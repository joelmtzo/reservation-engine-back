using System.ComponentModel.DataAnnotations.Schema;

namespace REngine2.model;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    [Column("customer_id")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}