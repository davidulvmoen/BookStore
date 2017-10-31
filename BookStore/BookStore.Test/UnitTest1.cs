using BookStore.App.BookContext.Application;
using BookStore.App.CartContext.Application;
using BookStore.App.CartContext.Model;
using BookStore.App.CartContext.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task TestCartInvalidItem()
		{
			BookDTO book = new BookDTO();
			book.ISBN = "123";
			book.InStock = 55;

			var mock = new Mock<IBookService>();
			mock.Setup(s => s.GetBookByIsbnAsync("123")).Returns(Task.FromResult(book));

			var cartService = new CartService(new CartRepository(), mock.Object);

			await cartService.AddItem("123", -22);
		}

		[TestMethod]
		public async Task TestCartValidItem()
		{
			BookDTO book = new BookDTO();
			book.ISBN = "123";
			book.InStock = 55;

			var mock = new Mock<IBookService>();
			mock.Setup(s => s.GetBookByIsbnAsync("123")).Returns(Task.FromResult(book));

			var cartService = new CartService(new CartRepository(), mock.Object);

			await cartService.AddItem("123", 22);
		}

		[TestMethod]
		public void TestCartCheckout()
		{
			var cart = new Cart();

			var item = new CartItem();
			item.ISBN = "11";
			item.Price = 100;
			item.Quantity = 10;
			cart.AddCartItem(item, 5);

			Assert.IsTrue(cart.Total == 1000);

			Assert.IsTrue(cart.CartItems.First().RestQuantity == 5);

			item = new CartItem();
			item.ISBN = "22";
			item.Price = 5;
			item.Quantity = 1;
			cart.AddCartItem(item, 1);

			Assert.IsTrue(cart.Total == 1005);

			Assert.IsTrue(cart.CartItems.Where(i=>i.ISBN == "22").First().DeliveredQuantity == 1);
		}
	}
}