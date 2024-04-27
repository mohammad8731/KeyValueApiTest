using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig
{
    public class ApplyFromBodyToAllComplexTypeParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) return;

            var allParameters = context.ApiDescription.ParameterDescriptions;

            //foreach (var parameter in allParameters)
            //{

            //}
            var type = allParameters[0].Type;
            var paramName= allParameters[0].Name;

            // Check if the parameter is a complex type (class) and not a simple type, 
            // nullable type, or a value type (struct)
            if (type.IsClass && type != typeof(string) && !type.IsValueType && !type.IsGenericType)
            {
                // Find and update the corresponding OpenAPI parameter
                var openApiParameter = operation.Parameters.FirstOrDefault(p => p.Name == paramName);
                if (openApiParameter != null)
                {
                    // Remove the parameter from operation parameters as it should be from body
                    operation.Parameters.Remove(openApiParameter);

                    // Ensure there's only one body parameter (considering best practices)
                    if (operation.RequestBody == null)
                    {
                        operation.RequestBody = new OpenApiRequestBody
                        {
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = context.SchemaGenerator.GenerateSchema(type, context.SchemaRepository)
                                }
                            },
                            Required = true
                        };
                    }
                }
            }
        }
    }
}
