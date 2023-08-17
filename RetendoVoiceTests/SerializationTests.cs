using RetendoVoice.Models;
using System.Text.Json;

namespace RetendoVoiceTests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void DeserializeFromJson()
        {
            string json = "{\r\n  \"list\": [\r\n    {\r\n      \"name\": \"AddNumbers\",\r\n      \"description\": \"Add two numbers together.\",\r\n      \"parameters\": [\r\n        {\r\n          \"name\": \"num1\",\r\n          \"type\": \"int\",\r\n          \"description\": \"First number.\",\r\n          \"required\": true\r\n        },\r\n        {\r\n          \"name\": \"num2\",\r\n          \"type\": \"int\",\r\n          \"description\": \"Second number.\",\r\n          \"required\": false\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"GetStringLength\",\r\n      \"description\": \"Get the length of a string.\",\r\n      \"parameters\": [\r\n        {\r\n          \"name\": \"input\",\r\n          \"type\": \"string\",\r\n          \"description\": \"Input string.\",\r\n          \"required\": true\r\n        },\r\n        {\r\n          \"name\": \"includeSpaces\",\r\n          \"type\": \"bool\",\r\n          \"description\": \"Flag to include spaces in length calculation.\",\r\n          \"required\": false\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"IsEvenNumber\",\r\n      \"description\": \"Check if a number is even.\",\r\n      \"parameters\": [\r\n        {\r\n          \"name\": \"number\",\r\n          \"type\": \"int\",\r\n          \"description\": \"Number to check.\",\r\n          \"required\": true\r\n        },\r\n        {\r\n          \"name\": \"allowNegative\",\r\n          \"type\": \"bool\",\r\n          \"description\": \"Flag to allow negative numbers.\",\r\n          \"required\": false\r\n        }\r\n      ]\r\n    }\r\n  ]\r\n}\r\n";
            RetendoFunctionCollection? functions = JsonSerializer.Deserialize<RetendoFunctionCollection>(json);
            Assert.IsNotNull(functions);
        }
    }
}