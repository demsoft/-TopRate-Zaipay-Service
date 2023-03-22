 
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
            var res = await EftPaymentService.CreateCustomer(createUser);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("Create/EFTTransaction")]
        public async Task<ActionResult> CreateEFTTransaction([FromBody] TransactionObj model)
        {
            var res = await EftPaymentService.CreateEFTTransaction(model);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("Search/EFTTransaction")]
        public async Task<ActionResult> SearchEFTTransaction([FromBody] SearchTransactionObj model)
        {
            var res = await EftPaymentService.SearchEFTTransaction(model);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("Cancel/EFTTransaction")]
        public async Task<ActionResult> CancelEFTTransaction([FromBody] CancelTransactionObj model)
        {
             var res = await EftPaymentService.CancelEFTTransaction(model);
             if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("Update/EFTCustomerAccount")]
        public async Task<ActionResult> UpdateEFTCustomerAccount([FromBody] UpdateCustomerObj model)
        {
            var res = await EftPaymentService.UpdateEFTCustomerAccount(model);
            if (res.StatusCode == 200){
                 return Ok(res);
            } else {
                return BadRequest(res);
            }
        }
    }
}