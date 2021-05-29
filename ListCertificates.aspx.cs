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
    public partial class ListCertificates : System.Web.UI.Page
    {
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void List (object sender, EventArgs e)

        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("viewCertificate", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            //To read the input from the user
            string c_id = cid.Text;

            //Executing the SQLCommand
            conn.Open();

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@cid", c_id));

            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CourseID = rdr.GetInt32(rdr.GetOrdinal("cid")).ToString();
                Label cidtxt = new Label();
                Label cid = new Label();
                cidtxt.Text = "Course ID:";
                cid.Text = " " + CourseID + " ";
                form1.Controls.Add(cidtxt);
                form1.Controls.Add(cid);

                String IssueDate = rdr.GetDateTime(rdr.GetOrdinal("IssueDate")).ToString();
                Label Datetxt = new Label();
                Label Date = new Label();
                Datetxt.Text = "Issue Date:";
                Date.Text = " " + IssueDate + " ";
                form1.Controls.Add(Datetxt);
                form1.Controls.Add(Date);

            }
            }
    }
}