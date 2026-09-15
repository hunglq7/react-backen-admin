using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("line")]
        [AllowAnonymous]
        public IActionResult GetLineData([FromBody] LineRequest request)
        {
            // Mock data for line chart based on range
            var data = new List<string>();

            if (request.Range == "week")
            {
                // Sample data for a week (7 days)
                data = new List<string> { "120", "132", "101", "134", "90", "230", "210" };
            }
            else if (request.Range == "month")
            {
                // Sample data for a month (30 days)
                data = new List<string>();
                for (int i = 1; i <= 30; i++)
                {
                    data.Add((100 + i * 2).ToString());
                }
            }
            else if (request.Range == "year")
            {
                // Sample data for a year (12 months)
                data = new List<string> { "2000", "2500", "1800", "3000", "2800", "3500", "3200", "3800", "3600", "4000", "4200", "4500" };
            }
            else
            {
                // Default week data
                data = new List<string> { "120", "132", "101", "134", "90", "230", "210" };
            }

            return Ok(new { result = data });
        }

        [HttpGet("pie")]
        [AllowAnonymous]
        public IActionResult GetPieData([FromQuery] string by = "category")
        {
            // Mock data for pie chart
            var data = new List<object>();

            if (by == "category")
            {
                data = new List<object>
                {
                    new { value = 335, code = "Category A" },
                    new { value = 310, code = "Category B" },
                    new { value = 234, code = "Category C" },
                    new { value = 135, code = "Category D" },
                    new { value = 1548, code = "Category E" }
                };
            }
            else
            {
                data = new List<object>
                {
                    new { value = 400, code = "Type X" },
                    new { value = 300, code = "Type Y" },
                    new { value = 200, code = "Type Z" }
                };
            }

            return Ok(new { result = data });
        }
    }

    public class LineRequest
    {
        public string Range { get; set; } = "week";
    }
}