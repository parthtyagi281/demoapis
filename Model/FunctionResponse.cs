namespace DemoApi.Model
{
    public class FunctionResponse<T>
    {
        public string status { get; set; }
        public T result { get; set; }
        public string Message { get; set; }
        
        public object result2 { get; set; }
        public Exception Ex { get; set; }
        public FunctionResponse()
        {
            status = "error";
            Message = "Response not set";

        }
    }

    public class FunctionResponse
    {
        public string status { get; set; }
        public object result { get; set; }
        //public string RefNo { get; set; }
        // public string Location { get; set; }
        public Exception Ex { get; set; }
        public object result2 { get; set; }
        public string message { get; set; }
    }
}
