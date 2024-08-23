﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Final_Demo.Model
{
    public class CartItem
    {
        public Guid CartId { get; set; }
        
        public Cart? Cart { get; set;}
        public Guid ItemId { get; set; }
        
        public Item? Item{ get; set; }
    }
}
