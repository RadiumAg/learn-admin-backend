namespace learn_admin_backend.Share
{
    public class MessageModel<T>
    {
        public bool? Success { get; set; }

        public T? Response { get; set; }

        public string? Msg { get; set; } = "";
    }
}
