using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{
  private static List<Filme> filmes = new List<Filme>();
  public static int id = 1;

  [HttpPost]
  public IActionResult addFilme([FromBody] Filme filme)
  {
    filme.Id = id++;
    filmes.Add(filme);
    System.Console.WriteLine(filme.Titulo);
    return CreatedAtAction(nameof(showFilmeById), new { Id = filme.Id }, filme);
    /*O primeiro parâmetro mostra como recuperar/acessar o elemento criado
      O segundo parâmetro mostra qual o ID do elemento que foi criado
      O terceiro parâmentro mostra qual foi o elemento criado.
    */
  }

  [HttpGet]
  public IActionResult showFilmes()
  {
    return Ok(filmes);
  }
  /*
    Definimos o retorno com a interface IEnumerable para tornar o método mais generico e pronto para funcionar com quanquer metodo que implemente essa interface.
  */
  [HttpGet("{id}")]//identifica que este get espera um id
  public IActionResult showFilmeById(int id)
  {
    Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme != null)
    {
      return Ok(filme);
    }
    return NotFound();
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