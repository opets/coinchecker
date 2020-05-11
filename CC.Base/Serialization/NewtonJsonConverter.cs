using Newtonsoft.Json;

namespace CC.Base.Serialization
{
    internal sealed class NewtonJsonConverter : IJsonConverter
    {
        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
