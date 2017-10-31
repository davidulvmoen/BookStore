using System.Collections.Generic;

namespace BookStore.App.CartContext.Application
{
	public class CartDTO
	{
		public decimal Total { get; set; }

		public IEnumerable<CartItemDTO> CartItems { get; set; }
	}
}
