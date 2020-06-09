using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public int IdNUmber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public DateTime Date { get; set; }
    }
}