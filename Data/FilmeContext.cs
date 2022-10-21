using Microsoft.EntityFrameworkCore;

public class FilmeContext : DbContext
{
  public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt) { }

  public DbSet<Filme> Filmes { get; set; }
}