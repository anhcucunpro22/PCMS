using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingFacilitiesController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public TrainingFacilitiesController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.TrainingFacilities
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.TrainingFacilities

                .FirstOrDefault(m => m.FacilityId == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(TrainingFacilities tf)
        {
            try
            {
                _db.TrainingFacilities.Add(tf);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(TrainingFacilities tf)
        {
            try
            {

                var existingTrainingFacilities = _db.TrainingFacilities.FirstOrDefault(m => m.FacilityId == tf.FacilityId);

                if (existingTrainingFacilities != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingTrainingFacilities.FacilityName = tf.FacilityName;
                    existingTrainingFacilities.Address = tf.Address;
                    existingTrainingFacilities.ContactName = tf.ContactName;
                    existingTrainingFacilities.ContactEmail = tf.ContactEmail;
                    existingTrainingFacilities.ContactPhone = tf.ContactPhone;
                    existingTrainingFacilities.Website = tf.Website;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy TrainingFacilities với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("TrainingFacilities not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{FacilityId}")]
        public IActionResult Delete(int FacilityId)
        {
            try
            {
                var trainingFacilities = _db.TrainingFacilities.Find(FacilityId);
                if (trainingFacilities != null)
                {
                    _db.TrainingFacilities.Remove(trainingFacilities);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"TrainingFacilities with ID {FacilityId} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}