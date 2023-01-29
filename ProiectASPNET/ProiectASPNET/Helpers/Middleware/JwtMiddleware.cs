using ProiectASPNET.Helpers.JwtUtils;
using ProiectASPNET.Services.UserService;

namespace ProiectASPNET.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }   

        public async Task Invoke(HttpContext httpcontext, IUserService userService, IJwtUtils jwtutils)
        {
            var token = httpcontext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtutils.ValidateJwtToken(token);
            if (userId != Guid.Empty)
            {
                httpcontext.Items["User"] = userService.GetById(userId);
            }

            await _nextRequestDelegate(httpcontext);
        }
    }
}
