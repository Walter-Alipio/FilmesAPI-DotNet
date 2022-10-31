using AutoMapper;
using FluentResults;

public class CinemaService
{
  private AppDbContext _context;
  private IMapper _mapper;
  public CinemaService(AppDbContext context, IMapper mapper)
  {
    _mapper = mapper;
    _context = context;
  }

  public ReadCinemaDTO AddCinema(CreateCinemaDTO cinemaDTO)
  {
    Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
    _context.Cinemas.Add(cinema);
    _context.SaveChanges();

    return _mapper.Map<ReadCinemaDTO>(cinema);
  }

  public List<ReadCinemaDTO> ShowCiemas(string? nomeDoFilme)
  {
    List<Cinema> cinemas = _context.Cinemas.ToList();
    if (cinemas == null)
    {
      return null;
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
    return _mapper.Map<List<ReadCinemaDTO>>(cinemas);
  }

  public ReadCinemaDTO ShowCiemaById(int id)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return null;
    }
    ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
    return cinemaDTO;
  }

  public Result UpdateCinema(int id, UpdateCinemaDTO cinemaDTO)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return Result.Fail("Cinema não encontrado");
    }
    _mapper.Map(cinemaDTO, cinema);
    _context.SaveChanges();
    return Result.Ok();
  }

  public Result DeleteCinema(int id)
  {
    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
    if (cinema == null)
    {
      return Result.Fail("Cinema não encontrado");
    }
    _context.Remove(cinema);
    _context.SaveChanges();
    return Result.Ok();
  }
}