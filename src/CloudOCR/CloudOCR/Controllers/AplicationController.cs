using CloudOCR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CloudOCR.Controllers
{
    public class AplicationController : Controller
    {
        //
        // GET: /Aplication/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aplicacion()
        {
            return View();
        }

        public ActionResult editUser()
        {
            return View();
        }

        public ActionResult FileUpload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            if (file != null)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                PicturesViewModel newRecord = new PicturesViewModel();
                newRecord.flName = ImageName;
                newRecord.url = physicalPath;
                db.PicturesSet.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../Aplication/Aplicacion/");
        }

    }

}