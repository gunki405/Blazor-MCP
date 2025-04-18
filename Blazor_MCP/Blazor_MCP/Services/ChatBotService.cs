using System.Text.Json;
using System.Text;
using System.Globalization;
using Blazor_MCP.DataModel;

namespace Blazor_MCP.Services
{
    public class ChatBotService
    {
        private readonly HttpClient _http;

        public ChatBotService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ChatResult> SendMessageAsync(string message, string Lang)
        {
            try
            {
                var requestBody = new
                {
                    language = Lang,
                    message = message
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _http.PostAsync("default/ai-chat-bot-test", content); // 경로가 있다면 뒤에 추가
                response.EnsureSuccessStatusCode();

                var resultString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ChatResponse>(resultString);

                ChatResult returnValue = new ChatResult
                {
                    Result = result?.Result ?? "응답 없음",
                    Emotion = result?.Emotion ?? "중립",
                };

                return returnValue;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP 요청 오류: {ex.Message}");
                throw new Exception($"HTTP 요청 오류: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"일반 오류: {ex.Message}");
                throw new Exception($"일반 오류: {ex.Message}");
            }
        }

        public class ChatResponse
        {
            public string Result { get; set; }
            public string Emotion { get; set; }
            public string Error { get; set; }
        }
    }
}
