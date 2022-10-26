using System.ComponentModel.DataAnnotations;

public class Sessao
{
  [Key]
  [Required]
  public int Id { get; set; }
  public virtual Cinema Cinema { get; set; }
  public int CinemaId { get; set; }
  public virtual Filme Filme { get; set; }
  public int FilmeID { get; set; }
  public DateTime HorarioDeEncerramentoDaSessao { get; set; }
}