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

  /// <summary>
  /// Save a new Sessão. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="201">If success</response>
  /// <response code="404">If new item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPost]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public IActionResult addSessao([FromBody] CreateSessaoDTO sessaoDTO)
  {
    ReadSessaoDTO readDto = _sessaoService.AddSessao(sessaoDTO);
    return CreatedAtAction(nameof(showSessaoById), new { Id = readDto.Id }, readDto);
  }

  /// <summary>
  /// Get a specific Sessão.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet("{id}")]
  [Authorize(Roles = "admin , regular")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showSessaoById(int id)
  {
    ReadSessaoDTO readDto = _sessaoService.ShowSessaoById(id);

    if (readDto == null) return NotFound();

    return Ok(readDto);
  }
}