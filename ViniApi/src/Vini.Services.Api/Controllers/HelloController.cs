using System.Threading.Tasks;
using Vini.Application.Interfaces;
using Vini.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Vini.Services.Api.Controllers
{
    public class HelloController : ApiController
    {
        private readonly IHelloAppService _helloAppService;

        private readonly ILogger<HelloController> _log;

        public HelloController(IHelloAppService helloAppService, ILogger<HelloController> log)
        {
            _helloAppService = helloAppService;
            _log = log;
        }

        [HttpPost("hello")]
        public async Task<IActionResult> Post([FromBody]HelloViewModel helloViewModel)
        {
            _log.LogInformation($"[{nameof(HelloController)}][{nameof(Post)}]Posted|{JsonSerializer.Serialize(helloViewModel)}");

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _helloAppService.SayHello(helloViewModel));
        }
    }
}
