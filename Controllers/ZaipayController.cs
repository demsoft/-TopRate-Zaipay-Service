 
using Microsoft.AspNetCore.Mvc; 
using System.Threading.Tasks;
using Zaipay.Models.WebHooks;
using Zaipay.Service;
using Zaipay.ViewModels;

namespace Zaipay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaipayController : ControllerBase
    {
        private IZaiPayPlatform ZaiPayService;
        public ZaipayController(IZaiPayPlatform zaiPay)
        {
            ZaiPayService = zaiPay;
        }

        [HttpGet]
        [Route("Get/Token")]
        public ActionResult GetTokens()
        {

            return Ok(ZaiPayService.GetToken());
        }

        [HttpPost]
        [Route("Create/ZaiUser")]
        public async Task<ActionResult> CreateVirtualAccount([FromBody] CreateUserVm createUser)
        {
            return Ok(await ZaiPayService.CreateZaiUser(createUser));
        }

        [HttpPost]
        [Route("InitateTransaction")]
        public async Task<ActionResult> InitateTransaction(InitateTransaction initateTransaction)
        {

           var response = await ZaiPayService.InitiateTransaction(initateTransaction);

            return Ok(response);
        }

        [HttpPost]
        [Route("Webhook/VirtualAccountStatus")]
        public void WebhookVirtualAccountStatus(VirtualAccountObject virtualAccount)
        {
            ZaiPayService.VirtualAccountStatus(virtualAccount);
        }
        
        [HttpPost]
        [Route("Webhook/IncomingFunds")]
        public void WebhookIncomingFunds(Models.WebHooks.Transactions transactions)
        {
            ZaiPayService.IncomingFunds(transactions);
        }
    }
}
