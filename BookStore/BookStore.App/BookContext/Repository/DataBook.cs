namespace BookStore.App.BookContext.Repository
{

	class DataBooks
	{
		public DataBook[] books { get; set; }
	}

	class DataBook
	{
		public string title { get; set; }
		public string author { get; set; }
		public float price { get; set; }
		public int inStock { get; set; }
	}

}
