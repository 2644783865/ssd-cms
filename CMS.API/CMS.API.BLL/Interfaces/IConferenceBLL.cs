﻿using CMS.BE.DTO;
using CMS.BE.Models.Program;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IConferenceBLL
    {
        IEnumerable<ConferenceDTO> GetConferences();
        ConferenceDTO GetConferenceById(int id);
        bool AddConference(ConferenceDTO conference);
        bool EditConference(ConferenceDTO conference);
        bool DeleteConference(int conferenceId);
        ConferenceProgramModel GetConferenceProgram(int conferenceId);
        ConferenceScheduleModel GetConferenceSchedule(int accountId, int conferenceId);
        byte[] GetConferenceScheduleICal(int accountId, int conferenceId);
    }
}
