namespace CC.Base.Rest
{
    internal sealed partial class WebClient
    {
        private class ResponseObject<T>
        {
            public bool Success { get; set; }
            public T Result { get; set; }
            public ResponseObjectError Error { get; set; }

            public class ResponseObjectError
            {
                public string ErrorCode { get; set; }
            }

        }
    }
}
