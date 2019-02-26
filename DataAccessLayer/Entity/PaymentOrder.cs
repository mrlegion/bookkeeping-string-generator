using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    [Table("order_info")]
    public class PaymentOrder
    {
        [Key]
        [Column("order_id")]
        public int Id { get; set; }

        /// <summary>
        /// Номер платежки
        /// </summary>
        [Required]
        [Column("order_number")]
        public int Number { get; set; }

        #region Даты

        /// <summary>
        /// Основная дата платежки
        /// </summary>
        [Column("order_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата поступления платежа
        /// </summary>
        [Column("order_in_date")]
        public DateTime InDate { get; set; }

        /// <summary>
        /// Дата списания платежа
        /// </summary>
        [Column("order_out_date")]
        public DateTime OutDate { get; set; }

        /// <summary>
        /// Дата проведения платежа
        /// </summary>
        [Column("order_accept_date")]
        public DateTime AcceptDate { get; set; }

        #endregion

        /// <summary>
        /// Сумма платежки
        /// </summary>
        [Required]
        [Column("order_total")]
        public int Total { get; set; }

        /// <summary>
        /// Сумма платежки прописью
        /// </summary>
        [Required]
        [Column("order_total_text")]
        public string TotalText { get; set; }

        /// <summary>
        /// Описание платежа платежки
        /// </summary>
        [MaxLength(500)]
        [Column("order_desc")]
        public string Description { get; set; }


        [Column("type_of_payment_id")]
        public int TypeOfPaymentId { get; set; }

        /// <summary>
        /// Вид платежа
        /// </summary>
        [Required]
        public Pay TypeOfPayment { get; set; }
        
        #region Компании

        [Column("payer_id")]
        public int PayerId { get; set; }

        /// <summary>
        /// Плательщик
        /// </summary>
        [Required]
        public Organization Payer { get; set; }

        [Column("recipient_id")]
        public int RecipientId { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [Required]
        public Organization Recipient { get; set; }

        #endregion

        [Required]
        [Column("order_type_of_paying")]
        public string TypeOfPaying { get; set; }

        [Required]
        [Column("order_queue_payment")]
        public string QueuePayment { get; set; }
    }
}
