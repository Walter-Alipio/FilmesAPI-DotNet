public class ReadGerenteDTO
{
  public int Id { get; set; }
  public string? Nome { get; set; }
  public object? Cinemas { get; set; }//usando object para poder selecionar o que deve ser mapeado no GerenteProfile
}