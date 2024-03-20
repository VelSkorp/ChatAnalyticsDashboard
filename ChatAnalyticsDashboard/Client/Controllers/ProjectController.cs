using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Client
{
	public class ProjectController : Controller
	{
		private readonly HttpClient _httpClient;

		public ProjectController(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(configuration["ServerApiURL"]);
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Project()
		{
			return View();
		}

        public async Task<IActionResult> TableAsync()
		{
			JObject totalChatsData;
			JObject durationData;
			JObject ratingsData;
			JObject responseTimeData;
			JObject tagsData;

			try
			{
				totalChatsData = await GetDataFromAPIAsync("total-chats-report");
				durationData = await GetDataFromAPIAsync("duration-report");
				ratingsData = await GetDataFromAPIAsync("ratings-report");
				responseTimeData = await GetDataFromAPIAsync("response-time-report");
				tagsData = await GetDataFromAPIAsync("tags-report");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", new { message = ex.Message });
			}

			ViewBag.TotalChats = totalChatsData;
			ViewBag.Duration = durationData;
			ViewBag.Ratings = ratingsData;
			ViewBag.ResponseTime = responseTimeData;
			ViewBag.Tags = tagsData;

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(string message = "An error occurred while processing your request.")
		{
			return View(new ErrorViewModel { ErrorMessage = message });
		}

		private async Task<JObject> GetDataFromAPIAsync(string reportName)
		{
			var response = await _httpClient.GetAsync(reportName);

			if (response.IsSuccessStatusCode)
			{
				return JObject.Parse(await response.Content.ReadAsStringAsync());
			}

			throw new Exception($"Recived {response.StatusCode} server status code");
		}
	}
}