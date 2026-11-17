using Microsoft.EntityFrameworkCore;

public class GerireContext(DbContextOptions<GerireContext> options) : DbContext(options)
{
    public DbSet<Gerire.Models.gerire> gerire { get; set; } = default!;
    public DbSet<Gerire.Models.Movie> Movie { get; set; } = default!;
}
