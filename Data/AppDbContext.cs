using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

  //defini como o modelo será criado através do ModelBuilder
  protected override void OnModelCreating(ModelBuilder builder)//
  {
    // 1:1
    builder.Entity<Endereco>()
      .HasOne(endereco => endereco.Cinema)
      .WithOne(cinema => cinema.Endereco)
      .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

    // 1:n
    builder.Entity<Cinema>()
      .HasOne(cinema => cinema.Gernte)
      .WithMany(gerente => gerente.Cinemas)
      .HasForeignKey(cinema => cinema.GerenteId);

    //.IsRequired(false) permitiria criar um Cinema sem a obrigatoriedade de um Gerente.

    /*.OnDelete(DeleteBehavior.Restrict); Essa linha pode ser adicionada para evitar que, ao apagar um Gerente, os Cinemas a ele vinculados também sejam apagados
    */

    // n:n
    builder.Entity<Sessao>()
      .HasOne(sessao => sessao.Filme)
      .WithMany(filme => filme.Sessoes)
      .HasForeignKey(sessao => sessao.FilmeID);

    builder.Entity<Sessao>()
      .HasOne(sessao => sessao.Cinema)
      .WithMany(cinema => cinema.Sessoes)
      .HasForeignKey(sessao => sessao.CinemaId);
  }

  public DbSet<Filme> Filmes { get; set; }
  public DbSet<Cinema> Cinemas { get; set; }
  public DbSet<Endereco> Enderecos { get; set; }
  public DbSet<Gerente> Gerentes { get; set; }
  public DbSet<Sessao> Sessoes { get; set; }
}