using System;

namespace Domain
{
    public class Visit
    {
        public Guid Id { get; set; }
        public int Temperature { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }

    }
}