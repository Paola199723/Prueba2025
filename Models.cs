using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
       
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

        // Si no existe variable de entorno, usar esta cadena por defecto (externa Render)
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString =
                "Host=dpg-d3hc6apr0fns73c9mui0-a.oregon-postgres.render.com;" +
                "Port=5432;" +
                "Database=prueba2025;" +
                "Username=prueba2025_user;" +
                "Password=pjHxLixIA8mpB6Jzmr2ryGtvc7iwk9eJ;" +
                "SSL Mode=Require;" +
                "Trust Server Certificate=true";
        }

      
        options.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostTag>()
            .HasKey(pt => new { pt.PostId, pt.TagId });
    }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<Post> Posts { get; set; } = new();
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<Comment> Comments { get; set; } = new();
    public List<PostTag> PostTags { get; set; } = new();
}

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<PostTag> PostTags { get; set; } = new();
}

public class PostTag
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}
