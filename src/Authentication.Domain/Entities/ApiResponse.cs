namespace Authentication.Domain.Entities
{
    public class ApiResponse<T>
    {
        public bool IsValid { get; set; }
        public T Data { get; set; }
        public ApiResponse(bool isValid, T data)
        {
            IsValid = isValid;
            Data = data;
        }
    }
}