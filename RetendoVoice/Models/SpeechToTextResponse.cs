using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetendoVoice.Models
{
    public class SpeechToTextResponse
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        public static SpeechToTextResponse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<SpeechToTextResponse>(json);
        }
    }
}
