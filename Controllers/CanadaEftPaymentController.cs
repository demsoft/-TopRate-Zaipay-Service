 
using Microsoft.AspNetCore.Mvc; 
using System.Threading.Tasks;
using Zaipay.Service;

namespace CanadaEftPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanadaEftPaymentController : ControllerBase
    {
        private ICanadaEftPaymentService EftPaymentService;
        public CanadaEftPaymentController(ICanadaEftPaymentService eftPayment)
        {
            EftPaymentService = eftPayment;
        }

        [HttpPost]
        [Route("Create/Customer")]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerObj createUser)
        {
            return Ok(await EftPaymentService.CreateCustomer(createUser));
        }
    }
}