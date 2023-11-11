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
    public class DebtCollectionController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public DebtCollectionController( PhotoCmsContext db)
        {
            _db = db;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.DebtCollection
                .Include(m => m.Ctm_2)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.DebtCollection
                .Include(m => m.Ctm_2)
                .FirstOrDefault(m => m.DebtCollectionID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(DebtCollection dec)
        {
            try
            {

                _db.DebtCollection.Add(dec);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(DebtCollection dec)
        {
            try
            {

                var existingDebtCollection = _db.DebtCollection.FirstOrDefault(m => m.DebtCollectionID == dec.DebtCollectionID);

                if (existingDebtCollection != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingDebtCollection.CustomerID = dec.CustomerID;
                    existingDebtCollection.InvoiceDate = dec.InvoiceDate;
                    existingDebtCollection.CollectionDate = dec.CollectionDate;
                    existingDebtCollection.DebtAmount = dec.DebtAmount;
                    existingDebtCollection.AmountPaid = dec.AmountPaid;
                    existingDebtCollection.PaymentMethod = dec.PaymentMethod;
                    existingDebtCollection.RemainingAmount = dec.RemainingAmount;
                    existingDebtCollection.Notes = dec.Notes;
                    existingDebtCollection.Status = dec.Status;
                    existingDebtCollection.RecordCreationDate = dec.RecordCreationDate;
                    existingDebtCollection.CreatedBy = dec.CreatedBy;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy DebtCollection với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("DebtCollection not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{DebtCollectionID}")]
        public IActionResult Delete(int DebtCollectionID)
        {
            try
            {
                var debtCollection = _db.DebtCollection.Find(DebtCollectionID);
                if (debtCollection != null)
                {
                    _db.DebtCollection.Remove(debtCollection);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"DebtCollection with ID {DebtCollectionID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
