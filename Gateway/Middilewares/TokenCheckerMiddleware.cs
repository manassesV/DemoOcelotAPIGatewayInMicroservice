namespace Gateway.Middilewares
{
    public class TokenCheckerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            string request = context.Request.Path.Value!;

            if(request.Contains("account/login", StringComparison.InvariantCultureIgnoreCase)
                || request.Contains("account/register", StringComparison.InvariantCultureIgnoreCase)
                || request.Equals("/")){

                await next(context);
            }
            else
            {
                var authHeader = context.Request.Headers.Authorization;

                if(authHeader.FirstOrDefault() == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Sorry, Access denied");
                }
                else
                {
                    await next(context);
                }
            }
        }
    }
}
