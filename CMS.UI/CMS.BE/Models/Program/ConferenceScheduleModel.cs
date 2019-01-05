using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.BE.Models.Program
{
    public class ConferenceScheduleModel
    {
        public ConferenceDTO Conference { get; set; }
        public AccountDTO Person { get; set; }
        public List<BaseEntryEntity> Entries { get; set; } = new List<BaseEntryEntity>();
    }
}
