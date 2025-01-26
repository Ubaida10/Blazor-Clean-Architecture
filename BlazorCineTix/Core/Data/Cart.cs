using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Core.Data
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }

        public User User { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal Total => Items.Sum(item => item.Movie.Price * item.Amount);
    }

}