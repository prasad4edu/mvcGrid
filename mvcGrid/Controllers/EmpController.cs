using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcGrid.Models;

namespace mvcGrid.Controllers
{
    public class EmpController : Controller
    {
        //
        // GET: /Emp/
        EmpBusinessLayer objEmpBusinessLayer = new EmpBusinessLayer();
        public ActionResult EmpList()
        {
            List<Empstructure> EmpList = objEmpBusinessLayer.getAllEmpDetails().ToList();
            return View(EmpList);
        }

        [HttpGet]
        [ActionName("EmpEdit")]
        public ActionResult EmpEdit(string EmpId)
        {
            Empstructure EmpList = objEmpBusinessLayer.getEmpDetails(EmpId);
            return View(EmpList);
        }


        [HttpPost]
        [ActionName("EmpEdit")]
        public ActionResult EmpEdit(Empstructure empStructure)
        {
            if (objEmpBusinessLayer.updateEmpDetails(empStructure) == 1)
                return RedirectToAction("EmpList", "Emp");
            return View();
        }

        public ActionResult EmpDetails(string EmpId)
        {
            Empstructure EmpList = objEmpBusinessLayer.getEmpDetails(EmpId);
            return View(EmpList);
        }

        [HttpGet]
        [ActionName("EmpDelete")]
        public ActionResult EmpDelete()
        {
            
            return View();
        }

        [HttpPost]
        [ActionName("EmpDelete")]
        public ActionResult EmpDelete(string ipEmpId)
        {
            if (objEmpBusinessLayer.deleteEmpDetails(ipEmpId) == 1)
                return RedirectToAction("EmpList", "Emp");
            return View();
        }

        [HttpGet]
        [ActionName("EmpInsert")]
        public ActionResult EmpInsert()
        {
            return View();
        }

        [HttpPost]
        [ActionName("EmpInsert")]
        public ActionResult EmpInsert(Empstructure empStructure)
        {
            if (objEmpBusinessLayer.insertEmpDetails(empStructure) == 1)
                return RedirectToAction("EmpList", "Emp");
            return View();
        }
    }
}
