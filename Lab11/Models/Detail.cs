namespace Lab11
{
  public class Detail
  {
    public int DetailId { get; set; }
    public int Amount { get; set; }
    public float Price { get; set; }
    public float SubTotal { get; set; }

    // Navigation properties
    public Product Product { get; set; }
    public Invoice Invoice { get; set; }
  }
}