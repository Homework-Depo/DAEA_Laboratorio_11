namespace Lab11;


public class Invoice
{
  public int InvoiceId { get; set; }

  public DateTime Date { get; set; }
  public string InvoiceNumber { get; set; }
  public float Total { get; set; }

  // Navigation properties
  public Customer Customer { get; set; }
  //public List<Detail> Details { get; set; }
}
