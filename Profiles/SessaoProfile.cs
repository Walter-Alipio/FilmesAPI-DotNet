using AutoMapper;

public class SessaoProfile : Profile
{
  public SessaoProfile()
  {
    CreateMap<CreateSessaoDTO, Sessao>();
    CreateMap<Sessao, ReadSessaoDTO>()
      .ForMember(dto => dto.HorarioDeInicio, opts => opts
        .MapFrom(dto => dto.HorarioDeEncerramentoDaSessao
        .AddMinutes(dto.Filme.Duracao * (-1))));//O resultado do método seria uma soma, utilizamos a multiplicação por -1 para forçar a subtração.
  }
}