using Blog.BuildingBlocks.Domain;

namespace Bolog.Domain.ArticleAggregate;

internal class DraftTagsMissingException : DomainException
{
    private const string _message = "Cannot publich draft without tags.";

    public DraftTagsMissingException() :base(_message)
    { 
    }
}
