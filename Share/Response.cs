namespace learn_admin_backend.Share
{
    public class Response<T>
    {
        public bool? success { get; set; }

        public T? response { get; set; }

        public string? msg { get; set; } = "";
    }
}
