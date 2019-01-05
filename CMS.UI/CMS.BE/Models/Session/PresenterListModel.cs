using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.BE.Models.Session
{
    public class PresentersListModel
    {
        public SessionDTO Session { get; set; }
        public SpecialSessionDTO SpecialSession { get; set; }
        public List<AccountDTO> Presenters { get; set; }
    }
}
