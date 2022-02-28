using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow
{
    public partial class brandcars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_BrandCars();
        }

        private void Show_BrandCars()
        {
            if (string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cars ORDER BY BrandName, ModelName", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    rpt1.DataSource = dt;
                    rpt1.DataBind();
                }
                else
                {
                    lblError.Text = "No cars can be found at this time. Please contact a system administrator.";
                }
                conn.Close();
            }
            else
            {
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cars WHERE BrandName=@id ORDER BY ModelName", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    rpt1.DataSource = dt;
                    rpt1.DataBind();
                }
                else
                {
                    lblError.Text = "No cars for this manufacturer can be found at this time. Please try another brand.";
                }
                conn.Close();
            }
        }

    }
}