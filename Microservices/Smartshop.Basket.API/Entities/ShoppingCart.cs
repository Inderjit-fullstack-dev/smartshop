namespace Smartshop.Basket.API.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart(string username)
        {
            Username = username;
            Items = new List<ShoppingCartItem>();
        }

        public decimal TotalPrice { 
            get 
            {
                decimal price = 0;
                Items.ForEach(item => 
                {
                    price += (item.Price * item.Quantity);
                });
                return price;
            } 
        }
    }
}
