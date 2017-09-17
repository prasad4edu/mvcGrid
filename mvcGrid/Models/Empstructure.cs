using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcGrid.Models
{
    public class Empstructure
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public int EmpAge { get; set; }
        public string EmpAddress { get; set; }
    }
}