using Microsoft.AspNetCore.Mvc;

namespace MyOcr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : Controller
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
        }

    }
}
