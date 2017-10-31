using System;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.App.CartContext.Model
{
	class Cart
	{
		public decimal Total
		{
			get
			{
				if (this.CartItems == null)
				{
					return 0;
				}

				var total = 0M;

				foreach (var item in CartItems)
				{
					total += item.Price * item.Quantity;
				}

				return total;
			}
		}

		public IEnumerable<CartItem> CartItems { get; set; }

		public void AddCartItem(CartItem item, int inStock)
		{
			if (item == null)
			{
				throw new ArgumentNullException();
			}

			if (this.GetItem(item.ISBN) != null)
			{
				throw new Exception();
			}

			if (item.Quantity < 0)
			{
				throw new ArgumentException();
			}
			
			item.RestQuantity = item.Quantity - inStock;

			item.DeliveredQuantity = item.Quantity - item.RestQuantity;

			if (this.CartItems == null)
			{
				this.CartItems = new List<CartItem>();
			}

			this.CartItems = this.CartItems.Concat(new CartItem[] { item });			
		}

		public void RemoveCartItem(string isbn)
		{
			if (this.CartItems == null)
			{
				throw new Exception();
			}

			if (this.GetItem(isbn) == null)
			{
				throw new Exception();
			}

			this.CartItems = this.CartItems.Where(i => i.ISBN != isbn);
		}

		CartItem GetItem(string isbn)
		{
			if (this.CartItems == null)
			{
				return null;
			}

			var item = this.CartItems.Where(i => i.ISBN == isbn);

			if (item.Count() == 0)
			{
				return null;
			}

			if (item.Count() > 1)
			{
				throw new Exception();
			}

			return item.First();
		}
	}
}
