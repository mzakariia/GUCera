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
    public partial class AddFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void Submit(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string Comment = comment.Text;
            string c_id = cid.Text;

            SqlCommand cmd = new SqlCommand("addFeedback", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@comment", Comment));
            cmd.Parameters.Add(new SqlParameter("@cid", c_id));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Write("Submitted Successfully");
        }
    }
}