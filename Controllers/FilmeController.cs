using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{
  private FilmeContext _context;
  public FilmeController(FilmeContext context)
  {
    _context = context;
  }

  [HttpPost]
  public IActionResult addFilme([FromBody] Filme filme)
  {
    _context.Filmes.Add(filme);
    _context.SaveChanges();

    return CreatedAtAction(nameof(showFilmeById), new { Id = filme.Id }, filme);
    /*O primeiro parâmetro mostra como recuperar/acessar o elemento criado
      O segundo parâmetro mostra qual o ID do elemento que foi criado
      O terceiro parâmentro mostra qual foi o elemento criado.
    */
  }

  [HttpGet]
  public IActionResult showFilmes()
  {
    return Ok(_context.Filmes);
  }
  /*
    Definimos o retorno com a interface IEnumerable para tornar o método mais generico e pronto para funcionar com quanquer metodo que implemente essa interface.
  */
  [HttpGet("{id}")]//identifica que este get espera um id
  public IActionResult showFilmeById(int id)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
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

  [HttpPut("{id}")]
  public IActionResult UpdateFilme(int id, [FromBody] Filme novoFilme)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme == null)
    {
      return NotFound();
    }
    filme.Titulo = novoFilme.Titulo;
    filme.Diretor = novoFilme.Diretor;
    filme.Duracao = novoFilme.Duracao;
    filme.Genero = novoFilme.Genero;
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult deleteFilme(int id)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme == null)
    {
      return NotFound();
    }

    _context.Remove(filme);
    _context.SaveChanges();
    return NoContent(); //status 204, confirma a requisição mas não envia nenhum corpo de resposta.

  }
}