using System.ComponentModel.Design;

namespace Bolog.Domain.ArticleAggregate;
public class Article
{
    private Article(ArticleId slug):base(slug)
    {
        
    }
    private Article():this(null!) { }

    //private readonly List<CommentId> _commentIds = null!;

    private readonly List<Tag> _tags = null!;
    public IReadOnlyCollection<Tag> Tags => [.. _tags];

    private readonly List<Like> _likes = null!;
    public IReadOnlyCollection<Like> Likes => [.. _likes];

    public Author Author { get; private set; } = null!;

    public string Title { get; private set; } = null!;
    public string Body { get; private set; } = null!;
    public string Summary { get; private set; } = null!;
    public DateTime? PublishedOnUtc { get; private set; }
    public ArticleStatus Status { get; private set; }
    public TimeSpan ReadOnTimeSpan { get; set; }
    public int GetReadOnInMinutes => Convert.ToInt32(ReadOnTimeSpan.TotalMinutes);
    public static Article CreateDraft(string title, string body,string summary)
    {
        return new Article(ArticleId.CreateUniqueId(title))
        {
            Author = Author.CreateDefaultAuthor(),
            Body = body,
            Status = ArticleStatus.Draft,
            ReadOnTimeSpan = getre,
            Summary = summary,
            Title = title,
        };
    }
    public static Article CreateArticle(string title, string body,string summary,IReadOnlyList<Tag> tags) 
    {
        var article = CreateDraft(title, body, summary);
        article.AddTags(tags);
        article.pu
    }

    public void AddTags(IReadOnlyList<Tag> tags)
    {
        _tags.AddRange(tags);
    }
}
