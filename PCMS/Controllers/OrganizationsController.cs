using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public OrganizationsController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Organizations
                .Include(m => m.Sch)
                .ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Organizations org)
        {
            try
            {
                _db.Organizations.Add(org);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Organizations org)
        {
            try
            {

                var existingOrganizations = _db.Organizations.FirstOrDefault(m => m.OrganizationID == org.OrganizationID);

                if (existingOrganizations != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingOrganizations.OrganizationName = org.OrganizationName;
                    existingOrganizations.Address = org.Address;
                    existingOrganizations.Phone = org.Phone;
                    existingOrganizations.ContactPerson = org.ContactPerson;
                    existingOrganizations.Email = org.Email;
                    existingOrganizations.SchoolID = org.SchoolID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Organizations  với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Organizations not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{OrganizationID}")]
        public IActionResult Delete(int OrganizationID)
        {
            try
            {
                var organizations = _db.Organizations.Find(OrganizationID);
                if (organizations != null)
                {
                    _db.Organizations.Remove(organizations);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Organizations with ID {OrganizationID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
