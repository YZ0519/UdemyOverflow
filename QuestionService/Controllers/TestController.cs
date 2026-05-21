using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QuestionService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("error")]
        public ActionResult GetErrorResponses(int code)
        {
            ModelState.AddModelError("Problem one", "Validation problem one");
            ModelState.AddModelError("Problem two", "Validation problem two");
            return code switch
            {
                400 => BadRequest("Opposite of good request"),
                401 => Unauthorized("You must logged in"),
                403 => Forbid(),
                404 => NotFound(),
                500 => throw new Exception("This is a server error"),
                _ => ValidationProblem(ModelState)

            };
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult TestAuth()
        {
            var user = User.FindFirstValue("name");
            return Ok($"{user} has been authorized");
        }
    }
}
