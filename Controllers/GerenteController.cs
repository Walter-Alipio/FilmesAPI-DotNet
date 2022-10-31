using System.Globalization;
using AutoMapper;
using FluentResults;
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

  [HttpPost]
  public IActionResult AddGerente([FromBody] CreateGerenteDTO gerenteDTO)
  {
    ReadGerenteDTO readDto = _gerenteService.AddGerente(gerenteDTO);

    return CreatedAtAction(nameof(showGerenteaById), new { Id = readDto.Id }, readDto);
  }

  [HttpGet("{id}")]
  public IActionResult showGerenteaById(int id)
  {
    ReadGerenteDTO readDto = _gerenteService.ShowGerenteById(id);
    if (readDto == null) return NotFound();

    return Ok(readDto);
  }

  [HttpDelete("{id}")]
  public IActionResult deleteGerente(int id)
  {
    Result resultado = _gerenteService.DeleteGerente(id);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }
}