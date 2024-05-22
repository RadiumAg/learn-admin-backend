namespace learn_admin_backend.Share
{
    public class Reponse<T>
    {
        public T Data { get; set; }
        public String? ErrorMessage { get; set; }
    }
}
