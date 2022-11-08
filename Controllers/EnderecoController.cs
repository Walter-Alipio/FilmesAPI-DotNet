
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
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

  /// <summary>
  /// Save a new Endereço. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="201">If success</response>
  /// <response code="404">If new item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPost]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public IActionResult addEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
  {
    ReadEnderecoDTO readDto = _enderecoService.AddEndereco(enderecoDTO);

    return CreatedAtAction(nameof(showEnderecoById), new { Id = readDto.Id }, readDto);
  }

  /// <summary>
  /// Get a list of Endereços.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the list is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet]
  [Authorize(Roles = "admin , regular")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showEnderecos()
  {
    List<ReadEnderecoDTO> enderecos = _enderecoService.ShowEnderecos();

    if (enderecos == null) return NotFound();

    return Ok(enderecos);
  }

  /// <summary>
  /// Get a specific Endereço.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet("{id}")]
  [Authorize(Roles = "admin , regular")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showEnderecoById(int id)
  {
    ReadEnderecoDTO readDto = _enderecoService.ShowEnderecoById(id);
    if (readDto == null) return NotFound();

    return Ok(readDto);
  }

  /// <summary>
  /// Update a specific Endereço. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
  {
    Result resultado = _enderecoService.UpdateEndereco(id, enderecoDTO);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }

  /// <summary>
  /// Deletes a specific Endereço. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult deleteEndereco(int id)
  {
    Result resultado = _enderecoService.DeleteEndereco(id);

    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }
}