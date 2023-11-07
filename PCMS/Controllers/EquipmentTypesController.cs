using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypesController : ControllerBase
    {

        private readonly PhotoCmsContext _db;

        public EquipmentTypesController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.EquipmentTypes
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.EquipmentTypes
                
                .FirstOrDefault(m => m.EquipmentTypeID == id);
            return new JsonResult(data);
        }


        [HttpPost]
        public IActionResult Post(EquipmentTypes eqm)
        {
            try
            {
                _db.EquipmentTypes.Add(eqm);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(EquipmentTypes eqm)
        {
            try
            {

                var existingEquipmentTypes = _db.EquipmentTypes.FirstOrDefault(m => m.EquipmentTypeID == eqm.EquipmentTypeID);

                if (existingEquipmentTypes != null)
                {

                    existingEquipmentTypes.TypeName = eqm.TypeName;
                    existingEquipmentTypes.Description = eqm.Description;
                    existingEquipmentTypes.Manufacturer = eqm.Manufacturer;
                    existingEquipmentTypes.Model = eqm.Model;
                    existingEquipmentTypes.ReleaseYear = eqm.ReleaseYear;
                    existingEquipmentTypes.WarrantyMonths = eqm.WarrantyMonths;
                    existingEquipmentTypes.PurchasePrice = eqm.PurchasePrice;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy EquipmentTypes với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("EquipmentTypes not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{EquipmentTypeID}")]
        public IActionResult Delete(int EquipmentTypeID)
        {
            try
            {
                var equipmentTypes = _db.EquipmentTypes.Find(EquipmentTypeID);
                if (equipmentTypes != null)
                {
                    _db.EquipmentTypes.Remove(equipmentTypes);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"EquipmentTypes with ID {EquipmentTypeID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
