using System;

public class VisitDto 
{
    public Guid Id { get; set; }
    public decimal Temperature { get; set; }
    public DateTime Date { get; set; }

    // from customer domain
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public int Age { get; set; }
    public string Barangay { get; set; }
    public string City { get; set; }

}