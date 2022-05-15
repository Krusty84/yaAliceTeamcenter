using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace TestRestClientTC
{
    public static class Helper
    {
        public static async Task<bool> yaStorageSerializingClass(object target, string yaAccessKeyId, string yaSecretAccessKey, string yaBucketName, string fileName)
        {
            MemoryStream memStream4Cookie = new MemoryStream();
            var binaryCookieForm = new BinaryFormatter();
            binaryCookieForm.Serialize(memStream4Cookie, target);
            //

            AmazonS3Config S3Config = new AmazonS3Config
            {
                ServiceURL = "http://s3.yandexcloud.net"
            };
            AmazonS3Client S3Client = new AmazonS3Client(yaAccessKeyId, yaSecretAccessKey, S3Config);

            try
            {
                PutObjectRequest creatingObject = new PutObjectRequest();
                creatingObject.BucketName = yaBucketName;
                creatingObject.Key = fileName;
                creatingObject.InputStream = memStream4Cookie;
                PutObjectResponse response = await S3Client.PutObjectAsync(creatingObject);
                return true;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public static async Task<object> yaStorageDeserializingClass(string yaAccessKeyId, string yaSecretAccessKey, string yaBucketName, string fileName)
        {
            try
            {
                AmazonS3Config S3Config = new AmazonS3Config
                {
                    ServiceURL = "http://s3.yandexcloud.net"
                };
                AmazonS3Client S3Client = new AmazonS3Client(yaAccessKeyId, yaSecretAccessKey, S3Config);

                GetObjectRequest request = new GetObjectRequest();
                request.BucketName = yaBucketName;
                request.Key = fileName;

                GetObjectResponse response = await S3Client.GetObjectAsync(request);
                Stream responseStream = response.ResponseStream;

                return new BinaryFormatter().Deserialize(responseStream);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public static DateTime convertDateTime2Alice(string inputTCDateTime)
        {
            DateTime convertedDate = DateTime.ParseExact(inputTCDateTime, "dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture);
            return convertedDate;
        }
    }
}