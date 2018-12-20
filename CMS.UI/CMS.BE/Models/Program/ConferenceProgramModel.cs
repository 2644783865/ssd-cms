using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.BE.Models.Program
{
    public class ConferenceProgramModel
    {
        public ConferenceDTO Conference { get; set; }
        public List<BaseTimeEntity> Entries { get; set; } = new List<BaseTimeEntity>();
        public List<SessionDTO> Sessions { get; set; } = new List<SessionDTO>();
        public List<SpecialSessionDTO> SpecialSessions { get; set; } = new List<SpecialSessionDTO>();
        public List<EventDTO> Events { get; set; } = new List<EventDTO>();
    }
}
