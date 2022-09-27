using System.ComponentModel.DataAnnotations;

namespace CustomerDatalayer.BusinessEntities
{
    [Serializable]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string? FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(15)]
        [RegularExpression("[0-9]+", ErrorMessage = "Invalid phone format")]
        public string? PhoneNumber { get; set; } = null;
        
        [RegularExpression("[a-zA-Z0-9]+[@]+[a-zA-Z0-9]+[.]+[a-zA-Z0-9]+", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; } = null;
        
        public decimal? TotalPurchasesAmount { get; set; } = 0;
    }
}
