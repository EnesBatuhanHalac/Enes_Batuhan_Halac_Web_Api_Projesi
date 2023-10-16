namespace BrightAkademi.API.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Bu kısımda 403 hatasını kontrol edebilir ve gerekirse 200 OK dönebilirsiniz.
            // Örneğin, JWT token kontrolü yapılabilir.

            //if (context.Response.StatusCode == 403)
            //{
            //    context.Response.StatusCode = 200; // 403 hatasını 200 OK olarak değiştiriyoruz
            //    context.Response.Headers["Content-Type"] = "text/plain"; // Yanıtın tipini ayarlayabilirsiniz
            //    await context.Response.WriteAsync("Authorized"); // Yanıt metni
            //    return;
            //}
            //if (context.Response.StatusCode == 0)
            //{
            //    context.Response.StatusCode = 403;
            //    context.Response.Headers["Content-Type"] = "text/plain";
            //    await context.Response.WriteAsync("OK");
            //}
            await _next(context);
        }
    }

}
