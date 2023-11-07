using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotocopierController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public PhotocopierController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Photocopier
                .Include(m => m.Facility_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Photocopier
                .Include(m => m.Facility_2)
                .FirstOrDefault(m => m.PhotocopierID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Photocopier phoc)
        {
            try
            {
                _db.Photocopier.Add(phoc);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Photocopier phoc)
        {
            try
            {

                var existingPhotocopier = _db.Photocopier.FirstOrDefault(m => m.PhotocopierID == phoc.PhotocopierID);

                if (existingPhotocopier != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingPhotocopier.Manufacturer = phoc.Manufacturer;
                    existingPhotocopier.Model = phoc.Model;
                    existingPhotocopier.ReleaseYear = phoc.ReleaseYear;
                    existingPhotocopier.WarrantyMonths = phoc.WarrantyMonths;
                    existingPhotocopier.SerialNumber = phoc.SerialNumber;
                    existingPhotocopier.Location = phoc.Location;
                    existingPhotocopier.PurchaseDate = phoc.PurchaseDate;
                    existingPhotocopier.PurchasePrice = phoc.PurchasePrice;
                    existingPhotocopier.IsActive = phoc.IsActive;
                    existingPhotocopier.FacilityID = phoc.FacilityID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Photocopier với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Photocopier not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{PhotocopierID}")]
        public IActionResult Delete(int PhotocopierID)
        {
            try
            {
                var photocopier = _db.Photocopier.Find(PhotocopierID);
                if (photocopier != null)
                {
                    _db.Photocopier.Remove(photocopier);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Photocopier with ID {PhotocopierID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
