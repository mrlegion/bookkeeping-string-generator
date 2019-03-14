using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Domain.Model
{
    public class Generator : IGenerator
    {
        public void OnGenerate(PaymentOrder order)
        {
            throw new System.NotImplementedException();
        }

        public Task OnGenerateAsync(PaymentOrder order)
        {
            throw new System.NotImplementedException();
        }

        public void OnGenerateList(IEnumerable<PaymentOrder> orders)
        {
            throw new System.NotImplementedException();
        }

        public Task OnGenerateListAsync(IEnumerable<PaymentOrder> orders)
        {
            throw new System.NotImplementedException();
        }
    }
}