 
using Microsoft.AspNetCore.Mvc; 
using System.Threading.Tasks;
using Zaipay.Service;

namespace FinmoAuFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinmoAuFlowController : ControllerBase
    {
        private IFinmoAuFlow FinmoAuFlow;
        public FinmoAuFlowController(IFinmoAuFlow finmoAuFlow)
        {
            FinmoAuFlow = finmoAuFlow;
        }

        [HttpPost]
        [Route("Create/Customer")]
        public async Task<ActionResult> CreateCustomer([FromBody] FinmoCustomerObj createUser)
        {
            return Ok(await FinmoAuFlow.CreateCustomer(createUser));
        }

        [HttpPost]
        [Route("Create/Wallet")]
        public async Task<ActionResult> CreateWallet([FromBody] WalletRequestObj createWallet)
        {
            return Ok(await FinmoAuFlow.CreateWallet(createWallet));
        }
    }
}