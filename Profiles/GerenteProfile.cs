using AutoMapper;

public class GerenteProfile : Profile
{
  public GerenteProfile()
  {

    CreateMap<CreateGerenteDTO, Gerente>();
    CreateMap<Gerente, ReadGerenteDTO>();
  }
}