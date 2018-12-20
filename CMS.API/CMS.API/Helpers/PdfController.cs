using CMS.BE.Models.Program;
using Rotativa;
using System.Web.Mvc;

namespace CMS.API.Helpers
{
    public class PdfController : Controller
    {
        public byte[] GetProgram(ConferenceProgramModel program)
        {
            var view = new ViewAsPdf(program)
            {
                FileName = $"{program.Conference.Title} Program.pdf",
                PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 }
            };
            return view.BuildFile(ControllerContext);
        }

        public byte[] GetSchedule(ConferenceScheduleModel schedule)
        {
            var view = new ViewAsPdf(schedule)
            {
                FileName = $"{schedule.Conference.Title} Schedule for {schedule.Person.Name}.pdf",
                PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 }
            };
            return view.BuildFile(ControllerContext);
        }
    }
}