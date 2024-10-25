using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using WEBMandiri.Models;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    public List<User> Users { get; set; } = new List<User>();

    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000/");
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Users = await _httpClient.GetFromJsonAsync<List<User>>("api/Users");
        return Page();
    }
}
