using System.Text.Json.Serialization;

namespace AIAssistantAPI.Models
{
    public class GeminiRequest(string text)
	{
		[JsonPropertyName("contents")]
		public List<Content> Contents { get; set; } =
			[
				new([new(text)])
			];
    }
}
