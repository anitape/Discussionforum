using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DiscussionForum.Pages
{
	public class TopicDetailsModel : PageModel

	{
		private readonly ILogger<IndexModel> _logger;
		private readonly UnitOfWork _unitOfWork;
		[BindProperty]
		public Topic objTopic { get; set; }

		public IEnumerable<Reply> objReplyList;

		[BindProperty]
		public Reply objReply { get; set; }
		public string reply { get; set; }
		public string replyUserId { get; set; }

		public TopicDetailsModel(ILogger<IndexModel> logger, UnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public IActionResult OnGet(int? topicId)
		{
			//check to see if user logged on
			//var claimsIdentity = User.Identity as ClaimsIdentity;
			//var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			//TempData["UserLoggedIn"] = claim;
			objTopic = _unitOfWork.Topic.Get(p => p.TopicId == topicId);
			objReplyList = _unitOfWork.Reply.GetAll(r => r.TopicId == topicId);
			//objReplyList = _unitOfWork.Reply.Get(r => r.TopicId == topicId);

			return Page();
		}

		public IActionResult OnPost(string? reply, string? replyUserId)
		{
			//if (!ModelState.IsValid)
			//{
			//	return Page();
			//}

			objReply = new Reply()
			{
				Content = reply,
				ReplyUserId = replyUserId,
				TopicId = objTopic.TopicId,
			};

			_unitOfWork.Reply.Add(objReply);

			_unitOfWork.Commit();

			return RedirectToPage("TopicDetails", new { topicid = objTopic.TopicId });
		}
	}
}