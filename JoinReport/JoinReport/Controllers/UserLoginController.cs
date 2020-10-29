using JoinReport.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoinReport.Controllers
{
    public class UserLoginController : Controller
    {
        UserLoginDAL userloginDAL = new UserLoginDAL();
        // GET: UserLogin
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Login(string _UName, string _Pass)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = userloginDAL.login(_UName, _Pass);
                if (dataTable.Rows.Count > 0)
                {
                    Session["login"] = 1;
                    return Json(true);
                }
                else
                {

                    return Json(false);
                }

            }
            catch (Exception)
            {

                return Json(false);
            }
        }
    }
}