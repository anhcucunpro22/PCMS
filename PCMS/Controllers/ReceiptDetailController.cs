using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptDetailController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public ReceiptDetailController(PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.ReceiptDetail
                .Include(m => m.Photo_2)
                .Include(m => m.Recei_3)
                .Include(m => m.Ser_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.ReceiptDetail
                .Include(m => m.Photo_2)
                .Include(m => m.Recei_3)
                .Include(m => m.Ser_2)
                .FirstOrDefault(m => m.ReceiptDetailID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(ReceiptDetail red)
        {
            try
            {

                _db.ReceiptDetail.Add(red);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(ReceiptDetail red)
        {
            try
            {

                var existingReceiptDetail = _db.ReceiptDetail.FirstOrDefault(m => m.ReceiptDetailID == red.ReceiptDetailID);

                if (existingReceiptDetail != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingReceiptDetail.ReceiptID = red.ReceiptID;
                    existingReceiptDetail.ServiceID = red.ServiceID;
                    existingReceiptDetail.PhotocopierID = red.PhotocopierID;
                    existingReceiptDetail.Quantity = red.Quantity;
                    existingReceiptDetail.UnitPrice = red.UnitPrice;
                    existingReceiptDetail.TotalAmount = red.TotalAmount;
                    
                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy ReceiptDetail với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("ReceiptDetail not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{ReceiptDetailID}")]
        public IActionResult Delete(int ReceiptDetailID)
        {
            try
            {
                var receiptDetail = _db.ReceiptDetail.Find(ReceiptDetailID);
                if (receiptDetail != null)
                {
                    _db.ReceiptDetail.Remove(receiptDetail);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"ReceiptDetail with ID {ReceiptDetailID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
