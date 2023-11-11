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
    public class CustomersController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        public CustomersController( PhotoCmsContext db)
        {
            _db = db;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Customers
                .Include(m => m.Organiza_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Customers
                .Include(m => m.Organiza_3)
                .FirstOrDefault(m => m.CustomerID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Customers ct)
        {
            try
            {

                _db.Customers.Add(ct);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPut]
        public IActionResult Put(Customers ct)
        {
            try
            {

                var existingCustomers = _db.Customers.FirstOrDefault(m => m.CustomerID == ct.CustomerID);

                if (existingCustomers != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingCustomers.CustomerName = ct.CustomerName;
                    existingCustomers.Address = ct.Address;
                    existingCustomers.Phone = ct.Phone;
                    existingCustomers.Email = ct.Email;
                    existingCustomers.Industry = ct.Industry;
                    existingCustomers.Notes = ct.Notes;
                    existingCustomers.OrganizationID = ct.OrganizationID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Customers với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Customers not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{CustomerID}")]
        public IActionResult Delete(int CustomerID)
        {
            try
            {
                var customers = _db.Customers.Find(CustomerID);
                if (customers != null)
                {
                    _db.Customers.Remove(customers);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Customers with ID {CustomerID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}