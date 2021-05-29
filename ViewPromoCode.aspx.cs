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
    public partial class ViewPromoCode : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("viewPromocode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            //Read row by row
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String code = rdr.GetString(rdr.GetOrdinal("code"));
                Label codelabel = new Label();
                Label codelabel1 = new Label();
                codelabel1.Text = "Code: ";
                codelabel.Text = code + " ";
                form1.Controls.Add(codelabel1);
                form1.Controls.Add(codelabel);
                DateTime issue = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                Label issuelabel = new Label();
                Label issuelabel1 = new Label();
                issuelabel.Text = issue.ToString()+" ";
                issuelabel1.Text = "Issue Data: ";
                form1.Controls.Add(issuelabel1);
                form1.Controls.Add(issuelabel);
                DateTime expire = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                Label expirelabel = new Label();
                Label expirelabel1 = new Label();
                expirelabel.Text = expire.ToString() + " ";
                expirelabel1.Text = "Expiry Data: ";
                form1.Controls.Add(expirelabel1);
                form1.Controls.Add(expirelabel);
                Decimal dis = rdr.GetDecimal(rdr.GetOrdinal("discount"));
                Label dislabel = new Label();
                Label dislabel1 = new Label();
                dislabel.Text = dis + " ";
                dislabel1.Text = "Discount: ";
                form1.Controls.Add(dislabel1);
                form1.Controls.Add(dislabel);
                int ad = rdr.GetInt32(rdr.GetOrdinal("adminId"));
                Label adlabel = new Label();
                Label adlabel1 = new Label();
                adlabel.Text = ad.ToString() + " ";
                adlabel1.Text = "AdminID: ";
                form1.Controls.Add(adlabel1);
                form1.Controls.Add(adlabel);
            }

        }
    }
}