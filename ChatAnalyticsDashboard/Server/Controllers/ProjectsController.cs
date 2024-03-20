using Microsoft.AspNetCore.Mvc;

namespace Server
{
	[ApiController]
	[Route("api/Get")]
	public class ProjectsController : ControllerBase
	{
		[HttpGet("total-chats-report")]
		public IActionResult GetTotalChatsReport()
		{
			return Ok(DataReader.ReadData("TotalChats.json"));
		}

		[HttpGet("duration-report")]
		public IActionResult GetDurationReport()
		{
			return Ok(DataReader.ReadData("Duration.json"));
		}

		[HttpGet("ratings-report")]
		public IActionResult GetRatingsReport()
		{
			return Ok(DataReader.ReadData("Ratings.json"));
		}

		[HttpGet("response-time-report")]
		public IActionResult GetResponseTimeReport()
		{
			return Ok(DataReader.ReadData("ResponseTime.json"));
		}

		[HttpGet("tags-report")]
		public IActionResult GetTagsReport()
		{
			return Ok(DataReader.ReadData("Tags.json"));
		}
	}
}