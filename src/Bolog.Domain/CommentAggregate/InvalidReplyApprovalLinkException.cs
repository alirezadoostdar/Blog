using Blog.BuildingBlocks.Domain;

namespace Blog.Domain.CommentAggregate;

public class InvalidReplyApprovalLinkException : DomainException
{
    private const string _message = "Invalid Reply approved link.";
    public InvalidReplyApprovalLinkException() : base(_message)
    {
    }
}
