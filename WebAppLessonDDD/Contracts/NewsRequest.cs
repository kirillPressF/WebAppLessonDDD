using System.ComponentModel.DataAnnotations;
using WebAppLessonDDD.Core.Models;

namespace WebAppLessonDDD.API.Contracts
{
    public record NewsRequest(
        [Required] [MaxLength(News.MAX_TITLE_LENGTH)]
        string Title,
        [Required] string TextData,
        IFormFile TitleImage
    );
}
