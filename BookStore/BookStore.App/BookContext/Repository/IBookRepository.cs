using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.App.BookContext.Model;

namespace BookStore.App.BookContext.Repository
{
    interface IBookRepository
    {
		Task<IEnumerable<Book>> GetBooksAsync(string searchString);

		Task<Book> GetBookByIsbnAsync(string isbn);
	}
}
