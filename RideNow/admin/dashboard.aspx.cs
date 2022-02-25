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
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_Dashboard();
        }

        private void Show_Dashboard()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [RentCars] ORDER BY FullName, CarName", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                lblError.Text = "There is no rental activity on record.";
            }
            else
            {
              rpt1.DataSource = dt;
              rpt1.DataBind();
            }
            conn.Close();
        }
    }
}