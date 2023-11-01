using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryOutController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public InventoryOutController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.InventoryOut
                .Include(m => m.Organiza_2)
                .Include(n => n.Wahouses_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(InventoryOut ivo)
        {
            try
            {
                _db.InventoryOut.Add(ivo);
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
        public IActionResult Put(InventoryOut ivo)
        {
            try
            {

                var existingInventoryOut = _db.InventoryOut.FirstOrDefault(m => m.InventoryOutID == ivo.InventoryOutID);

                if (existingInventoryOut != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingInventoryOut.OutDate = ivo.OutDate;
                    existingInventoryOut.ReceiverName = ivo.ReceiverName;
                    existingInventoryOut.ReceiverPhone = ivo.ReceiverPhone;
                    existingInventoryOut.DeliveryMethod = ivo.DeliveryMethod;
                    existingInventoryOut.TotalAmount = ivo.TotalAmount;
                    existingInventoryOut.ModifiedDate = ivo.ModifiedDate;
                    existingInventoryOut.Percentage_Discount = ivo.Percentage_Discount;
                    existingInventoryOut.Discount_Amount = ivo.Discount_Amount;
                    existingInventoryOut.Percentage_Tax = ivo.Percentage_Tax;
                    existingInventoryOut.Tax_Amount = ivo.Tax_Amount;
                    existingInventoryOut.Tong_tien = ivo.Tong_tien;
                    existingInventoryOut.Created_by = ivo.Created_by;
                    existingInventoryOut.Created_date = ivo.Created_date;
                    existingInventoryOut.Notes = ivo.Notes;
                    existingInventoryOut.OrganizationID = ivo.OrganizationID;
                    existingInventoryOut.WarehouseID = ivo.WarehouseID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy InventoryOut với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("InventoryOut not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{InventoryOutID}")]
        public IActionResult Delete(int InventoryOutID)
        {
            try
            {

                var inventoryOut = _db.InventoryOut.Find(InventoryOutID);
                if (inventoryOut != null)
                {
                    _db.InventoryOut.Remove(inventoryOut);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"InventoryOut with ID {InventoryOutID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
