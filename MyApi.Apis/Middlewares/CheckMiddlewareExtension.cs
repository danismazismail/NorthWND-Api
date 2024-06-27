namespace MyApi.Apis.Middlewares
{
    public static class CheckMiddlewareExtension
    {
        public static IApplicationBuilder UseCheckMiddlewareExtension(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckMiddleware>();

        }

    }
}
