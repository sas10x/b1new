using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        
    }
}