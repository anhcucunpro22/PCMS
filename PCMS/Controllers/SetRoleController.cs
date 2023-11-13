using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCMS.Data;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetRoleController : ControllerBase
    {
        PhotoCmsContext _db = new PhotoCmsContext();

        IConfiguration _configuration;

        public SetRoleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
