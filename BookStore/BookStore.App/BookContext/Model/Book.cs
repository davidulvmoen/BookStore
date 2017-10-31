namespace BookStore.App.BookContext.Model
{
	class Book
	{
		public string ISBN { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public decimal Price { get; set; }

		public int InStock { get; set; }

		public string GetISBN()
		{
			return this.ISBN;
		}

        public int GetInStock()
        {
            return this.InStock;
        }

        public bool HasTitleOrAuthor(string find)
        {
			if (!string.IsNullOrEmpty(this.Title))
			{
				if (this.Title.Contains(find))
				{
					return true;
				}
			}

			if (!string.IsNullOrEmpty(this.Author))
			{
				if (this.Author.Contains(find))
				{
					return true;
				}
			}

            return false;
        }
	}
}
