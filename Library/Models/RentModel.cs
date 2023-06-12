namespace Library.Models;

public class RentModel
{
    public int ID { get; set; }
    public int BookId { get; set; }
    public int ClientId { get; set; }
    public int Status { get; set; }
}