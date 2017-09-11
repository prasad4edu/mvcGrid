using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcGrid.Controllers
{
    public class GridController : Controller
    {
        //
        // GET: /Grid/

        public ActionResult Index()
        {
            
            List<mvcGrid.Models.GridModel> objLstGridModel = new List<Models.GridModel>();
            objLstGridModel.Add(new mvcGrid.Models.GridModel() { EmpId = 1, EmpFirstName = "First", EmpMiddleName = "Middle", EmpLastName = "Last" });
            objLstGridModel.Add(new mvcGrid.Models.GridModel() { EmpId = 2, EmpFirstName = "First", EmpMiddleName = "Middle", EmpLastName = "Last" });
            objLstGridModel.Add(new mvcGrid.Models.GridModel() { EmpId = 3, EmpFirstName = "First", EmpMiddleName = "Middle", EmpLastName = "Last" });
            objLstGridModel.Add(new mvcGrid.Models.GridModel() { EmpId = 4, EmpFirstName = "First", EmpMiddleName = "Middle", EmpLastName = "Last" });
            objLstGridModel.Add(new mvcGrid.Models.GridModel() { EmpId = 5, EmpFirstName = "First", EmpMiddleName = "Middle", EmpLastName = "Last" });
            return View(objLstGridModel);
        }


    }
}
