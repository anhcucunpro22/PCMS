using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCMS.AppModels;
using PCMS.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        PhotoCmsContext _db = new PhotoCmsContext();

        IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails(UserModel _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _db.Users
                    .Where(e => e.Email == _userData.EmailId && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    _userData.UserMessage = "Login Success";

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", _userData.ID.ToString()),
                        new Claim("DisplayName", _userData.FullName),
                        new Claim("UserName", _userData.FullName),
                        new Claim("Email", _userData.EmailId)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(_userData);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

    }
}
