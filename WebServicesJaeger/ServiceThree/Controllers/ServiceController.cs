using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceThree.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            // return "ServiceThree ";
            var client = new HttpClient();
            var ans = await client.GetStringAsync("http://localhost:8004/api/service");
            return $"ServiceThree {ans}";
        }
    }
}
