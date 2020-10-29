using JoinReport.DAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoinReport.Report
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReportDataDAL getReportDataDAL = new GetReportDataDAL();
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)(HttpContext.Current.Session["report_data"]);

                ReportViewer1.Enabled = true;
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("../Report/JoinReport.rdlc");
                ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();

            }
        }
    }
}
