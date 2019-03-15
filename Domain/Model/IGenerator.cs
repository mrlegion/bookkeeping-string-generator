using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Domain.Model
{
    public interface IGenerator
    {
        string Line { get; }
        List<string> Lines { get; }
        void OnGenerate(PaymentOrder order);
        Task OnGenerateAsync(PaymentOrder order);
        void OnGenerateList(IEnumerable<PaymentOrder> orders);
        Task OnGenerateListAsync(IEnumerable<PaymentOrder> orders);
    }
}