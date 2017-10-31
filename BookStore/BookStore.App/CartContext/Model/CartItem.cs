namespace BookStore.App.CartContext.Model
{
	class CartItem
	{
		public string ISBN { get; set; }

		public string Title { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public int DeliveredQuantity { get; set; }

		public int RestQuantity { get; set; } 

		public decimal Total
		{
			get
			{
				return this.Quantity * this.Price;
			}
		}
	}
}
