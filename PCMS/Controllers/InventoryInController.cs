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
    public class InventoryInController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public InventoryInController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.InventoryIn
                .Include(m => m.Suppli)
                .Include(n => n.Wahouses_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.InventoryIn
                .Include(m => m.Suppli)
                .Include(n => n.Wahouses_2)
                .FirstOrDefault(m => m.InventoryInID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(InventoryIn ivi)
        {
            try
            {
                _db.InventoryIn.Add(ivi);
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
        public IActionResult Put(InventoryIn ivi)
        {
            try
            {

                var existingInventoryIn = _db.InventoryIn.FirstOrDefault(m => m.InventoryInID == ivi.InventoryInID);

                if (existingInventoryIn != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingInventoryIn.InvoiceNumber = ivi.InvoiceNumber;
                    existingInventoryIn.InventoryInDate = ivi.InventoryInDate;
                    existingInventoryIn.ReceivedBy = ivi.ReceivedBy;
                    existingInventoryIn.AmountReceived = ivi.AmountReceived;
                    existingInventoryIn.Percentage_discount = ivi.Percentage_discount;
                    existingInventoryIn.Discount_amount = ivi.Discount_amount;
                    existingInventoryIn.Percentage_tax = ivi.Percentage_tax;
                    existingInventoryIn.Tax_amount = ivi.Tax_amount;
                    existingInventoryIn.Total_amount = ivi.Total_amount;
                    existingInventoryIn.PaymentMethod = ivi.PaymentMethod;
                    existingInventoryIn.Created_by = ivi.Created_by;
                    existingInventoryIn.Created_date = ivi.Created_date;
                    existingInventoryIn.Modified_date = ivi.Modified_date;
                    existingInventoryIn.Notes = ivi.Notes;
                    existingInventoryIn.WarehouseID = ivi.WarehouseID;
                    existingInventoryIn.SupplierID = ivi.SupplierID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy InventoryIn với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("InventoryIn not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{InventoryInID}")]
        public IActionResult Delete(int InventoryInID)
        {
            try
            {

                var inventoryIn = _db.InventoryIn.Find(InventoryInID);
                if (inventoryIn != null)
                {
                    _db.InventoryIn.Remove(inventoryIn);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"InventoryIn with ID {InventoryInID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
