using Newtonsoft.Json;

namespace CC.Base.Serialization
{
    public class UnsuccessfulResponseException : System.Exception
    {
        public string ErrorCode { get; }
        public string Json { get; }

        public UnsuccessfulResponseException(string errorCode, string json, string castToType)
            : base($"UnsuccessfulResponse. Error Code:{errorCode}, Cast to type:{castToType} JSON:{json}")
        {
            ErrorCode = errorCode;
            Json = json;
        }
    }
}
