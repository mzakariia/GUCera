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
    public partial class ViewAssignments : System.Web.UI.Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
        static SqlConnection conn = new SqlConnection(connStr);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Show(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int cid = Int16.Parse(txt_course_id.Text);

            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (sdr.Read())
            {
                string sid = sdr.GetInt32(sdr.GetOrdinal("sid")).ToString();
                Label lbl_sid = new Label();
                lbl_sid.Text = sid;
                form1.Controls.Add(lbl_sid);

                Label lbl_cid = new Label();
                lbl_cid.Text = cid.ToString();
                form1.Controls.Add(lbl_cid);

                string anumber = sdr.GetInt32(sdr.GetOrdinal("assignmentNumber")).ToString();
                Label lbl_anumber = new Label();
                lbl_anumber.Text = anumber;
                form1.Controls.Add(lbl_anumber);

                string atype = sdr.GetString(sdr.GetOrdinal("assignmenttype"));
                Label lbl_atype = new Label();
                lbl_atype.Text = atype;
                form1.Controls.Add(lbl_atype);

                string grade;
                if (sdr.IsDBNull(sdr.GetOrdinal("grade")))
                {
                    grade = "Not yet graded";
                }
                else
                {
                    grade = sdr.GetDecimal(sdr.GetOrdinal("grade")).ToString();
                }
                Label lbl_grade = new Label();
                lbl_grade.Text = grade;
                form1.Controls.Add(lbl_grade);
            }
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx"); 
        }
    }
}