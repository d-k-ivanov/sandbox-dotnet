// using System.Net.Http;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceFive.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
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
