using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.App.BookContext.Model;
using BookStore.App.BookContext.Repository;

namespace BookStore.App.BookContext.Application
{
	public class BookService : IBookService
	{
        IBookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }

        internal BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync(string searchString)
        {
			if (string.IsNullOrEmpty(searchString))
			{
				throw new ArgumentException();
			}

			IEnumerable<Book> books = null;

			try
			{
				books = await bookRepository.GetBooksAsync(searchString);
			}
			catch (Exception)
			{
				throw new Exception();
			}

			return Infrastructure.MapService.MapToList<BookDTO, Book>(books);
		}

        public async Task<BookDTO> GetBookByIsbnAsync(string isbn)
        {
			if (string.IsNullOrEmpty(isbn))
			{
				throw new ArgumentException();
			}

			Book book = null;

			try
			{
				book = await bookRepository.GetBookByIsbnAsync(isbn);
			}
			catch (Exception)
			{
				throw new Exception();
			}

			return Infrastructure.MapService.MapTo<BookDTO, Book>(book);
        }
    }
}