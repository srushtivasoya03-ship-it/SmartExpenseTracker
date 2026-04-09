using Amazon.S3;
using Amazon.S3.Transfer;

namespace SmartExpenseTracker.Services
{
    public class S3Service
    {
        private readonly IAmazonS3 _s3Client;

        public S3Service(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileTransferUtility = new TransferUtility(_s3Client);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await fileTransferUtility.UploadAsync(stream, "smart-expense-receipts-12345", fileName);
            }

          return $"https://smart-expense-receipts-12345.s3.ap-south-1.amazonaws.com/{fileName}";      }
    }
}