using API_piment.Services.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_piment.Services.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, JWTService jwtService, IConfiguration configuration)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsync("Unauthorized: Token is missing.");
                return;
            }

            BindContextToUser(context, token);
            await _next(context);
        }




        // Handle claims by extracting them from the token and binding them to the http context
        // way more secure than cookies or localstorage
        private void BindContextToUser(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                string secretKeyStr = Environment.GetEnvironmentVariable("SECRET_KEY");

                var secretKeyBit = Encoding.ASCII.GetBytes(secretKeyStr);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBit),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userID = jwtToken.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
                var username = jwtToken.Claims.First(i => i.Type == ClaimTypes.Name).Value;
                var role = jwtToken.Claims.First(i => i.Type == ClaimTypes.Role).Value;

                context.Items["UserID"] = userID;
                context.Items["Username"] = username;
                context.Items["Roles"] = role;
            }
            catch (Exception )
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            }

        }
    }
}
