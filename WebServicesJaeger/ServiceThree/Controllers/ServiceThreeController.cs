using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace ServiceThree.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceThreeController : ControllerBase
    {
        private readonly ITracer _tracer;

        public ServiceThreeController(ITracer tracer)
        {
            _tracer = tracer;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var span = _tracer.BuildSpan("ServiceThreeController Span").Start();
            span.Log("ServiceThreeController Log");
            span.SetTag("error",true);
            span.Finish();

            // return "ServiceThree ";

            var client = new HttpClient();
            var ans1 = await client.GetStringAsync("http://localhost:8004/api/service");
            var ans2 = await client.GetStringAsync("http://localhost:8005/api/service");
            return $"ServiceThree {ans1} {ans2}";
        }
    }
}
