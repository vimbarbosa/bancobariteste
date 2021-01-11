using System.Threading.Tasks;
using Vini.Application.Interfaces;
using Vini.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Vini.Services.Api.Controllers
{
    public class HelloController : ApiController
    {
        private readonly IHelloAppService _helloAppService;

        public HelloController(IHelloAppService helloAppService)
        {
            _helloAppService = helloAppService;
        }

        [HttpPost("hello")]
        public async Task<IActionResult> Post([FromBody]HelloViewModel helloViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _helloAppService.SayHello(helloViewModel));
        }
    }
}
