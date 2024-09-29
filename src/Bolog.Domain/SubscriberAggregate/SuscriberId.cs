using Blog.BuildingBlocks.Domain;
using Blog.BuildingBlocks.Exceptions;
using System.Net.Mail;

namespace Blog.Domain.SubscriberAggregate;

public class SubscriberId : ValueObject<SubscriberId>
{
    public MailAddress Email { get; set; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
    }

    public static SubscriberId CreateUniqueId(string email)
    {
        return Create(email);
    }

    public static SubscriberId Create(string value)
    {
        InvalidEmailAddressException.Throw(value);

        return new SubscriberId { Email = new MailAddress(value) };
    }
}
