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
    public partial class ViewFeedback : System.Web.UI.Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
        static SqlConnection conn = new SqlConnection(connStr);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Show(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int cid = Int16.Parse(txt_course_id.Text);

            cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));

            conn.Open();

            // number,comment ,numberOfLikes

            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (sdr.Read())
            {
                string number = sdr.GetInt32(sdr.GetOrdinal("number")).ToString();
                Label lbl_number = new Label();
                lbl_number.Text = number;
                form1.Controls.Add(lbl_number);

                string comment = sdr.GetString(sdr.GetOrdinal("comment"));
                Label lbl_comment = new Label();
                lbl_comment.Text = comment;
                form1.Controls.Add(lbl_comment);

                string number_of_likes = sdr.GetInt32(sdr.GetOrdinal("numberOfLikes")).ToString();
                Label lbl_nlikes = new Label();
                lbl_nlikes.Text = number_of_likes;
                form1.Controls.Add(lbl_nlikes);

            }
        }
    }
}