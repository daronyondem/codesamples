using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Company.Function
{
    public class ImageResizer
    {
        private readonly ILogger _logger;

        public ImageResizer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ImageResizer>();
        }

        [Function("ImageResizer")]
        public MyOutputType Run([BlobTrigger("sample-images/{name}", Connection = "20230429ec1eb2_STORAGE")] byte[] inputArray)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob");

            // Workaround for Worker bindings issue with Stream bindings in Isolated Functions.
            // https://github.com/Azure/azure-functions-dotnet-worker/issues/378#issuecomment-820768693
            Stream input = new MemoryStream(inputArray);

            var output = new MyOutputType();

            var thumbnailWidth = Convert.ToInt32(Environment.GetEnvironmentVariable("THUMBNAIL_WIDTH"));

            using (Image image = Image.Load(input))
            {
                MemoryStream mem = new MemoryStream();
                var divisor = image.Width / thumbnailWidth;
                var mediumHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(thumbnailWidth, mediumHeight)
                }));

                image.Save(mem, new JpegEncoder());
                output.imageMedium = mem.ToArray();
            }

            input.Position = 0;
            thumbnailWidth = thumbnailWidth /2;
            using (Image image = Image.Load(input))
            {
                MemoryStream mem = new MemoryStream();
                var divisor = image.Width / thumbnailWidth;
                var mediumHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(thumbnailWidth, mediumHeight)
                }));

                image.Save(mem, new JpegEncoder());
                output.imageSmall = mem.ToArray();
            }
            return output;
        }

        public class MyOutputType
        {
             [BlobOutput("sample-images-sm/{name}", Connection = "AzureWebJobsStorage")]
            public byte[]? imageSmall { get; set; }

            [BlobOutput("sample-images-md/{name}", Connection = "AzureWebJobsStorage")]
            public byte[]? imageMedium { get; set; }
        }
    }
}
