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
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

          //  string mobile_number = mobilenumber.Text;
                 
            SqlCommand cmd = new SqlCommand("addCreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            String credit = CreditNumber.Text;
            String name = HolderName.Text;
            String cv = C.Text;
            string exp =
                Exp_Date_Day.Text + "/" +
                Exp_Date_Month.Text + "/" +
                Exp_Date_Year.Text + " " 
                ;
           // SqlParameter deadline_param = new SqlParameter("@deadline", SqlDbType.DateTime);
            
            SqlParameter exp_param = new SqlParameter("@expiryDate", SqlDbType.DateTime);
            exp_param.Value = DateTime.Parse(exp);
            cmd.Parameters.Add(exp_param);

           // exp_param.Value = DateTime.Parse(exp);
          //  cmd.Parameters.Add(deadline_param);
            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@number", credit));
            cmd.Parameters.Add(new SqlParameter("@cardHolderName", name));
        //    cmd.Parameters.Add(new SqlParameter("@expiryDate", exp_param));
            cmd.Parameters.Add(new SqlParameter("@cvv", cv));

            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Added Successfully");
            conn.Close();

        }
    }
}