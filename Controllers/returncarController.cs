using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Car_Rental_Project.Models;
using System.Data.Entity.SqlServer;
using System.Data.Entity;

namespace Car_Rental_Project.Controllers
{
   
    public class returncarController : Controller
    {
        SuperCarEntities1 db = new SuperCarEntities1();
        // GET: returncar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(returncar recar)
        {

            if(ModelState.IsValid)
            {
                db.returncars.Add(recar);
                db.SaveChanges();
                var car =db.CarRegs.SingleOrDefault(e => e.CarNo==recar.CarNo);

                if (car == null)
                    return HttpNotFound("CarNo not Found");
                car.Available = "yes";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");  
                

            }
            return View(recar);
        }




        [HttpPost]
        public ActionResult Getid(string CarNo)
        {
            var carn = (from s in db.Rentals
                        where s.CarId == CarNo

                        select new
                        {
                            StartDate = s.sDate,
                            EndDate = s.sDate,
                            CustId = s.CustId,
                            CarNo = s.CarId,
                            Fee = s.Fee,
                            ElapsedDays = SqlFunctions.DateDiff("day",DateTime.Now, s.eDate)
                        }).ToArray();

            return Json(carn,JsonRequestBehavior.AllowGet);
        }

    }
}