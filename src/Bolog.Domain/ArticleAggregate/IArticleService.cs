namespace Bolog.Domain.ArticleAggregate;

public interface IArticleService
{
    Task<bool> IsArticleIdValidAsync(ArticleId articleId, CancellationToken cancellationToken);

    Task<bool> HasIdAsync(ArticleId articleId, CancellationToken cancellationToken);
}
