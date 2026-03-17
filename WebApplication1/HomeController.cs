using Microsoft.AspNetCore.Mvc;

namespace ClientSide.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                ViewBag.Result = "Введіть рядок!";
                return View("Index");
            }

            string apiUrl = $"https://localhost:7217/String?value={System.Net.WebUtility.UrlEncode(input)}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                ViewBag.Result = $"Найдовше слово: {result}";
            }
            catch
            {
                ViewBag.Result = "Помилка підключення до сервера.";
            }

            return View("Index");
        }
    }
}