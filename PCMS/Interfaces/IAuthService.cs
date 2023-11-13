using PCMS.AppModels;
using PCMS.Models;

namespace PCMS.Interfaces
{
    public interface IAuthService
    {
        Users AddUser(Users users);
        string Login(LoginRequest loginRequest);
        Role AddRole(Role role);
        bool AssignRoleToUser(AddUserRole obj);
    }
}
