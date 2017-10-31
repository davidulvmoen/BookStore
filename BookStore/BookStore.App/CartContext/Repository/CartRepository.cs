using BookStore.App.CartContext.Model;

namespace BookStore.App.CartContext.Repository
{
	class CartRepository : ICartRepository
	{
		static Cart storage;

		public void Create(Cart cart)
		{
			storage = cart;
		}

		public Cart Read()
		{			
			return storage;
		}

		public void Update(Cart cart)
		{
			storage = cart;
		}

		public void Delete()
		{
			storage = null;
		}
	}
}
