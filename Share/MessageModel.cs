namespace learn_admin_backend.Share
{
    public class MessageModel<T>
    {
        public bool? Success { get; set; }

        public T? Data { get; set; }

        public string? Msg { get; set; } = "";
    }
}
