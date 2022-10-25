using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

public class Filme
{
  [Key]
  [Required]
  public int Id { get; internal set; }
  [Required(ErrorMessage = "O campo Título é obrigratório.")]
  public string Titulo { get; set; }
  [Required(ErrorMessage = "O campo Diretor é obrigratório.")]
  public string Diretor { get; set; }
  [StringLength(30, ErrorMessage = "O genero não pode ultrapassar 30 caracteres.")]
  public string Genero { get; set; }
  [Range(1, 300, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 300 minutos.")]
  public int Duracao { get; set; }
}