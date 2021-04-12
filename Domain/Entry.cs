using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Entry
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Temperature { get; set; }
        public string Action { get; set; }
        public string Branch { get; set; }
        public DateTime Date { get; set; }
        public string Qcode { get; set; }

    }
}