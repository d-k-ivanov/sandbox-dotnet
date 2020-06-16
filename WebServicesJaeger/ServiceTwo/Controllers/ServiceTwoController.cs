using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;


namespace ServiceTwo.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceTwoController : ControllerBase
    {
        private readonly ITracer _tracer;

        public ServiceTwoController(ITracer tracer)
        {
            _tracer = tracer;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var span = _tracer.BuildSpan("ServiceTwoController Span").Start();
            span.Log("ServiceTwoController Log");
            span.SetTag("info",true);
            span.Finish();

            // return "ServiceTwo ";

            var client = new HttpClient();
            var ans1 = await client.GetStringAsync("http://localhost:8003/api/service");
            var ans2 = await client.GetStringAsync("http://localhost:8005/api/service");
            return $"ServiceTwo {ans1} {ans2}";
        }
    }
}
