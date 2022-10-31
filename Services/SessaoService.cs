using AutoMapper;

public class SessaoService
{
  private AppDbContext _context;
  private IMapper _mapper;
  public SessaoService(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public ReadSessaoDTO AddSessao(CreateSessaoDTO sessaoDTO)
  {
    Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
    _context.Sessoes.Add(sessao);
    _context.SaveChanges();

    return _mapper.Map<ReadSessaoDTO>(sessao);
  }

  public ReadSessaoDTO ShowSessaoById(int id)
  {
    Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
    if (sessao == null)
    {
      return null;
    }
    return _mapper.Map<ReadSessaoDTO>(sessao);
  }
}