using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.entity;

namespace MvcCrudTask.Controllers
{
    public class VehicleRegisterationController : Controller
    {
        IVehicleRepository reg = null;
        public VehicleRegisterationController(IVehicleRepository register)
        {
            reg = register;
        }


        // GET: VehicleRegisterationController
        public ActionResult List()
        {
          var vehicleResult=  reg.GetAllVehicleData();
            return View("DisplayDetail",vehicleResult);
        }

        // GET: VehicleRegisterationController/Details/5
        public ActionResult Details(string vehiclename)
        {
            var detail = reg.GetVehicleByName(vehiclename);
            return View("Detail",detail);
        }

        // GET: VehicleRegisterationController/Create
        public ActionResult Create()
        {

            return View("Add",new VehicleDetail());
        }

        // POST: VehicleRegisterationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDetail vehicleDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {

                  var str=  reg.GetVehicleByName(vehicleDetail.vehicleName);
                    if (str!=null)
                    {
                        ModelState.AddModelError("","UserName already exists");
                        return View("Add", new VehicleDetail());
                    }
                    reg.InsertVehicleData(vehicleDetail);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Add", new VehicleDetail());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleRegisterationController/Edit/5
        public ActionResult Edit(string vehicleName)
        {
            
            var updateValue = reg.GetVehicleByName(vehicleName);
            return View("update",updateValue);
        }

        // POST: VehicleRegisterationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleDetail detail)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var str = reg.GetVehicleByName(detail.vehicleName);
                    if (str != null)
                    {
                        ModelState.AddModelError("", "vehicleName already exists");
                        return View("update", detail);
                    }
                    reg.UpdateVehcileDetail(detail);
                    return RedirectToAction(nameof(List));
                }

                else
                {
                    return View("update", detail);
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleRegisterationController/Delete/5
        public ActionResult Delete(string vehicleName)
        {
            
            var DeleteValue = reg.GetVehicleByName(vehicleName);
            return View( DeleteValue);
        }

        // POST: VehicleRegisterationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                reg.deleteVehicleDetail(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
