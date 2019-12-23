// This sample requires C# 7.1 or later for async/await.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
// Install Newtonsoft.Json with NuGet
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TranslateTextSample
{
    /// <summary>
    /// The C# classes that represents the JSON returned by the Translator Text API.
    /// </summary>
    // public class TranslationResult
    // {
    //     public DetectedLanguage DetectedLanguage { get; set; }
    //     public TextResult SourceText { get; set; }
    //     public Translation[] Translations { get; set; }
    // }

    // public class DetectedLanguage
    // {
    //     public string Language { get; set; }
    //     public float Score { get; set; }
    // }

    // public class TextResult
    // {
    //     public string Text { get; set; }
    //     public string Script { get; set; }
    // }

    // public class Translation
    // {
    //     public string Text { get; set; }
    //     public TextResult Transliteration { get; set; }
    //     public string To { get; set; }
    //     public Alignment Alignment { get; set; }
    //     public SentenceLength SentLen { get; set; }
    // }

    // public class Alignment
    // {
    //     public string Proj { get; set; }
    // }

    // public class SentenceLength
    // {
    //     public int[] SrcSentLen { get; set; }
    //     public int[] TransSentLen { get; set; }
    // }

    class Program
    {
        private const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        // private static readonly string subscriptionKey = Environment.GetEnvironmentVariable(key_var);
        private static readonly string subscriptionKey = "49331ae9c7b548cdb0f97fb95b882d80";


        private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
        // private static readonly string endpoint = Environment.GetEnvironmentVariable(endpoint_var);
        private static readonly string endpoint = "https://api-nam.cognitive.microsofttranslator.com/";


        static Program()
        {
            if (null == subscriptionKey)
            {
                throw new Exception("Please set/export the environment variable: " + key_var);
            }
            if (null == endpoint)
            {
                throw new Exception("Please set/export the environment variable: " + endpoint_var);
            }
        }

        // Async call to the Translator Text API
        static public async Task TranslateTextRequest(string subscriptionKey, string endpoint, string route, string inputText)
        {
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Console.WriteLine(response.Content.ReadAsStringAsync().Result.GetType());

                var result = response.Content.ReadAsStringAsync().Result;
                var output = JsonConvert.DeserializeObject<object>(result);
                JArray jarray = output as JArray;
                // Console.WriteLine(jarray);
                JObject jobject = jarray.First as JObject;

                JProperty jproperty = jobject.First as JProperty;
                // JArray jarray2 = jproperty.First as JArray;
                JObject jobject2 = jproperty.First as JObject;
                JProperty jproperty2 = jobject2.First as JProperty;
                // JToken jtoken = jobject2.First as JToken;  
                JValue VALUE = jproperty2.First as JValue;         
                // Console.WriteLine(VALUE.Value);
                Console.WriteLine(VALUE.Value);


                // OR
                
                // get translation
                // JValue ALT_VALUE = jarray.First.Last.First.First.First.First as JValue;
                // Console.WriteLine(ALT_VALUE.Value);

                // get/detect language
                JValue language = jarray.First.First.First.First.First as JValue;
                Console.WriteLine(language.Value);

                // Read response as a string.
                // string result = await response.Content.ReadAsStringAsync();
                // TranslationResult[] deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);
                // // Console.WriteLine(result);
                // // Iterate over the deserialized results.
                // foreach (TranslationResult o in deserializedOutput)
                // {
                //     // Print the detected input languge and confidence score.
                //     Console.WriteLine("Detected input language: {0}\nConfidence score: {1}\n", o.DetectedLanguage.Language, o.DetectedLanguage.Score);
                //     // Iterate over the results and print each translation.
                //     foreach (Translation t in o.Translations)
                //     {
                //         Console.WriteLine("Translated to {0}: {1}", t.To, t.Text);
                //     }
                // }
            }
        }
        
        static void GetLanguages()
        {
          var langMap = new Dictionary<string, string>();
            string route = "/languages?api-version=3.0";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Set the method to GET
                request.Method = HttpMethod.Get;
                // Construct the full URI
                request.RequestUri = new Uri(endpoint + route);
                // Send request, get response
                var response = client.SendAsync(request).Result;
                // var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var deserialized = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                // Print the response
                // Console.WriteLine(deserialized.GetType());
                var translation = deserialized.translation;
                foreach(var langCode in translation)
                {
                  // var lang = l.First;
                  // Console.WriteLine(langCode.Name);
                  foreach(var langName in langCode)
                  {
                    // Console.WriteLine(langName.name);
                    // create map format
                    // <langName, langCode>
                    langMap.Add(langName.name.ToString().ToLower(), langCode.Name.ToString().ToLower());
                  }
                }
            }
          // foreach(var s in langMap)
          // {
          //   Console.WriteLine(s.Key);
          //   Console.WriteLine(s.Value);
          // }
          // if (langMap.ContainsKey("English"))
          // {
          //     Console.WriteLine(langMap["English"]);
          // }
          // Console.WriteLine(langMap["jfieo"]);
        }

        static async Task Main(string[] args)
        {
            // This is our main function.
            // Output languages are defined in the route.
            // For a complete list of options, see API reference.
            // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
            // string route = "/translate?api-version=3.0&to=de&to=it&to=ja&to=es&to=en";
            string route = "/translate?api-version=3.0&to=es";


            // get languages
            // GetLanguages();

            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.
            Console.Write("Type the phrase you'd like to translate? ");
            string textToTranslate = Console.ReadLine();
            await TranslateTextRequest(subscriptionKey, endpoint, route, textToTranslate);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}