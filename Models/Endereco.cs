using System.ComponentModel.DataAnnotations;

public class Endereco
{
  [Key]
  [Required]
  public int Id { get; set; }
  public string Logradouro { get; set; }
  public string Bairro { get; set; }
  public int Numero { get; set; }
  public Cinema Cinema { get; set; }
}