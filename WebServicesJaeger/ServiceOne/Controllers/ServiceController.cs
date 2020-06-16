using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceOne.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            // return "ServiceOne ";
            var client = new HttpClient();
            var ans = await client.GetStringAsync("http://localhost:8002/api/service");
            return $"ServiceOne {ans}";
        }
    }
}
