﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig
{
    public class SwaggerVersionMapping : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pathLists = new OpenApiPaths();
            IDictionary<string, OpenApiPaths> paths = new Dictionary<string, OpenApiPaths>();
            var version = swaggerDoc.Info.Version.Replace("v", "").Replace("version", "").Replace("ver", "").Replace(" ", "");
            foreach (var path in swaggerDoc.Paths)
            {
                pathLists.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
            }
            swaggerDoc.Paths = pathLists;
        }
    }
}
