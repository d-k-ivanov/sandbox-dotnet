// using System.Net.Http;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace ServiceFive.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceFiveController : ControllerBase
    {
        private readonly ITracer _tracer;

        public ServiceFiveController(ITracer tracer)
        {
            _tracer = tracer;
        }

        [HttpGet]
        public string Get()
        {
            var span = _tracer.BuildSpan("ServiceFiveController Span").Start();
            span.Log("ServiceFiveController Log");
            span.SetTag("warning",true);
            span.Finish();
            return "ServiceFive";
        }

        // [HttpGet]
        // public async Task<string> Get()
        // {
        //     // return "ServiceFive ";
        //     var client = new HttpClient();
        //     var ans = await client.GetStringAsync("http://localhost:8006/api/service");
        //     return $"ServiceFive {ans}";
        // }
    }
}
