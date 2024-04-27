using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig
{
    public class SetVersionInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //var updatedPaths = new Dictionary<string, OpenApiPathItem>();
            var updatedPaths = new OpenApiPaths();
            foreach (var entry in swaggerDoc.Paths)
            {
                //updatedPaths.Add(
                //    entry.Key.Replace("v{version}",swaggerDoc.Info.Version),
                //    entry.Value
                //    );
                updatedPaths.Add(entry.Key.Replace("v{version}", swaggerDoc.Info.Version), entry.Value);
            }
            swaggerDoc.Paths = updatedPaths;
        }
    }
}
