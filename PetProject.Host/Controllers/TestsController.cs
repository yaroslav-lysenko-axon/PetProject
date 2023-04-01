using Microsoft.AspNetCore.Mvc;

namespace PetProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}

