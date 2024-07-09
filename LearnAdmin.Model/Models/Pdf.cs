namespace LearnAdmin.Model.Models
{
    public class Pdf:RootEntityTkey<int>
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }
    }
}
