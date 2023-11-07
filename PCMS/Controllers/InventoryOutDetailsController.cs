using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryOutDetailsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public InventoryOutDetailsController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.InventoryOutDetails
                .Include(m => m.EquipType_2)
                .Include(n => n.InvenOuts_4)
                 .Include(n => n.Materialist_3)
                 .Include(n => n.UnitMeasure_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.InventoryOutDetails
                .Include(m => m.EquipType_2)
                .Include(n => n.InvenOuts_4)
                 .Include(n => n.Materialist_3)
                 .Include(n => n.UnitMeasure_2)
                .FirstOrDefault(m => m.InventoryOutDetailID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(InventoryOutDetails ivo)
        {
            try
            {
                _db.InventoryOutDetails.Add(ivo);
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
        public IActionResult Put(InventoryOutDetails ivo)
        {
            try
            {

                var existingInventoryOutDetails = _db.InventoryOutDetails.FirstOrDefault(m => m.InventoryOutDetailID == ivo.InventoryOutDetailID);

                if (existingInventoryOutDetails != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingInventoryOutDetails.Quantity = ivo.Quantity;
                    existingInventoryOutDetails.UnitPrice = ivo.UnitPrice;
                    existingInventoryOutDetails.TotalAmount = ivo.TotalAmount;
                    existingInventoryOutDetails.Notes = ivo.Notes;
                    existingInventoryOutDetails.InventoryOutID = ivo.InventoryOutID;
                    existingInventoryOutDetails.MaterialID = ivo.MaterialID;
                    existingInventoryOutDetails.UnitOfMeasureID = ivo.UnitOfMeasureID;
                    existingInventoryOutDetails.EquipmentTypeID = ivo.EquipmentTypeID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy InventoryOutDetails với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("InventoryOutDetails not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{InventoryOutDetailID}")]
        public IActionResult Delete(int InventoryOutDetailID)
        {
            try
            {

                var inventoryOutDetails = _db.InventoryOutDetails.Find(InventoryOutDetailID);
                if (inventoryOutDetails != null)
                {
                    _db.InventoryOutDetails.Remove(inventoryOutDetails);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"InventoryOutDetails with ID {InventoryOutDetailID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
