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

                    //TEAM A 
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
                    cfg.CreateMap<LastMessage, LastMessageDTO>().ForMember(dest => dest.LastMessageContent, opt => opt.MapFrom(src => src.LastMessage1));
                    cfg.CreateMap<LastMessageDTO, LastMessage>().ForMember(dest => dest.LastMessage1, opt => opt.MapFrom(src => src.LastMessageContent));



                    //team B
                    cfg.CreateMap<Award, AwardDTO>();
                    cfg.CreateMap<AwardDTO, Award>();
                    cfg.CreateMap<Event, EventDTO>();
                    cfg.CreateMap<EventDTO, Event>();
                    cfg.CreateMap<Task, TaskDTO>();
                    cfg.CreateMap<TaskDTO, Task>();

                    //team C
                    cfg.CreateMap<Review, ReviewDTO>();
                    cfg.CreateMap<ReviewDTO, Review>();
                    cfg.CreateMap<Author, AuthorDTO>();
                    cfg.CreateMap<AuthorDTO, Author>();
                    cfg.CreateMap<Submission, SubmissionDTO>();
                    cfg.CreateMap<SubmissionDTO, Submission>();
                    cfg.CreateMap<Article, ArticleDTO>();
                    cfg.CreateMap<ArticleDTO, Article>();
                    cfg.CreateMap<TravelInfo, TravelInfoDTO>();
                    cfg.CreateMap<TravelInfoDTO, TravelInfo>();
                    cfg.CreateMap<AccommodationInfo, AccommodationInfoDTO>();
                    cfg.CreateMap<AccommodationInfoDTO, AccommodationInfo>();
                    cfg.CreateMap<EmergencyInfo, EmergencyInfoDTO>();
                    cfg.CreateMap<EmergencyInfoDTO, EmergencyInfo>();
                    cfg.CreateMap<WelcomePackReceiver, WelcomePackReceiverDTO>();
                    cfg.CreateMap<WelcomePackReceiverDTO, WelcomePackReceiver>();
                });
                return config;
            }
        }
    }
}
