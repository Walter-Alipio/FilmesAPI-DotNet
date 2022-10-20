using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{
  private static List<Filme> filmes = new List<Filme>();
  public static int id = 1;

  [HttpPost]
  public void addFilme([FromBody] Filme filme)
  {
    filme.Id = id++;
    filmes.Add(filme);
    System.Console.WriteLine(filme.Titulo);
  }

  [HttpGet]
  public IEnumerable<Filme> showFilmes()
  {
    return filmes;
  }
  /*
    Definimos o retorno com a interface IEnumerable para tornar o método mais generico e pronto para funcionar com quanquer metodo que implemente essa interface.
  */
  [HttpGet("{id}")]//identifica que este get espera um id
  public Filme showFilmeById(int id)
  {
    return filmes.FirstOrDefault(filme => filme.Id == id);
    // foreach (var filme in filmes)
    // {
    //   if (filme.Id == id)
    //   {
    //     return filme;
    //   }
    // }
    // return null;
  }
}