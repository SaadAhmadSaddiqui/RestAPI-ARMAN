using Microsoft.AspNetCore.Mvc;
using RestAPI_ARMAN.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI_ARMAN.Processors
{
    public class AdminProcessor
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4Q6B9N0;Initial Catalog=ARMAN-DB;User ID=sa;Password=dictyt");

        public JsonResult LoginAdmin(string Username, string Password)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    Admin admin = new Admin();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Admins WHERE ((Username = '"+Username+ "') OR (AdminEmail = '" + Username + "')) AND Password = '"+Password+"'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            admin.AdminID = (int)dr.GetValue(0);
                            admin.Username = dr.GetValue(1).ToString();
                            admin.Password = dr.GetValue(2).ToString();
                            admin.AdminName = dr.GetValue(3).ToString();
                            admin.AdminEmail = dr.GetValue(4).ToString();
                        }
                        return new JsonResult(admin);
                    }
                    else
                    {
                        return new JsonResult("Wrong Username or Password!");
                    }

                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
        }
    }
}
