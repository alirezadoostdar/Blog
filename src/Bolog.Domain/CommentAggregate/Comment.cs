using Blog.BuildingBlocks.Domain;

namespace Bolog.Domain.CommentAggregate;

public class Comment : AggregateRoot<CommentId>
{
    private Comment(CommentId id) : base(id)
    {
        
    }

    private Comment() : this(null!) { }
    private readonly IList<Reply> _replies;
    public IReadOnlyCollection<Reply> Replys => [.. _replies];
    

}
