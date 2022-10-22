
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
  private AppDbContext _context;
  private IMapper _mapper;
  public EnderecoController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult addEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
  {
    Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
    _context.Enderecos.Add(endereco);
    _context.SaveChanges();
    return CreatedAtAction(nameof(showEnderecoById), new { Id = endereco.Id }, endereco);
  }

  [HttpGet]
  public IActionResult showEnderecos()
  {
    return Ok(_context.Enderecos);
  }

  [HttpGet("{id}")]
  public IActionResult showEnderecoById(int id)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return NotFound();
    }
    ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
    return Ok(enderecoDTO);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return NotFound();
    }
    _mapper.Map(enderecoDTO, endereco);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult deleteEndereco(int id)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return NotFound();
    }
    _context.Remove(endereco);
    _context.SaveChanges();
    return NoContent();
  }
}