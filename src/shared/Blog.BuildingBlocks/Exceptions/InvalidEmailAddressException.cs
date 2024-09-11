using Blog.BuildingBlocks.Domain;
using System.Net.Mail;

namespace Blog.BuildingBlocks.Exceptions;

public class InvalidEmailAddressException : DomainException
{
    private const string _message = "Invalid Email Address.";

    public InvalidEmailAddressException() : base(_message) { }

    public static void Throw(string email)
    {
        if (!MailAddress.TryCreate(email,out _))
        {
            throw new InvalidEmailAddressException();
        }
    }
}
