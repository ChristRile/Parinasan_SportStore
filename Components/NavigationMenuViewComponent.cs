using Microsoft.AspNetCore.Mvc;

namespace Parinasan_SportStore.Components
{
	public class NavigationMenuViewComponent : ViewComponent
	{
		public string Invoke()
		{
			return "Hello from the Nav View Component";
		}
	}
}