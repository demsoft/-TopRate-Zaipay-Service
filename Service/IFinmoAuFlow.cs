using System.Collections.Generic;
using System.Threading.Tasks;
using Zaipay.Models;
using Zaipay.Models.WebHooks;
using Zaipay.ViewModels;

namespace Zaipay.Service
{
    public interface IFinmoAuFlow
    {
        Task<CustomerResponseObject> CreateCustomer(FinmoCustomerObj request);
        Task<WalletResponseObj> CreateWallet(WalletRequestObj request);
    }
}
