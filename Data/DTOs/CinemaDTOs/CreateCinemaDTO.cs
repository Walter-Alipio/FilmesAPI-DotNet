using System.ComponentModel.DataAnnotations;

public class CreateCinemaDTO
{
  [Required(ErrorMessage = "O campo nome é obrigatório")]
  public string Nome { get; set; }
}