using Newtonsoft.Json;

namespace CLA_Administration_Web.Helpers.API
{
    public class APIResponseParserHelper
    {
        public static T ParseJsonToObject<T>(string json, bool isOneItem = false)
        {
            try
            {
                T result;

                var unescapedJson = JsonConvert.DeserializeObject<string>(json);
                if (isOneItem)
                {
                    var parsedObject = JsonConvert.DeserializeObject<List<T>>(unescapedJson);
                    
                    result = parsedObject.FirstOrDefault();
                }
                else
                {
                    result = JsonConvert.DeserializeObject<T>(unescapedJson);
                }
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
