 
using Microsoft.AspNetCore.Mvc; 
using System.Threading.Tasks;
using Zaipay.Service;

namespace CanadaEftPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanadaInteracController : ControllerBase
    {
        private ICanadaInteracPaymentService InteracPayment;
        public CanadaInteracController(ICanadaInteracPaymentService interacPayment)
        {
            InteracPayment = interacPayment;
        }

        [HttpPost]
        [Route("Request/Interac/Etransfer/Link")]
        public async Task<ActionResult> RequestInterac([FromBody] RequestInteracObj model)
        {
            var res = await InteracPayment.RequestInterac(model);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Route("Get/Payment/Link/")]
        public ActionResult GetWalletById(string rID)
        {

            return Ok(InteracPayment.GetPaymentLink(rID));
        }

        [HttpPost]
        [Route("Search/Interac/Etransfer/Array")]
        public async Task<ActionResult> SearchRequestInterac([FromBody] SearchRequestInteracObj model)
        {
            var res = await InteracPayment.SearchRequestInterac(model);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }
    }
}