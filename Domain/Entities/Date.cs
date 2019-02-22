using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Date : IEntity
    {
        public int Id { get; set; }
        public ICollection<BuyOrder> Orders { get; set; }   
        public DateTime MainDate { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}