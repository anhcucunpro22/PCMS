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
    public class ServiceGroupsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public ServiceGroupsController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.ServiceGroups
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.ServiceGroups
               
                .FirstOrDefault(m => m.ServiceGroupID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(ServiceGroups serg)
        {
            try
            {
                _db.ServiceGroups.Add(serg);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(ServiceGroups serg)
        {
            try
            {

                var existingServiceGroups = _db.ServiceGroups.FirstOrDefault(m => m.ServiceGroupID == serg.ServiceGroupID);

                if (existingServiceGroups != null)
                {

                    existingServiceGroups.GroupName = serg.GroupName;
                    existingServiceGroups.Description = serg.Description;
                    existingServiceGroups.Category = serg.Category;
                    existingServiceGroups.IsActive = serg.IsActive;
                    
                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy ServiceGroups với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("ServiceGroups not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{ServiceGroupID}")]
        public IActionResult Delete(int ServiceGroupID)
        {
            try
            {
                var serviceGroups = _db.ServiceGroups.Find(ServiceGroupID);
                if (serviceGroups != null)
                {
                    _db.ServiceGroups.Remove(serviceGroups);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"ServiceGroups with ID {ServiceGroupID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
