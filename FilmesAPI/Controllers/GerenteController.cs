using System.Globalization;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
  private GerenteService _gerenteService;

  public GerenteController(GerenteService gerenteService)
  {
    _gerenteService = gerenteService;
  }

  /// <summary>
  /// Save a new Gerente. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="201">If success</response>
  /// <response code="404">If new item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPost]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public IActionResult AddGerente([FromBody] CreateGerenteDTO gerenteDTO)
  {
    ReadGerenteDTO readDto = _gerenteService.AddGerente(gerenteDTO);

    return CreatedAtAction(nameof(showGerenteaById), new { Id = readDto.Id }, readDto);
  }

  /// <summary>
  /// Get a specific Gerente.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showGerenteaById(int id)
  {
    ReadGerenteDTO readDto = _gerenteService.ShowGerenteById(id);
    if (readDto == null) return NotFound();

    return Ok(readDto);
  }

  /// <summary>
  /// Deletes a specific Gerente. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult deleteGerente(int id)
  {
    Result resultado = _gerenteService.DeleteGerente(id);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }
}