namespace ServiceExpress.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsForbidden { get; }
        public string? ErrorMessage { get; }
        public T? Value { get; }

        private Result(T? value, bool isSuccess, bool isForbidden, string? errorMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            IsForbidden = isForbidden;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => new(value, true, false, null);
        public static Result<T> Forbidden(string message) => new(default, false, true, message);
        public static Result<T> Failure(string message) => new(default, false, false, message);
    }

}
