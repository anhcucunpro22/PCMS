using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Interfaces;
using System.Linq;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly PhotoCmsContext _db;
        private readonly ICustomerApi _customerApi;
        public AuthorController(PhotoCmsContext db, ICustomerApi customerApi)
        {
            _db = db;
            _customerApi = customerApi;
        }

        [HttpGet("GetRollStaff")]
        [Authorize(Roles = "Staff")]
        public JsonResult GetStaff()
        {
            var data = _db.Customers
                .Where(c => c.Notes != "Admin")
                .Include(m => m.Organiza_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("GetRollCustomer")]
        [Authorize(Roles = "Customer")]
        public JsonResult GetCustomer()
        {
            var data = _db.Customers
                .Where(c => c.Notes != "Admin" && c.Notes != "Staff")
                .Include(m => m.Organiza_3)
                .ToList();
            return new JsonResult(data);
        }

        [HttpGet("SearchbyName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchCustomerByName(string name)
        {
            var result = await _customerApi.SearchCustomerByName(name);
            return Ok(result);
        }

    }
}
