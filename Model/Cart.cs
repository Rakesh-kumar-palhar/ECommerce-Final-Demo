using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Final_Demo.Model
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        public Guid UserId { get; set; } 


        [Required]
        public Guid ItemId { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; } 

        public decimal Price { get; set; }

        [Required]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        //Relationship
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }

      


    }
}
