using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
  private SessaoService _sessaoService;
  public SessaoController(SessaoService sessaoService)
  {
    _sessaoService = sessaoService;
  }

  [HttpPost]
  [Authorize(Roles = "admin")]
  public IActionResult addSessao([FromBody] CreateSessaoDTO sessaoDTO)
  {
    ReadSessaoDTO readDto = _sessaoService.AddSessao(sessaoDTO);
    return CreatedAtAction(nameof(showSessaoById), new { Id = readDto.Id }, readDto);
  }

  [HttpGet("{id}")]
  [Authorize(Roles = "admin , regular")]
  public IActionResult showSessaoById(int id)
  {
    ReadSessaoDTO readDto = _sessaoService.ShowSessaoById(id);

    if (readDto == null) return NotFound();

    return Ok(readDto);
  }
}