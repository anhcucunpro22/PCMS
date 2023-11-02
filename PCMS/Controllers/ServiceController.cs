using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public ServiceController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Service
                .Include(m => m.SerGroup)
                .ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Service ser)
        {
            try
            {
                _db.Service.Add(ser);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Service ser)
        {
            try
            {

                var existingService = _db.Service.FirstOrDefault(m => m.ServiceID == ser.ServiceID);

                if (existingService != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingService.ServiceGroupID = ser.ServiceGroupID;
                    existingService.ServiceName = ser.ServiceName;
                    existingService.Description = ser.Description;
                    existingService.ServiceCategory = ser.ServiceCategory;
                    existingService.Price = ser.Price;
                    existingService.IsActive = ser.IsActive;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Service với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Service not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{ServiceID}")]
        public IActionResult Delete(int ServiceID)
        {
            try
            {
                var service = _db.Service.Find(ServiceID);
                if (service != null)
                {
                    _db.Service.Remove(service);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Service with ID {ServiceID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
