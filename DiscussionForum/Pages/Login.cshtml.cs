using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiscussionForum.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
           var signInResult = await signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, false,false);
            if (signInResult.Succeeded)
            {
                return RedirectToPage("Index");
            }else
            {
                return Page();
            }
        }
    }
}
