using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GUCera
{
    public partial class GradeAssignment : System.Web.UI.Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
        static SqlConnection conn = new SqlConnection(connStr);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Grade(Object sender, EventArgs e)
        {
            string sid = txt_sid.Text;
            string cid = txt_cid.Text;
            string anumber = Int16.Parse(txt_anumber.Text).ToString();
            string type = rbl_atype.SelectedItem.Text;
            string grade = double.Parse(txt_grade.Text).ToString();

            SqlCommand cmd = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@sid", sid));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@assignmentNumber", anumber));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@grade", grade));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx");
        }
    }
}