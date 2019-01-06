using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.BE.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.API.Controllers
{
    public class WebController : Controller
    {
        private IConferenceBLL _bll = new ConferenceBLL();
        public ActionResult ConferenceProgram(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var model = _bll.GetConferenceProgram(id.Value);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult Conferences()
        {
            var conferences = _bll.GetConferences();
            var model = new ConferencesModel()
            {
                Conferences = new List<BE.DTO.ConferenceDTO>()
            };
            if (conferences != null) model.Conferences = conferences.ToList(); 

            return View(model);
        }
    }
}