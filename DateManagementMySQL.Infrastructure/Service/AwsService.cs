using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using AWSSDK;
using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DateManagementMySQL.Infrastructure.Service
{
    public class AwsService(IAmazonS3 amazonS3,IConfiguration configuration,IlogService logService,IAwsImageBLL awsImageBLL) : IAwsService
    {
       private IAmazonS3 _amazonS3 = amazonS3;
       private IConfiguration _configuration = configuration;
       private IlogService _logService = logService;
        private IAwsImageBLL _awsImageBLL = awsImageBLL;

        public async Task<ResponseDTO> DeleteFileAsync(string fileName,int fileId)
        {
            ResponseDTO response = new();
            response.IsSuccess = false;

            try
            {
                var DeleteRequest = new DeleteObjectRequest
                {
                    BucketName = _configuration["AWS:BucketName"],
                    Key = fileName,
                };
                await _amazonS3.DeleteObjectAsync(DeleteRequest);
                var responseRepository = await _awsImageBLL.DeleteImage(fileId);
                response.IsSuccess= responseRepository.IsSuccess;
                response.Message = responseRepository.Message;
                return response;
            }
            catch (Exception ex)
            {
                _logService.message($"error en AwsService :{ex}");
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseDTO> GetUrlFileAsync(string fileName)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                var UrlRequest = new GetPreSignedUrlRequest
                {
                    BucketName =_configuration["AWS:BucketName"],
                    Key = fileName,
                    Expires = DateTime.UtcNow.AddYears(2),
                    Protocol= Protocol.HTTPS,
                };
                var presignedUrl = await _amazonS3.GetPreSignedURLAsync(UrlRequest);
                
                response.IsSuccess= true;
                response.Message = "url Generada";
                response.Data = presignedUrl;
                return response;
            }
            catch (Exception ex)
            {
                _logService.message($"error en AwsService :{ex}");
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
            
        }

        public async Task<ResponseDTO> UploadFileAsync(IFormFile fileData)
        {
            ResponseDTO response = new();
            response.IsSuccess = false;

            try
            {
                using (var stream = new MemoryStream())
                {
                    await fileData.CopyToAsync(stream);
                    var UploadRequest = new PutObjectRequest
                    {
                        BucketName = _configuration["AWS:BucketName"],
                        Key = fileData.FileName,
                        InputStream = stream,
                        ContentType = fileData.ContentType
                    };
                    await _amazonS3.PutObjectAsync(UploadRequest);

                }
                var UrlRequest = new GetPreSignedUrlRequest
                {
                    BucketName =_configuration["AWS:BucketName"],
                    Key = fileData.FileName,
                    Expires = DateTime.UtcNow.AddYears(2),
                    Protocol= Protocol.HTTPS,
                };
                var presignedUrl = await _amazonS3.GetPreSignedURLAsync(UrlRequest);
                AwsImagesDTO image = new();
                image.FileName = fileData.FileName;
                image.ContentType = fileData.ContentType;
                image.FileUrl = presignedUrl;
                image.BucketName = _configuration["AWS:BucketName"];
                var responsedata = await _awsImageBLL.UploadImage(image);
                response.IsSuccess= responsedata.IsSuccess;
                response.Message = responsedata.Message;
                response.Data = presignedUrl;
                return response;

            }
            catch (Exception ex)
            {
                _logService.message($"error en AwsService :{ex}");
               response.IsSuccess = false;
               response.Message = ex.Message;
               return response;
            }
        }
    }
}
