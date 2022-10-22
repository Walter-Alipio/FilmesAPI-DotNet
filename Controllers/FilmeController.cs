using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{
  private AppDbContext _context;
  private IMapper _mapper;
  public FilmeController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult addFilme([FromBody] CreateFilmeDTO filmeDTO)
  {
    //mapeando os dados recebidos para o objeto Filme
    Filme filme = _mapper.Map<Filme>(filmeDTO);
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
    if (filme == null)
    {
      return NotFound();
    }
    ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
    return Ok(filmeDTO);
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
  public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme == null)
    {
      return NotFound();
    }
    _mapper.Map(filmeDTO, filme);
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