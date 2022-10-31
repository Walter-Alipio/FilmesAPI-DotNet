
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
  private EnderecoService _enderecoService;
  public EnderecoController(EnderecoService enderecoService)
  {
    _enderecoService = enderecoService;
  }

  [HttpPost]
  public IActionResult addEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
  {
    ReadEnderecoDTO readDto = _enderecoService.AddEndereco(enderecoDTO);

    return CreatedAtAction(nameof(showEnderecoById), new { Id = readDto.Id }, readDto);
  }

  [HttpGet]
  public IActionResult showEnderecos()
  {
    List<ReadEnderecoDTO> enderecos = _enderecoService.ShowEnderecos();

    if (enderecos == null) return NotFound();

    return Ok(enderecos);
  }

  [HttpGet("{id}")]
  public IActionResult showEnderecoById(int id)
  {
    ReadEnderecoDTO readDto = _enderecoService.ShowEnderecoById(id);
    if (readDto == null) return NotFound();

    return Ok(readDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
  {
    Result resultado = _enderecoService.UpdateEndereco(id, enderecoDTO);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult deleteEndereco(int id)
  {
    Result resultado = _enderecoService.DeleteEndereco(id);

    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }
}