using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
  private CinemaService _cinemaService;
  public CinemaController(CinemaService cinemaService)
  {
    _cinemaService = cinemaService;
  }

  [HttpPost]
  [Authorize(Roles = "admin")]
  public IActionResult addCinema([FromBody] CreateCinemaDTO cinemaDTO)
  {
    ReadCinemaDTO readDto = _cinemaService.AddCinema(cinemaDTO);

    return CreatedAtAction(nameof(showCinemaById), new { Id = readDto.Id }, readDto);
  }

  [HttpGet]
  [Authorize(Roles = "admin , regular")]
  public IActionResult showCinemas([FromQuery] string? nomeDoFilme)
  {
    List<ReadCinemaDTO> readDto = _cinemaService.ShowCiemas(nomeDoFilme);
    if (readDto != null)
    {
      return Ok(readDto);
    }
    return NotFound();
  }

  [HttpGet("{id}")]
  [Authorize(Roles = "admin , regular")]
  public IActionResult showCinemaById(int id)
  {
    ReadCinemaDTO readDto = _cinemaService.ShowCiemaById(id);
    if (readDto != null) return Ok(readDto);

    return NotFound();
  }

  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
  {
    Result resultado = _cinemaService.UpdateCinema(id, cinemaDTO);
    if (resultado.IsFailed) return NotFound();
    return NoContent();
  }

  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  public IActionResult deleteCinema(int id)
  {
    Result resultado = _cinemaService.DeleteCinema(id);
    if (resultado.IsFailed) return NotFound();
    return NoContent();
  }
}