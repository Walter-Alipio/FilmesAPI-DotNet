using AutoMapper;
using FluentResults;

public class FilmeService
{
  private AppDbContext _context;
  private IMapper _mapper;

  public FilmeService(AppDbContext context, IMapper mapper)
  {
    _mapper = mapper;
    _context = context;
  }

  public ReadFilmeDTO AddFilme(CreateFilmeDTO filmeDTO)
  {
    //mapeando os dados recebidos para o objeto Filme
    Filme filme = _mapper.Map<Filme>(filmeDTO);
    _context.Filmes.Add(filme);
    _context.SaveChanges();

    return _mapper.Map<ReadFilmeDTO>(filme);
  }

  public List<ReadFilmeDTO> ShowFilmes(int? classificacaoEtaria)
  {
    List<Filme> filmes;
    if (classificacaoEtaria == null)
    {
      filmes = _context.Filmes.ToList();
    }
    else
    {
      filmes = _context.Filmes
        .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
    }


    if (filmes != null)
    {
      List<ReadFilmeDTO> reaDtos = _mapper.Map<List<ReadFilmeDTO>>(filmes);
      return reaDtos;
    }
    return null;
  }

  public ReadFilmeDTO ShowFilmeById(int id)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme != null)
    {
      ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
      return filmeDTO;
    }
    return null;
  }

  public Result UpdateFilme(int id, UpdateFilmeDTO filmeDTO)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme == null)
    {
      return Result.Fail("Filme não encontrado");
    }
    _mapper.Map(filmeDTO, filme);
    _context.SaveChanges();
    return Result.Ok();
  }

  internal Result DeleteFilme(int id)
  {
    Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if (filme == null)
    {
      return Result.Fail("Filme não encontrado.");
    }

    _context.Remove(filme);
    _context.SaveChanges();
    return Result.Ok();
  }
}