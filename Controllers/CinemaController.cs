using AutoMapper;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
  private AppDbContext _context;
  private IMapper _mapper;
  public CinemaController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult addCinema([FromBody] CreateCinemaDTO cinemaDTO)
  {
    Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
    _context.Cinemas.Add(cinema);
    _context.SaveChanges();
    return CreatedAtAction(nameof(showCinemaById), new { Id = cinema.Id }, cinema);
  }

  [HttpGet]
  public IActionResult showCinemas([FromQuery] string? nomeDoFilme)
  {
    List<Cinema> cinemas = _context.Cinemas.ToList();
    if (cinemas == null)
    {
      return NotFound();
    }

    if (!string.IsNullOrEmpty(nomeDoFilme))
    {
      //LINQ
      IEnumerable<Cinema> query = from cinema in cinemas
                                  where cinema.Sessoes.Any(sessao =>
                                  sessao.Filme.Titulo == nomeDoFilme)
                                  select cinema;

      cinemas = query.ToList();
    }
    List<ReadCinemaDTO> readDto = _mapper.Map<List<ReadCinemaDTO>>(cinemas);

    return Ok(readDto);
  }

  [HttpGet("{id}")]
  public IActionResult showCinemaById(int id)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return NotFound();
    }
    ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
    return Ok(cinemaDTO);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return NotFound();
    }
    _mapper.Map(cinemaDTO, cinema);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult deleteCinema(int id)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return NotFound();
    }
    _context.Remove(cinema);
    _context.SaveChanges();
    return NoContent();
  }
}