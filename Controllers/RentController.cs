using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Car_Rental_Project.Models;
using System.Data.Entity;

namespace Car_Rental_Project.Controllers
{
    public class RentController : Controller
    {
        SuperCarEntities1 db = new SuperCarEntities1();
        // GET: Rent
        public ActionResult Index()
        {
            var result = (from r in db.Rentals
                          join c in db.CarRegs on r.CarId equals c.CarNo
                          select new RentailViewModel
                          {
                              id = r.id,
                              CarId =r.CarId,
                              CustId =r.CustId,
                              Fee =r.Fee,
                              sDate =r.sDate,
                              eDate =r.eDate,
                              Available = c.Available,



                          }).ToList();
            return View(result);
        }

        [HttpGet]

        public ActionResult GetCar()
        {

            var car = db.CarRegs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Getid(int id)
        {

            var customer = (from s in db.Customers where s.id == id select s.CustName).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Getavil(string CarNo)
        {

            var caravil = (from s in db.CarRegs where s.CarNo == CarNo select s.Available).ToList();
            return Json(caravil, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(Rental rent)
        {

            if(ModelState.IsValid)
            {
                db.Rentals.Add(rent);
                db.SaveChanges();
                var car = db.CarRegs.SingleOrDefault(e=> e.CarNo==rent.CarId);
                if (car == null)
                    return HttpNotFound("CarNo is not valid");

                car.Available = "no";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            return View(rent);  
        }
    }
}