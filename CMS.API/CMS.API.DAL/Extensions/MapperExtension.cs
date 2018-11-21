using AutoMapper;
using CMS.BE.DTO;

namespace CMS.API.DAL.Extensions
{
    public static class MapperExtension
    {
        public static IMapper mapper;
        static MapperExtension()
        {
            mapper = Configuration.CreateMapper();
        }

        private static MapperConfiguration Configuration
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, AccountDTO>();
                    cfg.CreateMap<AccountDTO, Account>();
                    cfg.CreateMap<Role, RoleDTO>();
                    cfg.CreateMap<RoleDTO, Role>();
                    cfg.CreateMap<Conference, ConferenceDTO>();
                    cfg.CreateMap<ConferenceDTO, Conference>();
                });
                return config;
            }
        }
    }
}
