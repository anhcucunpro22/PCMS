using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleFunctionController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public RoleFunctionController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.RoleFunction
                .Include(m => m.Func)
                .Include(m => m.Rl)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.RoleFunction
                .Include(m => m.Func)
                .Include(m => m.Rl)
                .FirstOrDefault(m => m.RoleFunctionID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(RoleFunction rlf)
        {
            try
            {
                _db.RoleFunction.Add(rlf);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(RoleFunction rlf)
        {
            try
            {

                var existingRoleFunction = _db.RoleFunction.FirstOrDefault(m => m.RoleFunctionID == rlf.RoleFunctionID);

                if (existingRoleFunction != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingRoleFunction.RoleID = rlf.RoleID;
                    existingRoleFunction.FunctionID = rlf.FunctionID;
                    
                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy RoleFunction với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("RoleFunction not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{RoleFunctionID}")]
        public IActionResult Delete(int RoleFunctionID)
        {
            try
            {
                var roleFunction = _db.RoleFunction.Find(RoleFunctionID);
                if (roleFunction != null)
                {
                    _db.RoleFunction.Remove(roleFunction);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"RoleFunction with ID {RoleFunctionID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
