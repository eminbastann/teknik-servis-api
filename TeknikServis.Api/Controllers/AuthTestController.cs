using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeknikServis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = "Giriş başarılı. Yetkili alana erişebildin.",
                userName = User.Identity?.Name,
                isAuthenticated = User.Identity?.IsAuthenticated
            });
        }
    }
}