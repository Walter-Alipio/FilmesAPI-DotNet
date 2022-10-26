public class ReadSessaoDTO
{
  public int Id { get; set; }
  public Cinema Cinema { get; set; }
  public Filme Filme { get; set; }
  public DateTime HorarioDeEncerramentoDaSessao { get; set; }
  public DateTime HorarioDeInicio { get; set; }
}