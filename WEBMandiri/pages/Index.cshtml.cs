using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEBMandiri.Models;

namespace WEBMandiri.pages
{
    public class UserViewModel : PageModel
    {
        private readonly UserService _userService;

        public UserViewModel(UserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; } = new List<User>();

        public async Task OnGetAsync()
        {
            try
            {
                Users = await _userService.GetUsersAsync();
            }
            catch (Exception ex)
            {
                Users = null;
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteUserAsync(id);

            return RedirectToPage();
        }
    }
}
