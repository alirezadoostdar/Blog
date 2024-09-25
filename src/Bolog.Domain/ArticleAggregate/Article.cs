﻿using Blog.BuildingBlocks.Domain;
using Bolog.Domain.CommentAggregate;
using System.ComponentModel.Design;

namespace Bolog.Domain.ArticleAggregate;
public class Article : AggregateRoot<ArticleId>
{
    private Article(ArticleId slug) : base(slug)
    {
        _tags = [];
        _likes = [];
    }
    private Article():this(null!) { }

    private readonly List<CommentId> _commentIds = null!;
    public IReadOnlyCollection<CommentId> CommentIds => [.._commentIds];

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
            ReadOnTimeSpan = GetReadOnTimeSpan(body),
            Summary = summary,
            Title = title,
        };
    }
    public static Article CreateArticle(string title, string body,string summary,IReadOnlyList<Tag> tags) 
    {
        var article = CreateDraft(title, body, summary);
        article.AddTags(tags);
        article.Publish();
        return article;
    }

    public void AddTags(IReadOnlyList<Tag> tags)
    {
        _tags.AddRange(tags);
    }

    private static TimeSpan GetReadOnTimeSpan(string body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return TimeSpan.Zero;
        }

        var words = body.Split(' ', '\t', '\n', '\r').Length;
        var readingTimeMinutes = words / 200.0;
        return TimeSpan.FromSeconds(readingTimeMinutes);
    }

    public void UpdateDraft(string title, string summary,string body)
    {
        Title = title;
        Body = body;
        Summary = summary;
        ReadOnTimeSpan = GetReadOnTimeSpan(body);
    }

    public void UpdateTags(IReadOnlyList<Tag> tags)
    {
        _tags.Clear();

        AddTags(tags);
    }

    public void Publish()
    {
        if (_tags.Count == 0)
        {
            throw new DraftTagsMissingException();
        }

        Status = ArticleStatus.Published;
        ReadOnTimeSpan = GetReadOnTimeSpan(Body);
        PublishedOnUtc = DateTime.UtcNow;
    }

    public void Remove()
    {
        Status = ArticleStatus.Deleted;
    }

    public void Like(Like like)
    {
        var item = _likes.FirstOrDefault(x => x==like);
        if (item is null)
        {
            _likes.Add(like);
        }
    }
}
