namespace LearnAdmin.Model.Models
{
    public class Pdf
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public required string Url { get; set; }
    }
}
