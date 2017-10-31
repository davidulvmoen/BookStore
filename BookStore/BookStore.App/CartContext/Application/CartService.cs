using BookStore.App.BookContext.Application;
using BookStore.App.CartContext.Model;
using BookStore.App.CartContext.Repository;
using System;
using System.Threading.Tasks;

namespace BookStore.App.CartContext.Application
{
    public class CartService : ICartService
	{
		ICartRepository cartRepository;
		IBookService bookService;

		public CartService()
		{
			this.cartRepository = new CartRepository();
			this.bookService = new BookService();
		}

		internal CartService(ICartRepository cartRepository, IBookService bookService)
		{
			this.cartRepository = cartRepository;
			this.bookService = bookService;
		}

		public async Task AddItem(string isbn, int quantity)
		{
            if (string.IsNullOrEmpty(isbn))
            {
                throw new Exception();
            }

			BookDTO book = null;

			try
			{
				book = await bookService.GetBookByIsbnAsync(isbn);
			}
			catch (Exception)
			{
				throw new Exception();
			}

			if (book == null)
			{
				throw new Exception();
			}

			Cart cart = null;
			bool create = false;

			try
			{
				cart = cartRepository.Read();
			}
			catch (Exception)
			{
				throw new Exception();
			}

			if (cart == null)
			{
				cart = new Cart();
				create = true;
			}

			var item = new CartItem();
            item.ISBN = isbn;
            item.Quantity = quantity;
            item.Title = book.Title;
            item.Price = book.Price;

			cart.AddCartItem(item, book.InStock);

			try
			{
				if (create)
				{
					cartRepository.Create(cart);
				}
				else
				{
					cartRepository.Update(cart);
				}
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		public void RemoveItem(string isbn)
		{
			if (string.IsNullOrEmpty(isbn))
			{
				throw new Exception();
			}

			Cart cart = null;

			try
			{
				cart = cartRepository.Read();
			}
			catch (Exception)
			{
				throw new Exception();
			}

			if (cart == null)
			{
				throw new Exception();
			}

			cart.RemoveCartItem(isbn);

			try
			{
				cartRepository.Update(cart);
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		public CartDTO CheckOut()
		{
			Cart cart = null;

			try
			{
				cart = cartRepository.Read();
			}
			catch (Exception)
			{
				throw new Exception();
			}

			if (cart == null)
			{
				throw new Exception();
			}

			var cartDTO = new CartDTO();
			cartDTO.Total = cart.Total;
			cartDTO.CartItems = Infrastructure.MapService.MapToList<CartItemDTO, CartItem>(cart.CartItems);

			try
			{
				cartRepository.Delete();
			}
			catch (Exception)
			{
				throw new Exception();
			}

			return cartDTO;
		}
	}
}