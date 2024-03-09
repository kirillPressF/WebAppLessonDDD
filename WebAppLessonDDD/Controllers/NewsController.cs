using Microsoft.AspNetCore.Mvc;
using WebAppLessonDDD.API.Contracts;
using WebAppLessonDDD.BL;
using WebAppLessonDDD.Core.Models;

namespace WebAppLessonDDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController:ControllerBase
    {
        private readonly string _staticFilesPath =
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/Images");
        private readonly NewsService _newsService;
        private readonly  ImageService _imageService;

        public NewsController(NewsService newsService, ImageService imageService)
        {
            _newsService = newsService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNews(NewsRequest request)
        {
            var imageResult = await _imageService.CreateImage(request.TitleImage, _staticFilesPath);
            if (imageResult.IsFailure)
            {
                return BadRequest(imageResult.Error);
            }

            var news = News.Create(Guid.NewGuid(), request.Title, request.TextData, imageResult.Value);
            if (news.IsFailure)
            {
                return BadRequest(news.Error);
            }
            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> CountVie()
        {
            await _newsService.CountView();
        }
    }
}
