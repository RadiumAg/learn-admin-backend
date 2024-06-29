namespace LearnAdmin.Share
{
    public class MessageModel<T>
    {
        public bool? Success { get; set; }

        public T? Data { get; set; }

        public String? Msg { get; set; } = "";
    }


    public class MessageModel
    {
        public bool? Success { get; set; }

        public object? Data { get; set; } 

        public String? Msg { get; set; } = "";
    }
}
