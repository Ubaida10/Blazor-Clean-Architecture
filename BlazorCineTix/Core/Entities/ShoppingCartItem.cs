using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; }  // Make sure Movie has ImageUrl
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
