using System.Collections.Generic;
using System.Threading.Tasks;
using Zaipay.Models;
using Zaipay.Models.WebHooks;
using Zaipay.ViewModels;

namespace Zaipay.Service
{
    public interface ICanadaEftPaymentService
    {
        Task<string> CreateCustomer(CreateCustomerObj request);
    }
}
