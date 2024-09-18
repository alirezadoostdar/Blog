using Blog.BuildingBlocks.Domain;
using System.Net;

namespace Bolog.Domain.ArticleAggregate;

public class Like : ValueObject<Like>
{
    public string ClientIP { get; set; } = null!;
    public DateTime LinkedOn { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ClientIP;
    }

    public static Like Create(string clientIp, DateTime linkedOn)
    {
        if (!IPAddress.TryParse(clientIp,out IPAddress? ipAddress))
        {
            throw new ArgumentOutOfRangeException(nameof(clientIp));
        }

        return new Like
        {
            ClientIP = clientIp,
            LinkedOn = linkedOn
        };
    }
}
