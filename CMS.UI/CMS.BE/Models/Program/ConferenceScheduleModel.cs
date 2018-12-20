using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BE.Models.Program
{
    public class ConferenceScheduleModel
    {
        public ConferenceDTO Conference { get; set; }
        public AccountDTO Person { get; set; }
        public List<BaseTimeEntity> Entries { get; set; } = new List<BaseTimeEntity>();
    }
}
