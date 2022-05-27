using Calculator.API.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Calculator.API.Controllers.V1
{
    [Route(@"api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IApiKeyService _key;

        public LoginController()
        {
            _key = new ApiKeyService();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == _key.GetUsername() && password == _key.GetPassword())
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key.GetApiKey()));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
