using System.ComponentModel.DataAnnotations.Schema;

namespace learn_admin_backend.Database
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
