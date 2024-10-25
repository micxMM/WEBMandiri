using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WEBMandiri.Models;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000/");
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("api/Users");
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"api/Users/{id}");
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Users/{user.Id}", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }

    public async Task DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Users/{id}");
        response.EnsureSuccessStatusCode();
    }
}
