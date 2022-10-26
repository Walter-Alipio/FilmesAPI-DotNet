using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
  private AppDbContext _context;
  private IMapper _mapper;
  public SessaoController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult addSessao([FromBody] CreateSessaoDTO sessaoDTO)
  {
    Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
    _context.Sessoes.Add(sessao);
    _context.SaveChanges();
    return CreatedAtAction(nameof(showSessaoById), new { Id = sessao.Id }, sessao);
  }

  [HttpGet("{id}")]
  public IActionResult showSessaoById(int id)
  {
    Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
    if (sessao == null)
    {
      return NotFound();
    }
    ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);
    return Ok(sessaoDTO);
  }
}