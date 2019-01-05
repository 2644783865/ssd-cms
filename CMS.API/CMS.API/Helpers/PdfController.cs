using CMS.BE.Models.Program;
using CMS.BE.Models.Session;
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

        public byte[] GetPresentersList(PresentersListModel presentersList)
        {
            var view = new ViewAsPdf(presentersList)
            {
                FileName = $"List of presenters for {(presentersList.Session==null ? presentersList.SpecialSession.Title : presentersList.Session.Title)}.pdf",
                PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 }
            };
            return view.BuildFile(ControllerContext);
        }
    }
}