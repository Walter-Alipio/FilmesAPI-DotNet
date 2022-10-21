using AutoMapper;

public class FilmeProfile : Profile
{
  public FilmeProfile()
  {
    CreateMap<CreateFilmeDTO, Filme>();
    CreateMap<Filme, ReadFilmeDTO>();
    CreateMap<UpdateFilmeDTO, Filme>();
  }
}