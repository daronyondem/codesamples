using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageResizer
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([BlobTrigger("sample-images/{name}", Connection = "AzureWebJobsStorage")] Stream input,
            [Blob("sample-images-sm/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream imageSmall,
            [Blob("sample-images-md/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream imageMedium)
        {
            var thumbnailWidth = Convert.ToInt32(Environment.GetEnvironmentVariable("THUMBNAIL_WIDTH"));

            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load(input))
            {
                var divisor = image.Width / thumbnailWidth;
                var mediumHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

                image.Mutate(x => x.Resize(thumbnailWidth, mediumHeight));
                image.Save(imageSmall, new JpegEncoder());
            }

            input.Position= 0;  
            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load(input))
            {
                thumbnailWidth = thumbnailWidth /2; 
                var divisor = image.Width / thumbnailWidth;
                var smallHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

                image.Mutate(x => x.Resize(thumbnailWidth, smallHeight));
                image.Save(imageMedium, new JpegEncoder());
            }
        }
    }
}
