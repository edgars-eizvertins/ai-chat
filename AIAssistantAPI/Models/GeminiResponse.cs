using System.Text.Json.Serialization;

namespace AIAssistantAPI.Models
{
	public class GeminiResponse
	{
		[JsonPropertyName("candidates")]
		public List<Candidate>? Candidates { get; set; }

		[JsonPropertyName("usageMetadata")]
		public UsageMetadata? UsageMetadata { get; set; }

		[JsonPropertyName("modelVersion")]
		public string? ModelVersion { get; set; }
	}

	public class Candidate
	{
		[JsonPropertyName("content")]
		public Content? Content { get; set; }

		[JsonPropertyName("finishReason")]
		public string? FinishReason { get; set; }

		[JsonPropertyName("avgLogprobs")]
		public double AvgLogprobs { get; set; }
	}

	public class UsageMetadata
	{
		[JsonPropertyName("promptTokenCount")]
		public int PromptTokenCount { get; set; }

		[JsonPropertyName("candidatesTokenCount")]
		public int CandidatesTokenCount { get; set; }

		[JsonPropertyName("totalTokenCount")]
		public int TotalTokenCount { get; set; }

		[JsonPropertyName("promptTokensDetails")]
		public List<TokenDetail>? PromptTokensDetails { get; set; }

		[JsonPropertyName("candidatesTokensDetails")]
		public List<TokenDetail>? CandidatesTokensDetails { get; set; }
	}

	public class TokenDetail
	{
		[JsonPropertyName("modality")]
		public string? Modality { get; set; }

		[JsonPropertyName("tokenCount")]
		public int TokenCount { get; set; }
	}
}
