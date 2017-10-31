using BookStore.App.BookContext.Application;
using BookStore.App.CartContext.Application;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.Gui
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			var container = new Container();
			container.Register<IBookService, BookService>(lifestyle: Lifestyle.Singleton);
			container.Register<ICartService, CartService>(lifestyle: Lifestyle.Singleton);
			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}
    }
}
