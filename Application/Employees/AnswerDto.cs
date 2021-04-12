using System;
using System.Collections.Generic;


namespace Application.Employees
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public DateTime Date { get; set; }

    }
}