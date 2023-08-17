using System.Collections;
using System.Text.Json.Serialization;

namespace RetendoVoice.Models
{
    public class RetendoFunctionCollection
    {
        [JsonPropertyName("list")]
        public List<RetendoFunction> List { get; set; }

        [JsonConstructor]
        public RetendoFunctionCollection(List<RetendoFunction> list)
        {
            this.List = list;
        }
    }
}
