using Blog.BuildingBlocks.Domain;
using Humanizer;

namespace Bolog.Domain.ArticleAggregate;

public sealed class ArticleId : ValueObject<ArticleId>
{
    public required string Slug { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Slug;
    }

    public static ArticleId CreateUniqueId(string title)
        =>Create(title.Kebaberize());

    public static ArticleId Create(string title)
        =>new ArticleId { Slug = title };

    public override string ToString() => Slug;
}
