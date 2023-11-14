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
    public class ReceiptsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public ReceiptsController(PhotoCmsContext db)
        {
            _db = db;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Receipts
                .Include(m => m.Acc)
                .Include(m => m.Ctm_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Receipts
                .Include(m => m.Acc)
                .Include(m => m.Ctm_3)
                .FirstOrDefault(m => m.CustomerID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Receipts rec)
        {
            try
            {
                rec.Total_amount = rec.AmountReceived + rec.Tax_amount 
                    - rec.Discount_amount - rec.DepositPayment;
                _db.Receipts.Add(rec);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Receipts rec)
        {
            try
            {

                var existingReceipts = _db.Receipts.FirstOrDefault(m => m.CustomerID == rec.CustomerID);

                if (existingReceipts != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingReceipts.CustomerID = rec.CustomerID;
                    existingReceipts.AccountID = rec.AccountID;
                    existingReceipts.ReceivedDate = rec.ReceivedDate;
                    existingReceipts.ReceiptNumber = rec.ReceiptNumber;
                    existingReceipts.AmountReceived = rec.AmountReceived;
                    existingReceipts.Percentage_discount = rec.Percentage_discount;
                    existingReceipts.Discount_amount = rec.Discount_amount;
                    existingReceipts.DepositPayment = rec.DepositPayment;
                    existingReceipts.Percentage_tax = rec.Percentage_tax;
                    existingReceipts.Tax_amount = rec.Tax_amount;
                    existingReceipts.Total_amount = rec.Total_amount;
                    existingReceipts.PaymentMethod = rec.PaymentMethod;
                    existingReceipts.Created_by = rec.Created_by;
                    existingReceipts.Created_date = rec.Created_date;
                    existingReceipts.Modified_date = rec.Modified_date;
                    existingReceipts.Notes = rec.Notes;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Receipts với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Receipts not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{ReceiptID}")]
        public IActionResult Delete(int ReceiptID)
        {
            try
            {
                var receipts = _db.Receipts.Find(ReceiptID);
                if (receipts != null)
                {
                    _db.Receipts.Remove(receipts);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Receipts with ID {ReceiptID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
