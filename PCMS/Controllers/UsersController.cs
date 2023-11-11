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
    public class UsersController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public UsersController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Users
                .Include(m => m.Ctm_4)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Users
                .Include(m => m.Ctm_4)
                .FirstOrDefault(m => m.UserID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Users use)
        {
            try
            {
                _db.Users.Add(use);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Users use)
        {
            try
            {

                var existingUsers = _db.Users.FirstOrDefault(m => m.UserID == use.UserID);

                if (existingUsers != null)
                {

                    existingUsers.UserName = use.UserName;
                    existingUsers.FullName = use.FullName;
                    existingUsers.Email = use.Email;
                    existingUsers.Password = use.Password;
                    existingUsers.Notes = use.Notes;
                    existingUsers.Isactive = use.Isactive;
                    existingUsers.CustomerID = use.CustomerID;


                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Users với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Users not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            try
            {
                var users = _db.Users.Find(UserID);
                if (users != null)
                {
                    _db.Users.Remove(users);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Users with ID {UserID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
