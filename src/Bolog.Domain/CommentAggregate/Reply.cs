﻿using Blog.BuildingBlocks.Domain;

namespace Bolog.Domain.CommentAggregate;

public class Reply : ValueObject<ReplyId>
{
    public Guid Value { get; set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ReplyId CreateUniqueId() => Create(Guid.NewGuid());

    public static ReplyId Create(Guid value) => new ReplyId
    {
        Value = value
    };
    public override string ToString()
    {
        return Value.ToString();
    }
}