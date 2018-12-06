﻿using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.BE.Models.Program
{
    public class ConferenceProgramModel
    {
        public ConferenceDTO Conference { get; set; }
        public List<ConferenceProgramEntryModel> Entries { get; set; }
        public List<SessionDTO> Sessions { get; set; }
        public List<SpecialSessionDTO> SpecialSessions { get; set; }
        public List<EventDTO> Events { get; set; }
    }
}