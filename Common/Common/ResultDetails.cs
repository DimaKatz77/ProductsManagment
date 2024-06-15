namespace ProductsManagment.ErrorHandling.Middleware
{
    public class ResultDetails
    {
        public ResultDetails(bool isSuccess, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "";
    }
}
