using AutoMapper;

public class CinemaProfile : Profile
{
  public CinemaProfile()
  {
    CreateMap<CreateCinemaDTO, Cinema>();
    CreateMap<Cinema, ReadCinemaDTO>();
    CreateMap<UpdateCinemaDTO, Cinema>();
  }
}