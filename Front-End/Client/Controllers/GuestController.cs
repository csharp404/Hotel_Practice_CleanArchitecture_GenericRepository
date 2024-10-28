using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Client.Controllers
{
    public class GuestController(IHttpClientFactory httpClientFactory) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["Token"];
            if (token == null) {
                return Redirect("https://localhost:7224/Auth/Login");
            }
           using var client  = httpClientFactory.CreateClient("api");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var response = await  client.GetAsync("Guest/GetAllGuests");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Guest>>(content);
            return View(data);
        }
    }
}
