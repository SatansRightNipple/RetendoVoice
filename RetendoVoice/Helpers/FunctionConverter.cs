using RetendoVoice.Models;
using ScriptRunner.OpenAi.Models.Completion;
using ScriptRunner.OpenAi.Models.Completion.Parameters;

namespace RetendoVoice.Helpers
{
    public class FunctionConverter
    {
        public static Function Convert(RetendoFunction functionToCall)
        {
            Function function = new Function(functionToCall.Name, functionToCall.Description);

            foreach (Parameter parameter in functionToCall.Parameters)
                function.AddParameter(new OpenAi.Models.Completion.Parameters.Parameter(parameter.Name, parameter.Type, parameter.Description), parameter.Required);

            return function;
        }
    }
}
