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
  // [HttpGet]
  // public Filme showFilmesById(int id)
  // {
  //   return filmes[id];
  // }
}