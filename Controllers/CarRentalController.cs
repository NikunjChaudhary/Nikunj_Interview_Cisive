using Nikunj_Interview_Cisive.Models;
using Nikunj_Interview_Cisive.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nikunj_Interview_Cisive.Controllers
{
    public class CarRentalController : Controller
    {
        public readonly ICarRentalRepository iCarRentalRepository;
        public CarRentalController()
        {
            iCarRentalRepository = new CarRentalRepository();
        }

        // GET: CarRental
        public ActionResult CarRegistration()
        {
            ViewBag.Result = null;
            return View();
        }

        [HttpPost]
        public ActionResult CarRegistration(CarDetails oDetail)
        {
            if (ModelState.IsValid)
            {
                string isSaved = saveImage(oDetail);
                if (isSaved == "1")
                    ViewBag.Result = iCarRentalRepository.CarResigtration(oDetail);
                else
                    ViewBag.Result = isSaved;
            }

            return View();

        }

        public string saveImage(CarDetails oDetail)
        {
            string isSaved = "";
            try
            {
                string FileName = Path.GetFileNameWithoutExtension(oDetail.CarImageFile.FileName);
                string FileExtension = Path.GetExtension(oDetail.CarImageFile.FileName);

                if (FileExtension.ToString() == ".jpeg" || FileExtension.ToString() == ".jpg" || FileExtension.ToString() == ".png")
                {
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    oDetail.CarImagePath = Server.MapPath("~/CarImages/") + FileName;
                    oDetail.CarImageFile.SaveAs(oDetail.CarImagePath);
                    isSaved = "1";
                }
                else
                    isSaved = "File format not supported.";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSaved;
        }


        public ActionResult CarRentingRequest()
        {
            ViewBag.Result = null;
            return View();
        }

        [HttpPost]
        public ActionResult CarRentingRequest(CarRentingRequest oReq)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = iCarRentalRepository.CarRentingRequest(oReq);
            }
            return View();
        }


        public ActionResult CarReturnRequest()
        {
            ViewBag.Result = null;
            return View();
        }

        [HttpPost]
        public ActionResult CarReturnRequest(Car_Base oReq)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = iCarRentalRepository.CarReturnRequest(oReq);
            }
            return View();
        }

        public ActionResult CarDeRegistration()
        {
            ViewBag.Result = null;
            return View();
        }

        [HttpPost]
        public ActionResult CarDeRegistration(Car_Base oReq)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = iCarRentalRepository.CarDeRegistration(oReq);
            }
            return View();
        }

    }
}