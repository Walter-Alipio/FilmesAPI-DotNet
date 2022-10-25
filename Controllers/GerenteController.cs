using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
  private AppDbContext _context;
  private IMapper _mapper;

  public GerenteController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddGerente([FromBody] CreateGerenteDTO gerenteDTO)
  {
    Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
    _context.Gerentes.Add(gerente);
    _context.SaveChanges();
    return CreatedAtAction(nameof(showGerenteaById), new { Id = gerente.Id }, gerente);
  }

  [HttpGet("{id}")]
  public IActionResult showGerenteaById(int id)
  {
    Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
    if (gerente == null)
    {
      return NotFound();
    }
    ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
    return Ok(gerenteDTO);
  }

  [HttpDelete("{id}")]
  public IActionResult deleteGerente(int id)
  {
    Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
    if (gerente == null)
    {
      return NotFound();
    }

    _context.Remove(gerente);
    _context.SaveChanges();
    return NoContent();

  }
}