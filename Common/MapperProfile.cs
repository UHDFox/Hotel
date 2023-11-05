using AutoMapper;
using Hotel.Models;

public sealed class MapperProfile : Profile
{

	public MapperProfile()
	{
		CreateMap<NewRoomRequest, Room>();
	}
}
