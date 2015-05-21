namespace simple
{
	using AutoMapper;

    using simple.Models;
    using simple.Dtos;

	public class Bootstrapper
	{
		public void Automapper()
		{
            //Mapper.CreateMap<HostelDto, HotelInfo>()
            //         .ForMember(dest => dest.Latitude, opt => opt.ResolveUsing<LatitudeResolver>())
            //         .ForMember(dest => dest.Longitude, opt => opt.ResolveUsing<LongitudeResolver>());
        }
	}

    //public class LatitudeResolver : ValueResolver<ConferenceDto, double>
    //{
    //    protected override double ResolveCore(ConferenceDto source)
    //    {
    //        return source.Position[0];
    //    }
    //}

    //public class LongitudeResolver : ValueResolver<ConferenceDto, double>
    //{
    //    protected override double ResolveCore(ConferenceDto source)
    //    {
    //        return source.Position[1];
    //    }
    //}
}