namespace Domain.DTO
{
    public class ResultDTO
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public static ResultDTO Sucess(dynamic data, string message = "success operation")
        {
            return new ResultDTO
            {
                //IsSuccess = true,
                StatusCode = 200,
                Data = data,
                Message = message,
                //ErrorCode = ErrorCode.None,
            };
        }

        public static ResultDTO Faliure( string message ="invalid operation")
        {
            return new ResultDTO
            {
                //IsSuccess = false,
                StatusCode = 400,
                Data = default,
                Message = message,
                //ErrorCode = errorCode,
            };
        }
    }
}
