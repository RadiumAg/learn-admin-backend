namespace learn_admin_backend.Share
{
    public class Response<T>
    {
        public int? StatusCode { get; set; } = 200;

        public T? Data { get; set; }

        public String? ErrorMessage { get; set; } = "";
    }
}
