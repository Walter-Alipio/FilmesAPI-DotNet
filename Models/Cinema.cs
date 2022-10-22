using System.ComponentModel.DataAnnotations;

public class Cinema
{
  [Key]
  [Required]
  public int Id { get; internal set; }
  [Required(ErrorMessage = "O campo nome é obrigatório")]
  public string Nome { get; set; }
  public Endereco Endereco { get; set; }
  public int EnderecoId { get; set; }
}