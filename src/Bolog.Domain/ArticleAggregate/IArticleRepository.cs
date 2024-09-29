﻿using Blog.Domain.ArticleAggregate.Models;

namespace Blog.Domain.ArticleAggregate;

public interface IArticleRepository
{
    Task<bool> HasIdAsync(ArticleId articleId, CancellationToken cancellationToken);

    void Add(Article article);

    Task<IReadOnlyCollection<ArchiveModel>> GetArchivesAsync(CancellationToken cancellationToken);

    Task<Article?> GetArticleByIdAsync(ArticleId articleId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Article>> GetLatestArticlesAsync(int pageNumber, int pageSize, string title, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Article>> GetPopularArticlesAsync(int size, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Tag>> GetPopularTagsAsync(int size, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Article>> GetLatestArticlesAsync(Tag tag, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TagModel>> GetTagsAsync(CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Delete(Article draft);
    Task<Article?> GetDraftByIdAsync(ArticleId draftId, CancellationToken cancellationToken);
}
