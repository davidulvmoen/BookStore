using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.App.BookContext.Application
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(string searchString);

		Task<BookDTO> GetBookByIsbnAsync(string isbn);
    }
}
