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

        public ActionResult FileUpload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

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

        public ActionResult Upload()
       {
           string fullPath;
                List<string> imgNames;
                if (Session["images"] == null)
                {
                    imgNames = new List<string>();
                }
                else
                {
                    imgNames = (List<string>)Session["images"];
                }
                string name = string.Empty;

                if (Request.Files.Count > 0)
                {
                    List<string> exts = new List<string>();
                    exts.Add(".gif");
                    exts.Add(".jpg");
                    exts.Add(".jpeg");
                    exts.Add(".bmp");
                    var file = Request.Files[0];
                    if (exts.Contains(System.IO.Path.GetExtension(file.FileName).ToLower()))
                    {
                        Random rnd = new Random();
                        name = rnd.Next(111, 9999).ToString() + "_" + System.IO.Path.GetFileName(file.FileName);
                        imgNames.Add(name);
                        fullPath = Path.Combine(Server.MapPath("~/Content/Images"), name);
                        file.SaveAs(fullPath);
                        Session["images"] = imgNames;
                        //return Content(Url.Content(@"~/Content/Images" + fullPath));
                    }
                    else
                    {
                        name = "error";
                    }
            // model.Images = imgNames;
                } 
            return Json(name, JsonRequestBehavior.AllowGet);                 
                //return Content(Url.Content(@"~/Content/Images"));
      }
    }

}