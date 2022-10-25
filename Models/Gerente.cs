using System.ComponentModel.DataAnnotations;

public class Gerente
{
  [Key]
  [Required]
  public int Id { get; set; }
  public string Nome { get; set; }
}