using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ECommerce_Final_Demo.Model
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        [Required]
        public Country Country { get; set; } // Enum for Country
        [Required]
        public State State { get; set; } // Enum for State
        [Required]
        public City City { get; set; } //Enum for city
        public string? Image { get; set; } 
        //relationship
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
    public enum Country
    {
        USA,
        
        India
    }

    public enum State
    {
    
        California,

        Chikago,

        Maharashtra,

        Ahmadabad
    }

    public enum City
    {
        
        LosAngeles,

        Toronto,

        Mumbai,

        AnandNagar
    }



}