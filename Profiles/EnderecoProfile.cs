using AutoMapper;

public class EnderecoProfile : Profile
{
  public EnderecoProfile()
  {
    CreateMap<CreateEnderecoDTO, Endereco>();
    CreateMap<Endereco, ReadEnderecoDTO>();
    CreateMap<UpdateEnderecoDTO, Endereco>();
  }
}