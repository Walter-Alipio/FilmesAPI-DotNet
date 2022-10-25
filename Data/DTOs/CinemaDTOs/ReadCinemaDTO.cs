using System.ComponentModel.DataAnnotations;

public class ReadCinemaDTO
{
  [Key]
  [Required]
  public int Id { get; internal set; }
  [Required(ErrorMessage = "O campo nome é obrigatório")]
  public string Nome { get; set; }
  public Endereco Endereco { get; set; }
  public Gerente Gerente { get; set; }
}