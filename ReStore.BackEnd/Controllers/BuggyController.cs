using Microsoft.AspNetCore.Mvc;

namespace ReStore.BackEnd.Controllers;

public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;

        public BuggyController(ILogger<BuggyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails{Title = "This is a Bad Request"});
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1", "First Error");
            ModelState.AddModelError("Problem2", "Second Error");
            ModelState.AddModelError("Problem3", "Third Error");

            return ValidationProblem();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }
    }
