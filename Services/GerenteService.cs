using AutoMapper;
using FluentResults;

public class GerenteService
{
  private AppDbContext _context;
  private IMapper _mapper;
  public GerenteService(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public ReadGerenteDTO AddGerente(CreateGerenteDTO gerenteDTO)
  {
    Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
    _context.Gerentes.Add(gerente);
    _context.SaveChanges();

    return _mapper.Map<ReadGerenteDTO>(gerente);
  }

  public ReadGerenteDTO ShowGerenteById(int id)
  {
    Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
    if (gerente == null)
    {
      return null;
    }
    return _mapper.Map<ReadGerenteDTO>(gerente);
  }

  public Result DeleteGerente(int id)
  {
    Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

    if (gerente == null)
    {
      return Result.Fail("Gerente não encontrado.");
    }

    _context.Remove(gerente);
    _context.SaveChanges();
    return Result.Ok();
  }
}