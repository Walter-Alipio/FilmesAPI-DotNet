using AutoMapper;

public class GerenteProfile : Profile
{
  public GerenteProfile()
  {

    CreateMap<CreateGerenteDTO, Gerente>();

    //Definindo quais os campos de cinemas seram exibidos 
    CreateMap<Gerente, ReadGerenteDTO>()
      .ForMember(gerente => gerente.Cinemas, opts => opts
      .MapFrom(gerente => gerente.Cinemas.Select
      (cine => new { cine.Id, cine.Nome, cine.Endereco, cine.EnderecoId })));
  }
}