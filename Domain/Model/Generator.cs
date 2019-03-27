using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Domain.Model
{
    public class Generator : IGenerator
    {
        private readonly ISaver _saver;

        public Generator(ISaver saver)
        {
            _saver = saver;
        }

        public string Line { get; private set; }
        public List<string> Lines { get; private set; }

        public void OnGenerate(PaymentOrder order, string folder)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (!CheckPayerAndRecipient(order)) throw new ArgumentNullException(nameof(order), "In order can not be null Payer and Recipient");

            var baseInfo = BaseInfoToString(order);
            var payer = OrganizationInfoToString(order.Payer);
            var recipient = OrganizationInfoToString(order.Recipient).TrimEnd('\u0009');

            Line += baseInfo + payer + recipient;

            var path = Path.Combine(folder, "combine.txt");
            _saver.InitFile(path);
            _saver.WriteLines(new List<string>() {GenerateInfoLine(), Line});
        }

        public void OnGenerateList(IEnumerable<PaymentOrder> orders, string folder)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));
            if (!orders.Any()) throw new ArgumentException("In orders not fount items, please check orders list");

            var list = new List<string>();
            list.Add(GenerateInfoLine());
            foreach (var order in orders)
            {
                var baseInfo = BaseInfoToString(order);
                var payer = OrganizationInfoToString(order.Payer);
                var recipient = OrganizationInfoToString(order.Recipient).TrimEnd('\u0009');

                list.Add(baseInfo + payer + recipient);
            }

            var path = Path.Combine(folder, "combine.txt");
            _saver.InitFile(path);
            _saver.WriteLines(list);
        }

        private bool CheckPayerAndRecipient(PaymentOrder order)
        {
            // Check payer
            var payer = order.Payer != null &&
                        order.Payer.Bank != null &&
                        order.Payer.Company != null &&
                        !string.IsNullOrEmpty(order.Payer.AccountNumber);

            // Check recipient
            var recipient = order.Recipient != null &&
                            order.Recipient.Bank != null &&
                            order.Recipient.Company != null &&
                            !string.IsNullOrEmpty(order.Recipient.AccountNumber);

            return payer && recipient;
        }

        private string OrganizationInfoToString(Organization organization)
        {
            var result = "";
            result += $"{organization.Company.Name}\t{organization.Company.Inn}\t{organization.Company.Kpp}\t";
            result += $"{organization.Bank.Name}\tГ. {organization.Bank.City}\t{organization.Bank.Bik}\t{organization.Bank.AccountNumber}\t";
            result += $"{organization.AccountNumber}\t";
            return result;
        }

        private string BaseInfoToString(PaymentOrder order)
        {
            var total = order.Total.Replace('.', '-');
            total = total.Replace(',', '-');

            var result = "";
            result += $"{order.Number}\t{order.Date.ToShortDateString()}\t{order.InDate.ToShortDateString()}\t{order.OutDate.ToShortDateString()}\t{order.AcceptDate.ToShortDateString()}\t";
            result += $"{total}\t{order.TotalText}\t{order.Description}\t";
            result += $"{order.TypeOfPayment}\t{order.TypeOfPaying}\t{order.QueuePayment}\t";

            return result;
        }

        private string GenerateInfoLine()
        {
            string result = "";
            result += "Номер\tДата\tДата поступления\tДата списания\tДата проведения\tСумма\tСумма прописью\t";
            result += "Назначение платежа\tВид платежа\tВид оплаты\tОчер. плат\t";
            result += "Плательщик\tИНН\tКПП\tБанк Плательщика\tГород банка\tБИК\tНомер счета банка\tНомер счета\t";
            result += "Получатель\tИНН\tКПП\tБанк Получателя\tГород банка\tБИК\tНомер счета банка\tНомер счета";

            return result;
        }
    }
}