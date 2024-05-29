
namespace learn_admin_backend.Dto.Pdf
{
    public class CreatePdpsDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public required string Url { get; set; }
    }


    public class CreatePdpsResponseDto
    {
        public int Id { get; set; }

    }
}
