using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blog.Infrastructure.Persistence;

public class BloggerDbContextFactory : IDesignTimeDbContextFactory<BloggerDbContext>
{
    public BloggerDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<BloggerDbContext>();
        optionBuilder.UseSqlServer("data source=sql2019;initial catalog=blogger;TrustServerCertificate=True;Trusted_Connection=True;");

        return new BloggerDbContext(optionBuilder.Options);
    }
}
