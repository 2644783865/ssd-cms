using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BE.DTO
{
    public class BaseTimeEntity
    {
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }

        public string Title { get; set; }

    }
}
