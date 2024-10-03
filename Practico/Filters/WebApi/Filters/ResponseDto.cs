namespace WebApi.Filters
{
    public class ResponseDto
    {
        public object Content { get; set; }
        public bool ExecutionSuccessful { get; set; }
        public string Message { get; set; }
    }
}
