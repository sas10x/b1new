using System;

namespace Domain
{
    public class Visit
    {
        public Guid Id { get; set; }
        public decimal Temperature { get; set; }
        public string Action { get; set; }
        public string Branch { get; set; }
        public DateTime Date { get; set; }
        
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}