using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
