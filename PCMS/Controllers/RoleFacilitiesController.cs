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
    public class RoleFacilitiesController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public RoleFacilitiesController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.RoleFacilities
                .Include(m => m.Facility_3)
                .Include(m => m.Rl_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.RoleFacilities
                .Include(m => m.Facility_3)
                .Include(m => m.Rl_3)
                .FirstOrDefault(m => m.RoleFacilitiesID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(RoleFacilities rlfa)
        {
            try
            {
                _db.RoleFacilities.Add(rlfa);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(RoleFacilities rlfa)
        {
            try
            {

                var existingRoleFacilities = _db.RoleFacilities.FirstOrDefault(m => m.RoleFacilitiesID == rlfa.RoleFacilitiesID);

                if (existingRoleFacilities != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingRoleFacilities.RoleID = rlfa.RoleID;
                    existingRoleFacilities.FacilityID = rlfa.FacilityID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy RoleFacilities với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("RoleFacilities not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{RoleFacilitiesID}")]
        public IActionResult Delete(int RoleFacilitiesID)
        {
            try
            {
                var roleFacilities = _db.RoleFacilities.Find(RoleFacilitiesID);
                if (roleFacilities != null)
                {
                    _db.RoleFacilities.Remove(roleFacilities);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"RoleFacilities with ID {RoleFacilitiesID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
