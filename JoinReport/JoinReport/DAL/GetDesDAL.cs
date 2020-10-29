using JoinReport.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JoinReport.DAL
{
    public class GetDesDAL
    {
        public DataTable GetData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
                {
                    if (con.State == 0)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SP_emp_des", con);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);

                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}