using BookStore.App.CartContext.Model;

namespace BookStore.App.CartContext.Repository
{
	interface ICartRepository
	{
		void Create(Cart cart);

		Cart Read();

		void Update(Cart cart);

		void Delete();
	}
}
