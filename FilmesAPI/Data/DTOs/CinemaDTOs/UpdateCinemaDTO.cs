using System.ComponentModel.DataAnnotations;

public class UpdateCinemaDTO
{
  [Required(ErrorMessage = "O campo nome é obrigatório")]
  public string? Nome { get; set; }
  public int EnderecoId { get; set; }
}