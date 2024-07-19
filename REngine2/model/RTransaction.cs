using System.ComponentModel.DataAnnotations.Schema;

namespace REngine2.model;

public class RTransaction
{
    public int Id { get; set; }
    [Column("reservation_id")]
    public int ReservationId { get; set; }
    [Column("transaction_date")]
    public DateTime TransactionDate { get; set; }
    [Column("transaction_type")]
    public string TransactionType { get; set; }
    [Column("payment_method")]
    public string PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    [Column("transaction_status")]
    public string TransactionStatus { get; set; }
}