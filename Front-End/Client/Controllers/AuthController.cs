using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AuthController(IHttpClientFactory httpClient) : Controller
    {
        [HttpPost]
       public async Task<IActionResult> Login(LoginDto usr)
        {
			try
			{
                using var client = httpClient.CreateClient("api");
                var result = await client.PostAsJsonAsync("auth/login", usr);
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                var option = new CookieOptions()
                {
                    Expires = DateTimeOffset.Now.AddMinutes(1),
                };
                Response.Cookies.Append("Token", $"Bearer {content}", option);
                return Redirect("https://localhost:7224/guest");
            }
			catch (Exception)
			{
                return RedirectToAction("Login");
			}

        }
        [HttpGet]
        public IActionResult Login()
        {
			return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto usr)
        {
            using var client = httpClient.CreateClient("api");
            var result =await client.PostAsJsonAsync("auth/SignUp", usr);
            result.EnsureSuccessStatusCode();
            return RedirectToAction("Login");
        }
    }
}
