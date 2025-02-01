using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using AIAssistantAPI.Models;

namespace AIAssistantAPI.Services
{
    public class GeminiService
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public GeminiService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            apiKey = configuration["Gemini:ApiKey"]; // Assuming you add Gemini API key in appsettings.json
        }

        public async Task<GeminiResponse?> GetAIResponseAsync(string input)
        {
			var inputContent = new GeminiRequest(input);

            // Prepare the request
            var requestContent = new StringContent(
                JsonSerializer.Serialize(inputContent),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            // Replace with actual Gemini API URL
            var response = await httpClient.PostAsync(
				"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=" + apiKey, requestContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error from Gemini API: " + response.StatusCode);
            }

            // Read and return the response body
            var responseBody = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<GeminiResponse>(responseBody);
            return result;
        }
    }
}
