using API.Errors;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public BuggyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("test_auth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("not_found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _dbContext.Generos.Find(42);
            if (thing is null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("server_error")]
        public ActionResult GetServerError()
        {
            var thing = _dbContext.Generos.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("bad_request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad_request/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();

        }
    }
}
