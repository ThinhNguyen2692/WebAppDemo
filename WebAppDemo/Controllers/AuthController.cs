using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppDemo.Data.Models;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly ITokenService _tokenService;
        private readonly EcommerceAuthenticationServiceContext _context;
        private readonly JwtSettings _jwtSettings;
        public AuthController(
        IIdentityServerInteractionService interactionService,
        ITokenService tokenService,
        IOptions<JwtSettings> jwtSettings,
        EcommerceAuthenticationServiceContext context)
        {
            _interactionService = interactionService;
            _tokenService = tokenService;
            _jwtSettings = jwtSettings.Value;
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {         
            var user =  _context.Users.FirstOrDefault(x => x.EmailAddres == request.EmailAddres);
            if (user != null && user.Password == request.Password)
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.EmailAddres),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpireMinutes));

                var token = new JwtSecurityToken(
                    _jwtSettings.Issuer,
                    _jwtSettings.Issuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expires
                });
            }

            return Unauthorized();
        }
    }
    
}
