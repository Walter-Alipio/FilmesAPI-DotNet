using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//explicitando a rota como nome controlador
public class FilmeController : ControllerBase
{

  private FilmeService _filmeService;
  public FilmeController(FilmeService filmeService)
  {
    _filmeService = filmeService;
  }


  /// <summary>
  /// Save a new Filme. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If new item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPost]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult addFilme([FromBody] CreateFilmeDTO filmeDTO)
  {
    ReadFilmeDTO readDto = _filmeService.AddFilme(filmeDTO);

    return CreatedAtAction(nameof(showFilmeById), new { Id = readDto.Id }, readDto);
    /*O primeiro parâmetro mostra como recuperar/acessar o elemento criado
      O segundo parâmetro mostra qual o ID do elemento que foi criado
      O terceiro parâmentro mostra qual foi o elemento criado.
    */
  }

  /// <summary>
  /// Get all Filme.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the list is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet]
  [Authorize(Roles = "admin , regular", Policy = "IdadeMinima")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showFilmes([FromQuery] int? classificacaoEtaria = null)
  {
    List<ReadFilmeDTO> readDto = _filmeService.ShowFilmes(classificacaoEtaria);
    if (readDto != null) return Ok(readDto);
    return NotFound();
  }


  /// <summary>
  /// Get a specific Filme.
  /// </summary>
  /// <returns></returns>
  /// <response code="200">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpGet("{id}")]//identifica que este get espera um id
  [Authorize(Roles = "admin , regular", Policy = "IdadeMinima")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult showFilmeById(int id)
  {
    ReadFilmeDTO readDto = _filmeService.ShowFilmeById(id);
    if (readDto != null) return Ok(readDto);

    return NotFound();
  }

  /// <summary>
  /// Update a specific Filme. Role Admin is necessary
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
  {
    Result resultado = _filmeService.UpdateFilme(id, filmeDTO);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }

  /// <summary>
  /// Deletes a specific Filme. "Role Admin is necessary"
  /// </summary>
  /// <returns></returns>
  /// <response code="204">If success</response>
  /// <response code="404">If the item is null</response>
  /// <response code="401">If role is unauthorized</response>
  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult deleteFilme(int id)
  {
    Result resultado = _filmeService.DeleteFilme(id);
    if (resultado.IsFailed) return NotFound();

    return NoContent(); //status 204, confirma a requisição mas não envia nenhum corpo de resposta.

  }
}