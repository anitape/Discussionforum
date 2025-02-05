using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace DiscussionForum.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        [BindProperty]
        public Register RegisterViewModel    { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
              
            };
          var identityResult =  await  userManager.CreateAsync(user, RegisterViewModel.Password);

            if(identityResult.Succeeded)
            {
                var addRolesResult = await userManager.AddToRoleAsync(user, "Normie");
                if(addRolesResult.Succeeded)
                {
                    return Page();
                }


            }
            
                return NotFound();
            
            
                
            
        }
    }
}
