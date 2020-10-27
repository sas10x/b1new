using System;

namespace Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
    }
}