using Microsoft.AspNetCore.Mvc;
using Parinasan_SportStore.Models;
using Parinasan_SportStore.Models.ViewModels;

namespace Parinasan_SportStore.Controllers

{
	public class HomeController : Controller
	{
		private IStoreRepository repository;
		public int pageSize = 4;
		public HomeController(IStoreRepository repository)
		{
			this.repository = repository;
		}

		public ViewResult Index(int productPage = 1)
			=> View(new ProductsListViewModel
			{
				Products = repository.Products
				.OrderBy(p => p.ProductID)
				.Skip((productPage - 1) * pageSize)
				.Take(pageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = pageSize,
					TotalItems = repository.Products.Count()
				}
			});
	}
}