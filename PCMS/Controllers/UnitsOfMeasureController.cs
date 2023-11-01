using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsOfMeasureController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public UnitsOfMeasureController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.UnitsOfMeasure

                .ToList();
            return new JsonResult(data);
        }


        [HttpPost]
        public IActionResult Post(UnitsOfMeasure uom)
        {
            try
            {
                _db.UnitsOfMeasure.Add(uom);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                // Check the inner exception for more details
                if (ex.InnerException != null)
                {
                    var innerExceptionMessage = ex.InnerException.Message;
                    // Log or print the innerExceptionMessage for further investigation
                }

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(UnitsOfMeasure uom)
        {
            try
            {

                var existingUnitsOfMeasure = _db.UnitsOfMeasure.FirstOrDefault(m => m.UnitOfMeasureID == uom.UnitOfMeasureID);

                if (existingUnitsOfMeasure != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingUnitsOfMeasure.UnitName = uom.UnitName;
                    existingUnitsOfMeasure.Abbreviation = uom.Abbreviation;
                    existingUnitsOfMeasure.Description = uom.Description;
                    existingUnitsOfMeasure.ConversionFactor = uom.ConversionFactor;
                    existingUnitsOfMeasure.IsActive = uom.IsActive;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy UnitsOfMeasure với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("UnitsOfMeasure not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{UnitOfMeasureID}")]
        public IActionResult Delete(int UnitOfMeasureID)
        {
            try
            {

                var unitsOfMeasure = _db.UnitsOfMeasure.Find(UnitOfMeasureID);
                if (unitsOfMeasure != null)
                {
                    _db.UnitsOfMeasure.Remove(unitsOfMeasure);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"UnitsOfMeasure with ID {UnitOfMeasureID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }

    }
}
