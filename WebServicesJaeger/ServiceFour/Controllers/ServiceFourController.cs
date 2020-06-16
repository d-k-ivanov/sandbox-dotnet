using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceFour.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceFourController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            // return "ServiceFour ";
            var client = new HttpClient();
            var ans = await client.GetStringAsync("http://localhost:8005/api/service");
            return $"ServiceFour {ans}";
        }
    }
}
