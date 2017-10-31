using System.Threading.Tasks;

namespace BookStore.App.CartContext.Application
{
	public interface ICartService
	{
		Task AddItem(string isbn, int quantity);

		void RemoveItem(string isbn);

		CartDTO CheckOut();
	}
}
