using BookStore.App.BookContext.Application;
using BookStore.App.CartContext.Application;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Gui.Controllers
{
	public class ShoppingController : Controller
    {
		IBookService bookService;

		ICartService cartService;

		public ShoppingController(IBookService bookService, ICartService cartService)
		{
			this.bookService = bookService;
			this.cartService = cartService;
		}

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Search(string searchString)
        {
			try
			{
				var model = await bookService.GetBooksAsync(searchString);

				return Json(model, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return new HttpStatusCodeResult(500, e.Message);
			}
        }

        [HttpPost]
        public async Task Add(string isbn, int qty)
        {
			try
			{
				await cartService.AddItem(isbn, qty);
			}
			catch (Exception e)
			{
				Response.StatusCode = 500;
				Response.StatusDescription = e.Message;
			}
        }

        [HttpPost]
        public void Remove(string isbn)
        {
			try
			{
				cartService.RemoveItem(isbn);
			}
			catch (Exception e)
			{
				Response.StatusCode = 500;
				Response.StatusDescription = e.Message;
			}
		}

		public ActionResult Order()
		{
			try
			{
				var model = cartService.CheckOut();

				return Json(model, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return new HttpStatusCodeResult(500, e.Message);
			}			
		}
    }
}