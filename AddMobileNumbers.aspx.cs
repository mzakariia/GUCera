﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AddMobileNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddMobileNumber(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                string mobile_number = mobilenumber.Text;

                if (mobile_number.Equals(""))
                {
                    Response.Write("Invalid mobile number, please try again.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("addMobile", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", Session["user"]));
                    cmd.Parameters.Add(new SqlParameter("@mobile_number", mobile_number));

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }catch(Exception _)
                    {
                        Response.Write("This mobile number is already registered for this user.");
                    }
                }
            }catch(Exception _)
            {
                Response.Write("Internal server error. Plase try again.");
            }
        }

        protected void Back(object sender, EventArgs e)
        {
            if (Session["type"].Equals("2"))
            {
                Response.Redirect("StudentHome.aspx");
            }
            else if (Session["type"].Equals("1"))
            {
                Response.Redirect("AdminHome.aspx");
            }
            else if (Session["type"].Equals("0"))
            {
                Response.Redirect("InstructorPage.aspx");
            }
        }
    }
}