using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyAccountController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public MoneyAccountController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.MoneyAccount
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.MoneyAccount
                
                .FirstOrDefault(m => m.AccountID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(MoneyAccount moc)
        {
            try
            {
                _db.MoneyAccount.Add(moc);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(MoneyAccount moc)
        {
            try
            {

                var existingMoneyAccount = _db.MoneyAccount.FirstOrDefault(m => m.AccountID == moc.AccountID);

                if (existingMoneyAccount != null)
                {

                    existingMoneyAccount.AccountName = moc.AccountName;
                    existingMoneyAccount.AccountType = moc.AccountType;
                    existingMoneyAccount.Balance = moc.Balance;
                    existingMoneyAccount.IsLocked = moc.IsLocked;
                    existingMoneyAccount.Currency = moc.Currency;
                    existingMoneyAccount.BankName = moc.BankName;
                    existingMoneyAccount.AccountNumber = moc.AccountNumber;
                    existingMoneyAccount.ContactPerson = moc.ContactPerson;
                    existingMoneyAccount.ContactEmail = moc.ContactEmail;
                    existingMoneyAccount.ContactPhone = moc.ContactPhone;
                    existingMoneyAccount.Notes = moc.Notes;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy MoneyAccount với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("MoneyAccount not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{AccountID}")]
        public IActionResult Delete(int AccountID)
        {
            try
            {
                var moneyAccount = _db.MoneyAccount.Find(AccountID);
                if (moneyAccount != null)
                {
                    _db.MoneyAccount.Remove(moneyAccount);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"MoneyAccount with ID {AccountID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
