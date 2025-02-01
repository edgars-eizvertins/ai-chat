using System.Text.Json.Serialization;

namespace AIAssistantAPI.Models
{
	public class Content(List<Part> parts)
	{
		[JsonPropertyName("parts")]
		public List<Part> Parts { get; set; } = parts;

		[JsonPropertyName("role")]
		public string? Role { get; set; }
	}

	public class Part(string text)
	{
		[JsonPropertyName("text")]
		public string Text { get; set; } = text;
	}
}