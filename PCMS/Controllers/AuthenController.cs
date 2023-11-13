using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCMS.AppModels;
using PCMS.Interfaces;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthenController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public string Login([FromBody] LoginRequest obj)
        {
            var token = _auth.Login(obj);
            return token;
        }

        [HttpPost("assignRole")]
        public bool AssignRoleToUser([FromBody] AddUserRole userRole)
        {
            var addedUserRole = _auth.AssignRoleToUser(userRole);
            return addedUserRole;
        }

        [HttpPost("addUser")]
        public Users AddUser([FromBody] Users user)
        {
            var addeduser = _auth.AddUser(user);
            return addeduser;
        }

        [HttpPost("addRole")]
        public Role AddRole([FromBody] Role role)
        {
            var addedRole = _auth.AddRole(role);
            return addedRole;
        }
    }
}
