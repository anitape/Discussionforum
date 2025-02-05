using Infrastructure.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiscussionForum.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
		public IEnumerable<Topic> objTopicList;

		private readonly UnitOfWork _unitOfWork;

		public IndexModel(ILogger<IndexModel> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
			_unitOfWork = unitOfWork;
		}


		public IActionResult OnGet()
		{
			objTopicList = _unitOfWork.Topic.GetAll(null, t => t.TopicId, null);
			return Page();
		}
	}
}