using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace StorySuite.Domain
{
    public class Story(string title, string? summary, Genre primaryGenre, Genre? secondaryGenre, string? content) : Entity
    {
        public const int SummaryMaxLength = 250;
        public const int TitleMaxLength = 250;
        public string? Content { get; set; } = content;

        public Genre PrimaryGenre { get; set; } = primaryGenre;

        public Genre? SecondaryGenre { get; set; } = secondaryGenre;

        [StringLength(SummaryMaxLength)]
        public string? Summary { get; set; } = summary;

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = title;

        public static Result<Story> TryCreate(string title, string? summary, Genre primaryGenre, Genre? secondaryGenre, string? content)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<Story>("Title cannot be empty");

            if (title.Length > TitleMaxLength)
                return Result.Failure<Story>($"Title cannot be longer than {TitleMaxLength} characters");

            if (summary != null && summary.Length > SummaryMaxLength)
                return Result.Failure<Story>($"Summary cannot be longer than {SummaryMaxLength} characters");

            return Result.Success(new Story(title, summary, primaryGenre, secondaryGenre, content));
        }
    }
}