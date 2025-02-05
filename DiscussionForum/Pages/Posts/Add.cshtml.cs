using DataAccess.Data;
using Infrastructure.Models;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DiscussionForum.Pages.Posts
{

    
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

         
        

        [BindProperty]
        public PostTopic PostTopicRequest{ get; set; }

        public AddModel(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
          

        }


        public void OnGet()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        }

        public void OnPost() {

            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var topicPost = new Topic()
            {
                
                Title = PostTopicRequest.Title,
                Description = PostTopicRequest.Description,
                //AuthorUserId = "2c43e67b-4e7e-4061-a1b0-773190f08ecb",
                AuthorUserId = claim.Value

                
            

        };
            applicationDbContext.Topics.Add(topicPost);
            applicationDbContext.SaveChanges();
        
        }
    }
}
