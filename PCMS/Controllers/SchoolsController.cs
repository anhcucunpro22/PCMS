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
    public class SchoolsController : ControllerBase
    {
        private readonly PhotoCmsContext _db;

        public SchoolsController(PhotoCmsContext db)
        {

            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Schools
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Schools
               
                .FirstOrDefault(m => m.SchoolID == id);
            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(Schools sch)
        {
            try
            {
                _db.Schools.Add(sch);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Schools schools)
        {
            try
            {

                var existingSchools = _db.Schools.FirstOrDefault(m => m.SchoolID == schools.SchoolID);

                if (existingSchools != null)
                {

                    existingSchools.SchoolName = schools.SchoolName;
                    existingSchools.Address = schools.Address;
                    existingSchools.Phone = schools.Phone;
                    existingSchools.PrincipalName = schools.PrincipalName;
                    existingSchools.Email = schools.Email;



                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy Schools với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Schools not found");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{SchoolID}")]
        public IActionResult Delete(int SchoolID)
        {
            try
            {
                var schools = _db.Schools.Find(SchoolID);
                if (schools != null)
                {
                    _db.Schools.Remove(schools);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"School with ID {SchoolID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}
    

