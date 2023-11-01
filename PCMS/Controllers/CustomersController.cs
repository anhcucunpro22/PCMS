//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PCMS.Data;
//using PCMS.Models;

//namespace PCMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        //private readonly IConfiguration _configuration;
//        private readonly PhotoCmsContext _db;
//        public CustomersController(IConfiguration configuration, PhotoCmsContext db)
//        {
//            //_configuration = configuration;
//            _db = db;
//        }


//        [HttpGet]
//        public JsonResult Get()
//        {
//            var data = _db.Customers
//                .Include(m => m.Organiza_3)
//                .ToList();
//            return new JsonResult(data);
//        }
//        [HttpPost]
//        public IActionResult Post(Customers ct)
//        {
//            try
//            {

//                _db.Customers.Add(ct);
//                _db.SaveChanges();
//                return new JsonResult("Added Successfully");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"Error: {ex.Message}");
//            }
//        }
//    }
//}