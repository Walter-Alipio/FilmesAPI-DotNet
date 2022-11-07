using System.Data;
using AutoMapper;
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

  [HttpPost]
  [Authorize(Roles = "admin")]
  public IActionResult addFilme([FromBody] CreateFilmeDTO filmeDTO)
  {
    ReadFilmeDTO readDto = _filmeService.AddFilme(filmeDTO);

    return CreatedAtAction(nameof(showFilmeById), new { Id = readDto.Id }, readDto);
    /*O primeiro parâmetro mostra como recuperar/acessar o elemento criado
      O segundo parâmetro mostra qual o ID do elemento que foi criado
      O terceiro parâmentro mostra qual foi o elemento criado.
    */
  }

  [HttpGet]
  [Authorize(Roles = "admin , regular", Policy = "IdadeMinima")]
  public IActionResult showFilmes([FromQuery] int? classificacaoEtaria = null)
  {
    List<ReadFilmeDTO> readDto = _filmeService.ShowFilmes(classificacaoEtaria);
    if (readDto != null) return Ok(readDto);
    return NotFound();
  }

  [HttpGet("{id}")]//identifica que este get espera um id
  public IActionResult showFilmeById(int id)
  {
    ReadFilmeDTO readDto = _filmeService.ShowFilmeById(id);
    if (readDto != null) return Ok(readDto);

    return NotFound();
  }

  [HttpPut("{id}")]
  public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
  {
    Result resultado = _filmeService.UpdateFilme(id, filmeDTO);
    if (resultado.IsFailed) return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult deleteFilme(int id)
  {
    Result resultado = _filmeService.DeleteFilme(id);
    if (resultado.IsFailed) return NotFound();

    return NoContent(); //status 204, confirma a requisição mas não envia nenhum corpo de resposta.

  }
}