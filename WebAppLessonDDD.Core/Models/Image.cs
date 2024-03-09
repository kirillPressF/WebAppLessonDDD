using CSharpFunctionalExtensions;

namespace WebAppLessonDDD.Core.Models;

public class Image
{
    public Image(string fileName)
    {
        FileName = fileName;
    }

    public Guid NewsId { get; }
    public string FileName { get; } = string.Empty;

    public static Result<Image> CreateImage(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<Image>($"{nameof(fileName)} cannot be empty or null");
        }

        var image = new Image(fileName);

        return Result.Success(image);
    }
}