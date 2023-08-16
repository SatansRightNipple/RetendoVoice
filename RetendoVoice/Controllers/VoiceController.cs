using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetendoVoice.Helpers;
using Sakur.WebApiUtilities.Models;

namespace RetendoVoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        [HttpPost]
        public async Task<ObjectResult> GetText(IFormFile file)
        {
            byte[] fileBytes = WhisperHelper.IFormFileToByte(file);
            string text = await WhisperHelper.Instance.SpeechToText(fileBytes);

            await Task.CompletedTask;
            return new ApiResponse(1);
        }


    }
}
