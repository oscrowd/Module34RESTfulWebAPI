using AutoMapper;
using Module34RESTfulWebAPI.Contracts;
using Module34RESTfulWebAPI.Configuration;
using Module34RESTfulWebAPI.Controllers;


namespace Module34RESTfulWebAPI
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, Contracts.HomeApi.Contracts.AddressInfo>();
            CreateMap<HomeOptions, Contracts.HomeApi.Contracts.InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
