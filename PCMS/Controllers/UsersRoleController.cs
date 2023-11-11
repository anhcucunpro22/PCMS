using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRoleController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public UsersRoleController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.UsersRole
                .Include(m => m.Rl_2)
                .Include(m => m.Usr_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.UsersRole
                .Include(m => m.Rl_2)
                .Include(m => m.Usr_2)
                .FirstOrDefault(m => m.UsersRoleID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(UsersRole usr)
        {
            try
            {
                _db.UsersRole.Add(usr);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(UsersRole usr)
        {
            try
            {

                var existingUsersRole = _db.UsersRole.FirstOrDefault(m => m.UsersRoleID == usr.UsersRoleID);

                if (existingUsersRole != null)
                {

                    existingUsersRole.UserID = usr.UserID;
                    existingUsersRole.RoleID = usr.RoleID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy UsersRole với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("UsersRole not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{UsersRoleID}")]
        public IActionResult Delete(int UsersRoleID)
        {
            try
            {
                var usersRole = _db.UsersRole.Find(UsersRoleID);
                if (usersRole != null)
                {
                    _db.UsersRole.Remove(usersRole);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Users with ID {UsersRoleID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
