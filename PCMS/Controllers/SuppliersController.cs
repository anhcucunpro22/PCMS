using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public SuppliersController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Suppliers
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Suppliers
               
                .FirstOrDefault(m => m.SupplierID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Suppliers sl)
        {
            try
            {
                _db.Suppliers.Add(sl);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Suppliers sl)
        {
            try
            {

                var existingSupplierss = _db.Suppliers.FirstOrDefault(m => m.SupplierID == sl.SupplierID);

                if (existingSupplierss != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingSupplierss.SupplierName = sl.SupplierName;
                    existingSupplierss.ContactName = sl.ContactName;
                    existingSupplierss.ContactEmail = sl.ContactEmail;
                    existingSupplierss.ContactPhone = sl.ContactPhone;
                    existingSupplierss.Address = sl.Address;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Suppliers với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Suppliers not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{SupplierID}")]
        public IActionResult Delete(int SupplierID)
        {
            try
            {
                var suppliers = _db.Suppliers.Find(SupplierID);
                if (suppliers != null)
                {
                    _db.Suppliers.Remove(suppliers);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Suppliers with ID {SupplierID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
