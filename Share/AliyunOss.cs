using Aliyun.OSS;
using Aliyun.OSS.Common;
using System.Security.Cryptography;

namespace learn_admin_backend.Share
{
    public class AliyunOss
    {
        string endpoint;
        string accessKeyId;
        string accessKeySecret;
        OssClient client;
        readonly IConfiguration configuration;
        AutoResetEvent _event = new AutoResetEvent(false);
        HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();

        public AliyunOss(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.endpoint = configuration["Endpoint"];
            this.accessKeyId = configuration["accessKeyId"];
            this.accessKeySecret = configuration["AccessKeySecret"];
            this.client = new OssClient(this.endpoint, this.accessKeyId, this.accessKeySecret);
        }

        public void PutObjectFromFile(string bucketName, Stream fileToUpload)
        {
            const string key = "PutObjectFromFile";
            try
            {
                client.PutObject(bucketName, key, fileToUpload);
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
        }

    }
}
