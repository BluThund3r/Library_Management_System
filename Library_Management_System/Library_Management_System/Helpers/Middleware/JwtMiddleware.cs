using Library_Management_System.Helpers.JwtUtils;
using Library_Management_System.Services.UserService;

namespace Library_Management_System.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            this.nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if(userId != Guid.Empty)
            {
                httpContext.Items["User"] = userService.GetById(userId);
            }

            await nextRequestDelegate(httpContext);
        }
    }
}
