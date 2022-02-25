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
    public partial class showcase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdvertisedShowcases();
            HiddenShowcases();
        }

        private void AdvertisedShowcases()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "SELECT * FROM ShowCases WHERE ShowType=@type";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@type", "1");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rpt1.DataSource = dt;
            rpt1.DataBind();
            conn.Close();
        }

        private void HiddenShowcases()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "SELECT * FROM ShowCases WHERE ShowType=@type";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@type", "0");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rpt2.DataSource = dt;
            rpt2.DataBind();
            conn.Close();
        }
    }
}