using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{
  private static List<Filme> filmes = new List<Filme>();

  [HttpPost]
  public void addFilme([FromBody] Filme filme)
  {
    filmes.Add(filme);
    System.Console.WriteLine(filme.Titulo);
  }

  [HttpGet]
  public List<Filme> showFilmes()
  {
    return filmes;
  }
}