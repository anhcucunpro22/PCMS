using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PCMS.Models;
using PCMS.Data;
using Microsoft.AspNetCore.Authorization;

namespace PCMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        
        private readonly PhotoCmsContext _db;
        public WarehousesController( PhotoCmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Warehouses
                .Include(m => m.Facility)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Warehouses
                .Include(m => m.Facility)
                .FirstOrDefault(m => m.WarehouseID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Warehouses hou)
        {
            try
            {
                _db.Warehouses.Add(hou);
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
        public IActionResult Put(Warehouses wh)
        {
            try
            {

                var existingWarehouses = _db.Warehouses.FirstOrDefault(m => m.WarehouseID == wh.WarehouseID);

                if (existingWarehouses != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingWarehouses.WarehouseName = wh.WarehouseName;
                    existingWarehouses.Address = wh.Address;
                    existingWarehouses.Phone = wh.Phone;
                    existingWarehouses.ManagerNameWh = wh.ManagerNameWh;
                    existingWarehouses.FacilityID = wh.FacilityID;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Warehouses với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Warehouses not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{WarehouseID}")]
        public IActionResult Delete(int WarehouseID)
        {
            try
            {

                var warehouses = _db.Warehouses.Find(WarehouseID);
                if (warehouses != null)
                {
                    _db.Warehouses.Remove(warehouses);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Warehouses with ID {WarehouseID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
