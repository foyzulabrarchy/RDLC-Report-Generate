using JoinReport.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JoinReport.DAL
{
    public class FilterDataDAL
    {
        public DataTable filter(int id)
        //public int Add(string _name, string _phone, string _designation)
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

                    SqlCommand cmd = new SqlCommand("SP_Join_Data_Filter", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                   

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    HttpContext.Current.Session["report data"] = dt;
                    

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