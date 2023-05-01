namespace CashSaver.Helper
{
    public enum ResultStatus
    {
        Success,
        Failure
    }

    public class Result<T>
    {
        public Result<T> CreateFailureResult(string? message = null)
        {
            ErrorMessage = message;
            SetFailureStatus();
            return this;
        }

        public Result<T> CreateSuccessResult(T? value, string? message = null)
        {
            Value = value;
            ErrorMessage = message;
            SetSuccessStatus();
            return this;
        }

        public void SetSuccessStatus() => Status = ResultStatus.Success;
        public void SetFailureStatus() => Status = ResultStatus.Failure;
        public ResultStatus Status { get; private set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
        public bool IsSucceded => Status == ResultStatus.Success;
    }
}
