using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow.admin
{
    public partial class carinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            Show_CarInfo();
        }

        private void Show_CarInfo()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cars WHERE CarID=@cid";
                cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                rpt1.DataSource = dt;
                rpt1.DataBind();
                conn.Close();
            } 
            else
            {
                 // Instructor's code retrieves the top 1 car (order by Descr)
                lblError.Text = "Please return to the <a href='index.aspx'>gallery</a> and pick a specific car.";
                
            }
        }
    }
}