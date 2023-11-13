using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using PCMS.AppModels;
using PCMS.Data;
using PCMS.Interfaces;
using PCMS.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PCMS.Services
{
    public class AuthService : IAuthService
    {
        private readonly PhotoCmsContext _db;
        private readonly IConfiguration _configuration;
        public AuthService(PhotoCmsContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public Role AddRole(Role role)
        {
            var addedRole = _db.Role.Add(role);
            _db.SaveChanges();
            return addedRole.Entity;
        }

        public Users AddUser(Users users)
        {
            try
            {
                // Kiểm tra xem username đã tồn tại chưa
                var existingUser = _db.Users.FirstOrDefault(u => u.UserName == users.UserName);
                if (existingUser != null)
                {
                    throw new Exception("Username already exists");
                }

                // Kiểm tra xem email đã tồn tại chưa
                var existingEmail = _db.Users.FirstOrDefault(u => u.Email == users.Email);
                if (existingEmail != null)
                {
                    throw new Exception("Email already exists");
                }

                // Hash mật khẩu trước khi thêm người dùng
                users.Password = users.HashPassword(users.Password);

                _db.Users.Add(users);
                _db.SaveChanges();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public bool AssignRoleToUser(AddUserRole obj)
        {
            try
            {
                var addRoles = new List<UsersRole>();
                var user = _db.Users.SingleOrDefault(s => s.UserID == obj.UserId);
                if (user == null)
                    throw new Exception("User is not valid");
                foreach (int role in obj.RoleIds)
                {
                    var userRole = new UsersRole();
                    userRole.RoleID = role;
                    userRole.UserID = user.UserID;
                    addRoles.Add(userRole);
                }
                _db.UsersRole.AddRange(addRoles);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var user = _db.Users.SingleOrDefault(s => s.UserName == loginRequest.Username);
                if (user != null)
                {
                    // Xác minh mật khẩu
                    if (user.VerifyPassword(loginRequest.Password, user.Password))
                    {
                        // Tạo token JWT
                        var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.UserID.ToString()),
                        new Claim("UserName", user.UserName)
                        };
                        var userRoles = _db.UsersRole.Where(u => u.UserID == user.UserID).ToList();
                        var roleIds = userRoles.Select(s => s.RoleID).ToList();
                        var roles = _db.Role.Where(r => roleIds.Contains(r.RoleID)).ToList();
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                        return jwtToken;
                    }
                    else
                    {
                        throw new Exception("Invalid password");
                    }
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }



    }
}
