using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEBMandiri.Models;

namespace WEBMandiri.pages
{

     
        public class CreateModel : PageModel
        {
            private readonly UserService _userService;

            public CreateModel(UserService userService)
            {
                _userService = userService;
            }

            [BindProperty]
            public User User { get; set; }

            public void OnGet()
            {
           
            }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page(); 
                }

                await _userService.CreateUserAsync(User); 
                return RedirectToPage("/Index"); 
            }
        }
     
}
