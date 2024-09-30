using Blog.Domain.ArticleAggregate;
using Blog.Domain.CommentAggregate;
using Blog.Domain.SubscriberAggregate;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistence;

public class BloggerDbContext : DbContext
{
    public BloggerDbContext (DbContextOptions<BloggerDbContext> options) : base(options)
    {

    }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(BloggerDbContextSchema.DefaultSchema);

        var infrastructureAssembly = typeof(IAssemblyMaker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
    }
}
