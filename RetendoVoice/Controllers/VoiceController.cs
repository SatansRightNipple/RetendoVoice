using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetendoVoice.Helpers;
using RetendoVoice.Models;
using Sakur.WebApiUtilities.Models;

namespace RetendoVoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        [HttpPost]
        public async Task<SpeechToTextResponse> GetText(IFormFile file)
        {
            byte[] fileBytes = WhisperHelper.IFormFileToByte(file);
            SpeechToTextResponse text = await WhisperHelper.Instance.SpeechToText(fileBytes);

            return text;
        }
    }
}
