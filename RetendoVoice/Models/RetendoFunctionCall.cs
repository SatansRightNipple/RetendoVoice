using ScriptRunner.OpenAi.Models.Completion;
using System.Text.Json.Nodes;

namespace RetendoVoice.Models
{
    public class RetendoFunctionCall
    {
        public string Name { get; set; }
        public Dictionary<string, JsonNode>? Arguments { get; set; }

        public RetendoFunctionCall(FunctionCall functionCall) 
        {
            Name = functionCall.Name;
            Arguments = functionCall.Arguments;
        }
    }
}
