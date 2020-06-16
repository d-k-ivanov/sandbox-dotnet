using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceOne.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceOneController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            // return "ServiceOne ";

            var client = new HttpClient();
            var ans1 = await client.GetStringAsync("http://localhost:8002/api/service");
            var ans2 = await client.GetStringAsync("http://localhost:8004/api/service");
            return $"ServiceOne {ans1} {ans2}";
        }
    }
}
