using Infrastructure.Entities;
using System.Collections.Generic;

namespace WpfApp.UserControls.ViewModels
{
    public class PaymentOrderDetailViewModel : UserControlViewModelBase<PaymentOrder>
    {
        private IDictionary<string, string> _general;

        public IDictionary<string, string> General
        {
            get { return _general; }
            set { Set(nameof(General), ref _general, value); }
        }

        private IDictionary<string, string> _payer;

        public IDictionary<string, string> Payer
        {
            get { return _payer; }
            set { Set(nameof(Payer), ref _payer, value); }
        }

        private IDictionary<string, string> _recipient;

        public IDictionary<string, string> Recipient
        {
            get { return _recipient; }
            set { Set(nameof(Recipient), ref _recipient, value); }
        }

        private IDictionary<string, string> _additional;

        public IDictionary<string, string> Additional
        {
            get { return _additional; }
            set { Set(nameof(Additional), ref _additional, value); }
        }

        public override void Init(PaymentOrder entity, string title)
        {
            base.Init(entity, title);
            General = new Dictionary<string, string>()
            {
                { "Номер платежного поручения:", Entity.Number.ToString() },
                { "Дата платежного поручения:", Entity.Date.ToShortDateString() },
                { "Дата поступления:", Entity.InDate.ToShortDateString() },
                { "Дата списания:", Entity.OutDate.ToShortDateString() },
                { "Дата проведения:", Entity.AcceptDate.ToShortDateString() },
                { "Сумма платежного поручения:", Entity.Total },
                { "Сумма прописью:", Entity.TotalText },
            };

            Payer = new Dictionary<string, string>()
            {
                { "Наименование компании:", Entity.Payer.Company.Name },
                { "ИНН компании:", Entity.Payer.Company.Inn },
                { "КПП компании:", Entity.Payer.Company.Kpp },
                { "Банк плательщика:", Entity.Payer.Bank.Name },
                { "Город банка:", Entity.Payer.Bank.City },
                { "БИК банка плательщика:", Entity.Payer.Bank.Bik },
                { "Номер кор. счёта:", Entity.Payer.Bank.AccountNumber },
                { "Номер счёта компании:", Entity.Payer.AccountNumber },
            };

            Recipient = new Dictionary<string, string>()
            {
                { "Наименование компании:", Entity.Recipient.Company.Name },
                { "ИНН компании:", Entity.Recipient.Company.Inn },
                { "КПП компании:", Entity.Recipient.Company.Kpp },
                { "Банк получателя:", Entity.Recipient.Bank.Name },
                { "Город банка:", Entity.Recipient.Bank.City },
                { "БИК банка получателя:", Entity.Recipient.Bank.Bik },
                { "Номер кор. счёта:", Entity.Recipient.Bank.AccountNumber },
                { "Номер счёта компании:", Entity.Recipient.AccountNumber },
            };

            Additional = new Dictionary<string, string>()
            {
                { "Назначение платежа:", Entity.Description },
                { "Вид платежа:", Entity.TypeOfPayment },
                { "Вид оплаты:", Entity.TypeOfPaying },
                { "Очередность платежа:", Entity.QueuePayment },
            };
        }
    }
}