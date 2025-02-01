using Microsoft.AspNetCore.Mvc;
using AIAssistantAPI.Services;

namespace AIAssistantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly GeminiService geminiService;

        public AIController(GeminiService geminiService)
        {
            this.geminiService = geminiService;
        }

        // POST api/ai/ask
        [HttpPost("ask")]
        public async Task<ActionResult<string>> AskAI([FromBody] AIRequest request)
        {
            if (string.IsNullOrEmpty(request?.Input))
            {
                return BadRequest("Input cannot be empty");
            }

            try
            {
                var response = await geminiService.GetAIResponseAsync(request.Input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error contacting Gemini API: {ex.Message}");
            }
        }
    }

	public class AIRequest
    {
        public string Input { get; set; } = string.Empty;
    }
}
