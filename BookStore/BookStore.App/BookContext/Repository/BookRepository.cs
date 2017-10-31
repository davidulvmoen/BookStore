using BookStore.App.BookContext.Model;
using BookStore.App.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.App.BookContext.Repository
{
	class BookRepository : IBookRepository
	{
		HttpService httpService;

		public BookRepository()
		{
			this.httpService = new HttpService();
		}

		public async Task<IEnumerable<Book>> GetBooksAsync(string searchString)
		{
			var books = await this.GetAllBooksAsync();

			if (books == null)
			{
				return null;
			}

			// storage logic... should probably be tested...
			return books.Where(b => b.HasTitleOrAuthor(searchString));
		}

		public async Task<Book> GetBookByIsbnAsync(string isbn)
		{
			var books = await this.GetAllBooksAsync();

			if (books == null)
			{
				return null;
			}

			// storage logic... should probably be tested...
			foreach (var item in books)
			{
				if (item.GetISBN() == isbn)
				{
					return item;
				}
			}

			return null;
		}

		async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			var raw = await this.httpService.Get("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");

			if (string.IsNullOrEmpty(raw))
			{
				throw new Exception();
			}

			var dataBooks = Infrastructure.MapService.FromJSON<DataBooks>(raw);

			var books = Infrastructure.MapService.MapToList<Book, DataBook>(dataBooks.books);

			// should not be here...
			int i = 0;

			foreach (var item in books)
			{
				item.ISBN = i.ToString();
				i++;
			}

			return await Task.FromResult(books);
		}
	}
}