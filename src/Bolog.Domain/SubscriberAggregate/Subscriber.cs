﻿using Blog.BuildingBlocks.Domain;
using Blog.Domain.ArticleAggregate;
using System.Collections.Immutable;

namespace Blog.Domain.SubscriberAggregate;

public sealed class Subscriber : AggregateRoot<SubscriberId>
{
    public DateTime JoinedOnUtc { get; init; }

    private readonly IList<ArticleId> _articleIds;

    public IReadOnlyCollection<ArticleId> ArticleIds => _articleIds.ToImmutableList();

    public static Subscriber Create(SubscriberId subscriberId)
        => new Subscriber(subscriberId)
        {
            JoinedOnUtc = DateTime.UtcNow
        };

    private Subscriber(SubscriberId id) : base(id)
    {
        _articleIds = [];
    }

    private Subscriber() : this(null!) { }
}
