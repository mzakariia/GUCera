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
    public partial class EnrolInCourse : System.Web.UI.Page
    {

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("enrollInCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string i_id = Instr_ID.Text;
            string c_id = C_ID.Text;
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@cid", c_id));
            cmd.Parameters.Add(new SqlParameter("@instr", i_id));
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Enrolled Successfully");
              
            conn.Close();



        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}