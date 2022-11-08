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


  /// <summary>
  /// Save a new Cinema. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="201">If success</response>
  /// <response code="404">If new item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPost]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public IActionResult addCinema([FromBody] CreateCinemaDTO cinemaDTO)
  {
    ReadCinemaDTO readDto = _cinemaService.AddCinema(cinemaDTO);

    return CreatedAtAction(nameof(showCinemaById), new { Id = readDto.Id }, readDto);
  }


  /// <summary>
  /// Get a list of Cinemas.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the list is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet]
  [Authorize(Roles = "admin , regular")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showCinemas([FromQuery] string? nomeDoFilme)
  {
    List<ReadCinemaDTO> readDto = _cinemaService.ShowCiemas(nomeDoFilme);
    if (readDto != null)
    {
      return Ok(readDto);
    }
    return NotFound();
  }

  /// <summary>
  /// Get a specific Cinema.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet("{id}")]
  [Authorize(Roles = "admin , regular")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showCinemaById(int id)
  {
    ReadCinemaDTO readDto = _cinemaService.ShowCiemaById(id);
    if (readDto != null) return Ok(readDto);

    return NotFound();
  }

  /// <summary>
  /// Update a specific Cinema. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
  {
    Result resultado = _cinemaService.UpdateCinema(id, cinemaDTO);
    if (resultado.IsFailed) return NotFound();
    return NoContent();
  }

  /// <summary>
  /// Deletes a specific Cinema. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult deleteCinema(int id)
  {
    Result resultado = _cinemaService.DeleteCinema(id);
    if (resultado.IsFailed) return NotFound();
    return NoContent();
  }
}