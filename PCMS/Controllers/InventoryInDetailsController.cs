using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryInDetailsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public InventoryInDetailsController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.InventoryInDetails
                .Include(m => m.InvenIn)
                .Include(n => n.Materials_2)
                 .Include(n => n.UnitMeasure)
                .ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(InventoryInDetails itd)
        {
            try
            {
                _db.InventoryInDetails.Add(itd);
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
        public IActionResult Put(InventoryInDetails itd)
        {
            try
            {

                var existingInventoryInDetails = _db.InventoryInDetails.FirstOrDefault(m => m.InventoryInDetailID == itd.InventoryInDetailID);

                if (existingInventoryInDetails != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingInventoryInDetails.InventoryInID = itd.InventoryInID;
                    existingInventoryInDetails.MaterialID = itd.MaterialID;
                    existingInventoryInDetails.UnitOfMeasureID = itd.UnitOfMeasureID;
                    existingInventoryInDetails.Quantity = itd.Quantity;
                    existingInventoryInDetails.UnitPrice = itd.UnitPrice;
                    existingInventoryInDetails.TotalPrice = itd.TotalPrice;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy InventoryInDetails với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("InventoryInDetails not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{InventoryInDetailID}")]
        public IActionResult Delete(int InventoryInDetailID)
        {
            try
            {

                var inventoryInDetails = _db.InventoryInDetails.Find(InventoryInDetailID);
                if (inventoryInDetails != null)
                {
                    _db.InventoryInDetails.Remove(inventoryInDetails);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"InventoryInDetails with ID {InventoryInDetailID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
