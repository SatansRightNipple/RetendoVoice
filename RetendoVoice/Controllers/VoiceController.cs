using BrunoZell.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using RetendoVoice.Helpers;
using RetendoVoice.Models;
using ScriptRunner.OpenAi;
using ScriptRunner.OpenAi.Models.Completion;

namespace RetendoVoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        [HttpPost]
        public async Task<ParseVoiceResult> ParseVoice(IFormFile file, [ModelBinder(BinderType = typeof(JsonModelBinder))] RetendoFunctionCollection functionsToCallCollection)
        {
            byte[] fileBytes = WhisperHelper.IFormFileToByte(file);
            SpeechToTextResponse userSpeech = await WhisperHelper.Instance.SpeechToText(fileBytes);

            string? apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY");

            if (apiKey == null)
                throw new ArgumentNullException("Missing open AI API key");

            OpenAiApi openAi = new OpenAiApi(apiKey);
            CompletionParameter completionParameter = new CompletionParameter(Model.Default);

            foreach (RetendoFunction functionToCall in functionsToCallCollection.List)
            {
                completionParameter.AddFunction(FunctionConverter.Convert(functionToCall));
            }

            if (userSpeech.Text == null) 
                throw new Exception("The text is null for some reason");

            completionParameter.AddUserMessage(userSpeech.Text);
            CompletionResult result = await openAi.CompleteAsync(completionParameter);

            return new ParseVoiceResult(result.GetFunctionCalls(), userSpeech.Text);
        }
    }
}
