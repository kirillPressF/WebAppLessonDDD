using CSharpFunctionalExtensions;

namespace WebAppLessonDDD.Core.Models;

public class News
{
    public const int MAX_TITLE_LENGTH = 100;

    private News(Guid id, string title, string textData, DateTime createDate, Image? titleImage)
    {
        Id = id;
        Title = title;
        TextData = textData;
        CreateDate = createDate;
        TitleImage = titleImage;
    }

    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string TextData { get; } = string.Empty;
    public DateTime CreateDate { get; }
    public int Views { get; } = 0;
    public Image? TitleImage { get; }

    public static Result<News> CreateNews(Guid id, string title, string textData, DateTime createDate,
        Image? titleImage)
    {
        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            return Result.Failure<News>($"{nameof(title)} cannot be null or empty");
        if (string.IsNullOrEmpty(textData) || title.Length > MAX_TITLE_LENGTH)
            return Result.Failure<News>($"{nameof(textData)} cannot be null or empty");

        var news = new News(id, title, textData, createDate, titleImage);

        return Result.Success(news);
    }
}