using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure;

namespace DiscussionForum.Pages.Topics
{
	public class IndexModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;

		public IEnumerable<Topic> objTopicList;

		public IndexModel(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			objTopicList = new List<Topic>();
		}

		public IActionResult OnGet()
		{
			//There are five major sets of IActionResult Types the can be returned
			//1. Server Status Code Results
			//2. Server Status Code and Object Results
			//3. Redirect (to another webpage) Results
			//4. File Results
			//5. Content Results (like another Razor Web Page)

			objTopicList = _unitOfWork.Topic.GetAll();
			return Page(); //render Page

		}
	}
}