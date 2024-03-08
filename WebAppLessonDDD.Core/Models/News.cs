using static System.Net.Mime.MediaTypeNames;

namespace WebAppLessonDDD.Core.Models;

public class News
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TextData { get; set; } = string.Empty;
        public DateTime CreateDate { get; }
        public int Views { get; } = 0;
        public Image? TitleImage { get; }
    }
}