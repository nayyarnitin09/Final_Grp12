using ProjectTeam12_Latest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeam12_Latest.Controllers
{
    [Authorize(Roles = "Admin,SalesClerk")]
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Sale(int id)
        {
            CarEntities db = new CarEntities();
            CarDetail objCar = new CarDetail();
            objCar = db.CarDetails.Find(id);
            return View(objCar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sale([Bind(Include = "CarId,ListPrice,DiscountPercentage,CostPrice,ListingDate,SellPrice,SellDate,ModelNumber,CustomerName,EngineType,SittingCapacity,Performance,ABS,CompanyId,UsageId")]CarDetail objCar)
        {
            CarEntities db = new CarEntities();
            //CarDetail objCar=new CarDetail
            if (objCar.CustomerName == null)
            {
                ModelState.AddModelError("CustomerName", "Please enter customer name");
            }
            if (objCar.SellPrice == 0)
            {
                ModelState.AddModelError("SellPrice", "Sell Price cannt have zero value");
            }
            if (objCar.SellPrice == null)
            {
                ModelState.AddModelError("SellPrice", "Please enter selling price");
            }
            if (objCar.SellDate == null)
            {
                ModelState.AddModelError("SellDate", "Please enter Selling Date");
            }
            if (objCar.SellPrice != null && objCar.SellPrice != 0 && User.IsInRole("SalesClerk"))
            {
                decimal? value = objCar.SellPrice - (objCar.CurrentPrice() / 2);
                if (value < 0)
                {
                    ModelState.AddModelError("", "User is not authorized to sell item less than 50% of current price");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(objCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "CarDetails");
            }
            else
            {
                return View(objCar);
            }
        }
    }
}