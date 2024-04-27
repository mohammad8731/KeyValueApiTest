namespace AzarDataNetTestAPI.Modules.Common.Application.Middleware
{
    public static class UseExceptionHandelingMiddleware
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
         => app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
