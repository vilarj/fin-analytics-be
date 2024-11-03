using Microsoft.AspNetCore.Mvc;

namespace Fin_Analytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateUserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok("User");
        }
    }
}