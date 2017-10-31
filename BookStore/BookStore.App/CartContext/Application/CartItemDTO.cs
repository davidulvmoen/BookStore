namespace BookStore.App.CartContext.Application
{
	public class CartItemDTO
	{
		public string ISBN { get; set; }

		public string Title { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public int DeliveredQuantity { get; set; }

		public int RestQuantity { get; set; }

		public decimal Total { get; set; }
	}
}
