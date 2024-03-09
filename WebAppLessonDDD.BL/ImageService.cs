using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using WebAppLessonDDD.Core.Models;

namespace WebAppLessonDDD.BL
{
    public class ImageService
    {
        public async Task<Result<Image>> CreateImage(IFormFile titleImage, string path)
        {
            try
            {
                var fileName = Path.GetFileName(titleImage.FileName);
                var filePath = Path.Combine(path, fileName);
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await titleImage.CopyToAsync(stream);
                }

                var image = Image.CreateImage(filePath);

                return image;
            }
            catch (Exception ex)
            {
                return Result.Failure<Image>(ex.Message);
            }
        }
    }
}
