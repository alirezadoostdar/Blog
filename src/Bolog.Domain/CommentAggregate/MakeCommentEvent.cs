﻿using Blog.BuildingBlocks.Domain;

namespace Bolog.Domain.CommentAggregate;

public class MakeCommentEvent : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;

    public CommentId CommentId { get; set; } = null!;
}
