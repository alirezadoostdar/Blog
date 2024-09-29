﻿using Blog.Domain.ArticleAggregate;

namespace Blog.Domain.CommentAggregate;

public interface  ICommentRepository
{
    Task<Comment?> GetCommentByApproveLinkAsync(string link, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Comment>> GetApprovedArticleCommentsAsync(ArticleId articleId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Reply>> GetApprovedRepliesAsync(CommentId commentId, CancellationToken cancellationToken);


    Task CreateAsync(Comment comment, CancellationToken cancellationToken);

    Task<Comment?> GetCommentByIdAsync(CommentId commentId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
