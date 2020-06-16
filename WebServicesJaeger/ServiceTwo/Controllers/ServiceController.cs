using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ServiceTwo.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            // return "ServiceTwo ";
            var client = new HttpClient();
            var ans = await client.GetStringAsync("http://localhost:8003/api/service");
            return $"ServiceTwo {ans}";
        }
    }
}
