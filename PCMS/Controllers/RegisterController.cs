using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCMS.Data;

namespace PCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        PhotoCmsContext _db = new PhotoCmsContext();
        
    }
}
