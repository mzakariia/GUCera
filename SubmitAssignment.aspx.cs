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
    public partial class SubmitAssignment : System.Web.UI.Page
    {

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("submitAssign", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string ass_type = AssType.SelectedItem.Value;
            string ass_num = AssNum.Text;
            string c_id = Cid.Text;

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@assignType", ass_type));
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@assignnumber", ass_num));
            cmd.Parameters.Add(new SqlParameter("@cid", c_id));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Write("Submitted Successfully");

        }
    }
    }