using JoinReport.DAL;
using JoinReport.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoinReport.Controllers
{
    public class JoinReportController : Controller
    {
        BasicUtilities basicUtilities = new BasicUtilities();
        GetDesDAL getDesDAL = new GetDesDAL();
        GetReportDataDAL getReportDataDAL = new GetReportDataDAL();
        FilterDataDAL filterDataDAL = new FilterDataDAL();
        DataTable dataTable = new DataTable();

        // GET: JoinReport
        public ActionResult Index()
        {
            //login check
    
            if(Session["login"] == null)
            {
                return Redirect("/UserLogin/Index");
            }
            else { 


            //        
            List<Dictionary<string, object>> _list = new List<Dictionary<string, object>>();

            dataTable = getDesDAL.GetData();
            _list = basicUtilities.GetTableRows(dataTable);
            ViewBag.Data = _list;
            return View();
            }
        }

        [HttpPost]
        public JsonResult drop(int dropdownDes)
        {
            try
            {
                if (dropdownDes <0 )
                {
                    dataTable = getReportDataDAL.GetData();
                    Session["report_data"] = dataTable;
                    return Json(true);
                }
                else
                {
                    dataTable = filterDataDAL.filter(dropdownDes);

                    Session["report_data"] = dataTable;
                    return Json(true);
                }
               
            }
            catch (Exception)
            {
                return Json(false);
            }
        }


    }
}