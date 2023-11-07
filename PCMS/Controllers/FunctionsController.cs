using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public FunctionsController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Functions
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Functions

                .FirstOrDefault(m => m.FunctionID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Functions fuc)
        {
            try
            {
                _db.Functions.Add(fuc);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Functions fuc)
        {
            try
            {

                var existingFunctions = _db.Functions.FirstOrDefault(m => m.FunctionID == fuc.FunctionID);

                if (existingFunctions != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingFunctions.FunctionName = fuc.FunctionName;
                    existingFunctions.Description = fuc.Description;
                    existingFunctions.IsActive = fuc.IsActive;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Functions với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Functions not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{FunctionID}")]
        public IActionResult Delete(int FunctionID)
        {
            try
            {
                var functions = _db.Functions.Find(FunctionID);
                if (functions != null)
                {
                    _db.Functions.Remove(functions);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Functions with ID {FunctionID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
