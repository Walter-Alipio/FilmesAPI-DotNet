using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Cinema
{
  [Key]
  [Required]
  public int Id { get; internal set; }
  [Required(ErrorMessage = "O campo nome é obrigatório")]
  public string Nome { get; set; }
  public virtual Endereco Endereco { get; set; }
  public int EnderecoId { get; set; }
  public virtual Gerente Gernte { get; set; }
  public int GerenteId { get; set; }
  [JsonIgnore]
  public virtual List<Sessao> Sessoes { get; set; }
}