using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using PCMS.Data;
using PCMS.Models;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialGroupController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly PhotoCmsContext _db;
        public MaterialGroupController(IConfiguration configuration, PhotoCmsContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //string query = @"
            //                select MaterialGroupID, MaterialGroupName, Description from
            //                dbo.Material_Group
            //                ";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("PCMSAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            var data = _db.MaterialGroup
                //.Include(m => m.Group)
                //.Where(m=>m.MaterialID <3)
                //.Select(m=> new {Name = m.MaterialName,m.MaterialGroupID})
                .ToList();

            return new JsonResult(data);
        }

        [HttpPost]
        public IActionResult Post(MaterialGroup mgr)
        {
            //string query = @"
            //                insert into dbo.Material_Group
            //                values(@MaterialGroupName,@Description)
            //                SELECT SCOPE_IDENTITY();
            //            ";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("PCMSAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("MaterialGroupName", mgr.MaterialGroupName);
            //        myCommand.Parameters.AddWithValue("Description", mgr.Description);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Added Successfully");
                try
                {

                    _db.MaterialGroup.Add(mgr);
                    _db.SaveChanges();
                    return new JsonResult("Added Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            

        }

        [HttpPut]
        public IActionResult Put(MaterialGroup mgr)
        {
            //    string query = @"
            //                    UPDATE dbo.Material_Group
            //                    SET MaterialGroupName = @MaterialGroupName, Description = @Description
            //                    WHERE MaterialGroupID = @MaterialGroupID;
            //                    ";
            //DataTable table = new DataTable();
            //    string sqlDataSource = _configuration.GetConnectionString("PCMSAppCon");
            //    SqlDataReader myReader;
            //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //    {
            //        myCon.Open();
            //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //        {
            //            myCommand.Parameters.AddWithValue("MaterialGroupID", mgr.MaterialGroupID);
            //            myCommand.Parameters.AddWithValue("MaterialGroupName", mgr.MaterialGroupName);
            //            myCommand.Parameters.AddWithValue("Description", mgr.Description);
            //            myReader = myCommand.ExecuteReader();
            //            table.Load(myReader);
            //            myReader.Close();
            //            myCon.Close();
            //        }
            //    }

            //    return new JsonResult("Update Successfully");
            try
            {
                
                var existingMaterialGroup = _db.MaterialGroup.FirstOrDefault(m => m.MaterialGroupID == mgr.MaterialGroupID);

                if (existingMaterialGroup != null)
                {
                    // Nếu MaterialGroup đã tồn tại, bạn có thể cập nhật các thông tin của nó.
                    existingMaterialGroup.MaterialGroupName = mgr.MaterialGroupName;
                    existingMaterialGroup.Description = mgr.Description;

                    _db.SaveChanges(); // Lưu các thay đổi vào tài liệu dữ liệu.

                    return new JsonResult("Updated Successfully");
                }
                else
                {
                    // Trường hợp không tìm thấy MaterialGroup với ID tương ứng, bạn có thể xem xét việc báo lỗi hoặc thực hiện thêm mới tại đây, tùy thuộc vào yêu cầu của bạn.
                    return NotFound("MaterialGroup not found");
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error: {ex.Message}");
            }

        }

        [HttpDelete("{MaterialGroupID}")]
        public IActionResult Delete(int MaterialGroupID)
        {
            //    string query = @"
            //                    Delete from dbo.Material_Group
            //                    Where MaterialGroupID = @MaterialGroupID
            //                    ";
            //    DataTable table = new DataTable();
            //    string sqlDataSource = _configuration.GetConnectionString("PCMSAppCon");
            //    SqlDataReader myReader;
            //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //    {
            //        myCon.Open();
            //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //        {
            //            myCommand.Parameters.AddWithValue("MaterialGroupID", MaterialGroupID);
            //            myReader = myCommand.ExecuteReader();
            //            table.Load(myReader);
            //            myReader.Close();
            //            myCon.Close();
            //        }
            //    }

            //    return new JsonResult("Deleted Successfully");
            try
            {
                var materialGroup = _db.MaterialGroup.Find(MaterialGroupID);
                if (materialGroup != null)
                {
                    _db.MaterialGroup.Remove(materialGroup);
                    _db.SaveChanges();
                    return new JsonResult("Delete Successfully");
                }
                else
                {
                    return NotFound($"MaterialGroup with ID {MaterialGroupID} not found.");
                }
            }
            catch (Exception exc)
            {
                return BadRequest($"Error: {exc.Message}");
            }
        }
    }
}

    

