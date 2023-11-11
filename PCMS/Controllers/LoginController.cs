using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCMS.AppModels;
using PCMS.Data;
using PCMS.Models;
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
        [Route("PostRegisterDetails")]
        public async Task<IActionResult> PostRegisterDetails(UserAuthen _userAuthen)
        {
            if (_userAuthen != null)
            {
                // Check if the user with the same email already exists in the database
                var existingUser = _db.Users.FirstOrDefault(e => e.Email == _userAuthen.EmailId);
                if (existingUser != null)
                {
                    return BadRequest("Email already exists");
                }

                // Create a new user entity and populate its properties
                var newUser = new Users
                {
                    UserName = _userAuthen.UserName,
                    FullName = _userAuthen.FullName,
                    Email = _userAuthen.EmailId,
                    Password = _userAuthen.HashPassword(_userAuthen.Password), // Mã hóa password trước khi lưu vào cơ sở dữ liệu
                    Isactive = true,
                    Notes = _userAuthen.Notes,
                };

                // Add the new user to the database
                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();

                _userAuthen.UserMessage = "Registration Success";

                return Ok(_userAuthen);
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

        

        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails(UserModel _userData)
        {
            if (_userData != null)
            {
                var user = _db.Users.FirstOrDefault(e => e.Email == _userData.EmailId);
                if (user == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    var userModel = new UserModel(); // Create an instance of UserModel
                    bool isPasswordValid = userModel.VerifyPassword(_userData.Password, user.Password); // Call VerifyPassword on the userModel instance
                    if (!isPasswordValid)
                    {
                        return BadRequest("Invalid Credentials");
                    }

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
