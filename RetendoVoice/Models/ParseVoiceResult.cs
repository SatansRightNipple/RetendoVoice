using ScriptRunner.OpenAi.Models.Completion;

namespace RetendoVoice.Models
{
    public class ParseVoiceResult
    {
        public List<RetendoFunctionCall>? ListOfFunctions { get; set; }
        public string RawText { get; set; }

        public ParseVoiceResult(List<FunctionCall>? listOfFunctions, string rawText)
        {
            ListOfFunctions = new List<RetendoFunctionCall>();

            if (listOfFunctions != null)
                foreach (FunctionCall function in listOfFunctions) 
                    ListOfFunctions.Add(new RetendoFunctionCall(function));

            RawText = rawText;
        }
    }
}
