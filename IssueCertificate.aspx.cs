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
    public partial class IssueCertificate : System.Web.UI.Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
        static SqlConnection conn = new SqlConnection(connStr);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Issue(object sender, EventArgs e)
        {
            int cid = Int16.Parse(txt_cid.Text);
            int sid = Int16.Parse(txt_sid.Text);
            string deadline =
                txt_issue_day.Text + "/" +
                txt_issue_month.Text + "/" +
                txt_issue_year.Text + " " +
                txt_issue_hour.Text + ":" +
                txt_issue_minute.Text +
                ":00 PM";

            SqlCommand cmd = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@sid", sid));
            cmd.Parameters.Add(new SqlParameter("@insId", Session["user"]));
            SqlParameter issue_param = new SqlParameter("@issueDate", SqlDbType.DateTime);
            issue_param.Value = DateTime.Parse(deadline);
            cmd.Parameters.Add(issue_param);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Write("Certificate added successfully");
        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx");
        }

    }
}