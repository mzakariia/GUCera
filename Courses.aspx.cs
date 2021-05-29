using System;
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
    public partial class Courses : System.Web.UI.Page
    {

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("availableCourses", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            //cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));
            //Read row by row
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                String firstname = rdr.GetString(rdr.GetOrdinal("name"));
                Label cname = new Label();
                Label cnamelabel = new Label();
                cnamelabel.Text = "Course Name: ";
                cname.Text = firstname + " ";
                form1.Controls.Add(cnamelabel);
                form1.Controls.Add(cname);
            }
            }
        }
}