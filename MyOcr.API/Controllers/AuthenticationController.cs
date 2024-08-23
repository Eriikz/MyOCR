using Microsoft.AspNetCore.Mvc;

namespace MyOcr.API.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        public static IWebHostEnvironment _environment;

        public AuthenticationController(ILogger<AuthenticationController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        [HttpGet("GetEnvironment")]
        public string GetEnvironment()
        {
            string texto = " Web API - ImagemController em execução : " + DateTime.Now.ToLongTimeString();
            texto += $"\n Ambiente :  {_environment.EnvironmentName}";
            return texto;
        }
    }
}
