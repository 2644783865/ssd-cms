using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Program;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.API.BLL.BLL
{
    public class ConferenceBLL : IConferenceBLL
    {
        private IConferenceRepository _repository = new ConferenceRepository();
        private IEventRepository _eventRepository = new EventRepository();
        private ISessionRepository _sessionRepository = new SessionRepository();
        private IAuthenticationRepository _authRepository = new AuthenticationRepository();

        public IEnumerable<ConferenceDTO> GetConferences()
        {
            try
            {
                return _repository.GetConferences();
            }
            catch
            {
                return null;
            }
        }

        public ConferenceDTO GetConferenceById(int id)
        {
            try
            {
                var conference = _repository.GetConferenceById(id);
                if (conference == null) return null;
                return conference;
            }
            catch
            {
                return null;
            }
        }

        public bool AddConference(ConferenceDTO conference)
        {
            try
            {
                _repository.AddConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditConference(ConferenceDTO conference)
        {
            try
            {
                _repository.EditConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteConference(int conferenceId)
        {
            try
            {
                _repository.DeleteConference(conferenceId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public ConferenceProgramModel GetConferenceProgram(int conferenceId)
        {
            var conference = _repository.GetConferenceById(conferenceId);
            if (conference == null) return null;
            var events = _eventRepository.GetEventsForConferenceWithBaseEntryAttributes(conferenceId).ToList();
            var sessions = _sessionRepository.GetSessionsForConferenceWithBaseEntryAttributes(conferenceId).ToList();
            var specialSessions = _sessionRepository.GetSpecialSessionsForConferenceWithBaseEntryAttributes(conferenceId).ToList();
            var entries = (_eventRepository.GetEvents(conferenceId) as IEnumerable<BaseEntryEntity>).ToList();
            entries.AddRange((_sessionRepository.GetSessions(conferenceId) as IEnumerable<BaseEntryEntity>));
            entries.AddRange((_sessionRepository.GetSpecialSessions(conferenceId) as IEnumerable<BaseEntryEntity>));
            entries = entries.OrderBy(ent => ent.BeginDate).ToList();
            return new ConferenceProgramModel()
            {
                Conference = conference,
                Entries = entries,
                Events = events,
                Sessions = sessions,
                SpecialSessions = specialSessions
            };
        }

        public ConferenceScheduleModel GetConferenceSchedule(int accountId, int conferenceId)
        {
            var conference = _repository.GetConferenceById(conferenceId);
            var person = _authRepository.GetAccountById(accountId);
            var entries = (_sessionRepository.GetSessionsForConferenceAndChairWithBaseEntryAttributes(accountId, conferenceId) as IEnumerable<BaseEntryEntity>).OrderBy(ent => ent.BeginDate).ToList();
            entries.AddRange((_sessionRepository.GetSpecialSessionsForConferenceAndChairWithBaseEntryAttributes(accountId, conferenceId) as IEnumerable<BaseEntryEntity>).OrderBy(ent => ent.BeginDate));
            entries = entries.OrderBy(ent => ent.BeginDate).ToList();
            return new ConferenceScheduleModel()
            {
                Conference = conference,
                Entries = entries,
                Person = person
            };
        }

        public byte[] GetConferenceScheduleICal(int accountId, int conferenceId)
        {
            var entries = (_sessionRepository.GetSessionsForConferenceAndChairWithBaseEntryAttributes(accountId, conferenceId) as IEnumerable<BaseEntryEntity>).OrderBy(ent => ent.BeginDate).ToList();
            entries.AddRange((_sessionRepository.GetSpecialSessionsForConferenceAndChairWithBaseEntryAttributes(accountId, conferenceId) as IEnumerable<BaseEntryEntity>).OrderBy(ent => ent.BeginDate));
            entries = entries.OrderBy(ent => ent.BeginDate).ToList();

            var calendar = new Ical.Net.Calendar();
            foreach (var entry in entries)
            {
                calendar.Events.Add(new CalendarEvent
                {
                    Class = "PUBLIC",
                    Summary = (entry.GetType() == typeof(SessionDTO) ? "Session " : "Special session ") + entry.Title,
                    Created = new CalDateTime(DateTime.Now),
                    Description = entry.GetType() == typeof(SessionDTO) ? ((SessionDTO)entry).Description : ((SpecialSessionDTO)entry).Description,
                    Start = new CalDateTime(Convert.ToDateTime(entry.BeginDate)),
                    End = new CalDateTime(Convert.ToDateTime(entry.EndDate)),
                    Sequence = 0,
                    Uid = Guid.NewGuid().ToString(),
                    Location = entry.BuildingName + " r:" + entry.RoomCode,
                });
            }
            var serializer = new CalendarSerializer(new SerializationContext());
            var serializedCalendar = serializer.SerializeToString(calendar);
            return Encoding.UTF8.GetBytes(serializedCalendar);
        }
    }
}
