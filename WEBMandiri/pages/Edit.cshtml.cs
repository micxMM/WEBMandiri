using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEBMandiri.Models;

namespace WEBMandiri.pages
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task OnGetAsync(int id)
        {
            User = await _userService.GetUserByIdAsync(id);
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userService.UpdateUserAsync(User);
            return RedirectToPage("/Index");
        }
    }
}
