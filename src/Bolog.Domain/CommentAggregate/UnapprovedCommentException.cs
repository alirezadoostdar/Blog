namespace Blog.Domain.CommentAggregate;

public class UnapprovedCommentException : Exception
{
    private const string _message = "Reply is not allowed for unapproved comments.";
    public UnapprovedCommentException() : base(_message)
    {

    }
}
