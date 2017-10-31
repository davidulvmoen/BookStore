namespace BookStore.App.BookContext.Application
{
	public class BookDTO
    {
		public string ISBN { get; set; }

		public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }
    }
}
