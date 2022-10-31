using AutoMapper;
using FluentResults;

public class EnderecoService
{
  private AppDbContext _context;
  private IMapper _mapper;
  public EnderecoService(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public ReadEnderecoDTO AddEndereco(CreateEnderecoDTO enderecoDTO)
  {
    Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
    _context.Enderecos.Add(endereco);
    _context.SaveChanges();

    return _mapper.Map<ReadEnderecoDTO>(endereco);
  }

  public List<ReadEnderecoDTO> ShowEnderecos()
  {
    List<Endereco> enderecos = _context.Enderecos.ToList();
    if (enderecos == null) return null;

    return _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
  }

  public ReadEnderecoDTO ShowEnderecoById(int id)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return null;
    }
    return _mapper.Map<ReadEnderecoDTO>(endereco);
  }

  public Result UpdateEndereco(int id, UpdateEnderecoDTO enderecoDTO)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return Result.Fail("Endereço não encontrado.");
    }
    _mapper.Map(enderecoDTO, endereco);
    _context.SaveChanges();
    return Result.Ok();
  }

  public Result DeleteEndereco(int id)
  {
    Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    if (endereco == null)
    {
      return Result.Fail("Endereço não encontrado.");
    }
    _context.Remove(endereco);
    _context.SaveChanges();
    return Result.Ok();
  }
}