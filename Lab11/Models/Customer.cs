namespace Lab11;

public class Customer
{
  public int CustomerId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string DocumentNumber { get; set; }

  // Navigation property
  //public List<Invoice> Invoices { get; set; }
}
