using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PCMS.Models;
using PCMS.Data;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly PhotoCmsContext _db;
        public MaterialController(IConfiguration configuration, PhotoCmsContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _db.Materials
                .Include(m => m.MaterialGroup_1)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _db.Materials
                .Include(m => m.MaterialGroup_1)
                .FirstOrDefault(m => m.MaterialID == id);
            return new JsonResult(data);
        }


        [HttpPost]
        public IActionResult Post(Materials mat)
        {
            try
            {

                _db.Materials.Add(mat);
                _db.SaveChanges();
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }



        [HttpPut]
        public IActionResult Put(Materials mat)
        {
            try
            {

                var existingMaterial = _db.Materials.FirstOrDefault(m => m.MaterialID == mat.MaterialID);

                if (existingMaterial != null)
                {

                    existingMaterial.MaterialGroupID = mat.MaterialGroupID;
                    existingMaterial.MaterialName = mat.MaterialName;

                    _db.SaveChanges();

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy vật liệu với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("Material not found");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có.
                return BadRequest($"Error: {ex.Message}");
            }

        }



        [HttpDelete("{MaterialID}")]
        public IActionResult Delete(int MaterialID)
        {
            try
            {

                var material = _db.Materials.Find(MaterialID);
                if (material != null)
                {
                    _db.Materials.Remove(material);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"Material with ID {MaterialID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}




