using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Date
    {
        public int DateId { get; set; }
        public ICollection<BuyOrder> Orders { get; set; }   
        public DateTime MainDate { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}