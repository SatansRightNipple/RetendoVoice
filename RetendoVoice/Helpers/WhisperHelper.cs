using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RetendoVoice.Models;
using System.Net.Http;

namespace RetendoVoice.Helpers
{
    public class WhisperHelper
    {
        public static WhisperHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WhisperHelper();
                return _instance;
            }
        }

        private static WhisperHelper? _instance;

        private HttpClient http;

        public WhisperHelper()
        {
            http = CreateHttpClient();
        }

        public async Task<SpeechToTextResponse> SpeechToText(byte[] audioBytes)
        {
            string whisperUrl = "https://api.openai.com/v1/audio/transcriptions";

            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(audioBytes), "file", "audio.wav");
                content.Add(new StringContent("whisper-1"), "model");

                HttpResponseMessage response = await http.PostAsync(whisperUrl, content);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) 
                    throw new OpenAiException(json, response.StatusCode);

                SpeechToTextResponse? result = SpeechToTextResponse.FromJson(json);

                if (result == null)
                    throw new Exception("WTH Json is it null?!");

                return result;
            }
        }

        public static byte[] IFormFileToByte(IFormFile formFile)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient result = new HttpClient();
            string? apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY");

            if (apiKey == null)
                throw new ArgumentNullException("missing open AI API key");

            result.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            return result;
        }
    }
}
