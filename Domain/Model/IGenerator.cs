using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Domain.Model
{
    public interface IGenerator
    {
        void OnGenerate(PaymentOrder order);
        Task OnGenerateAsync(PaymentOrder order);
        void OnGenerateList(IEnumerable<PaymentOrder> orders);
        Task OnGenerateListAsync(IEnumerable<PaymentOrder> orders);
    }
}