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


                    cfg.CreateMap<Presentation, PresentationDTO>();
                    cfg.CreateMap<PresentationDTO, Presentation>();
                    cfg.CreateMap<SpecialSession, SpecialSessionDTO>();
                    cfg.CreateMap<SpecialSessionDTO, SpecialSession>();
                    cfg.CreateMap<Session, SessionDTO>();
                    cfg.CreateMap<SessionDTO, Session>();
                    cfg.CreateMap<Room, RoomDTO>();
                    cfg.CreateMap<RoomDTO, Room>();
                    cfg.CreateMap<Building, BuildingDTO>();
                    cfg.CreateMap<BuildingDTO, Building>();
                    cfg.CreateMap<Message, MessageDTO>();
                    cfg.CreateMap<MessageDTO, Message>();



                    //team B
                    cfg.CreateMap<Award, AwardDTO>();
                    cfg.CreateMap<AwardDTO, Award>();
                    cfg.CreateMap<Event, EventDTO>();
                    cfg.CreateMap<EventDTO, Event>();
                    cfg.CreateMap<Task, TaskDTO>();
                    cfg.CreateMap<TaskDTO, Task>();

                });
                return config;
            }
        }
    }
}
