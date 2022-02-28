using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow.user
{
    public partial class myrent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_MyRent();
        }

        protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Return")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                AvailabilityChange(id);
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "UPDATE TOP(1) RentCars SET isReturned=@isReturn WHERE UserName = @username AND CarID=@carid AND isReturned='0'";
                cmd1.Parameters.AddWithValue("@isReturn", 1);
                cmd1.Parameters.AddWithValue("@username", Session["userName"].ToString());
                cmd1.Parameters.AddWithValue("@carid", id);
                cmd1.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("myrent.aspx");
            }
        }

        private void Show_MyRent()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [RentCars] WHERE UserName=@thisuser", conn);
            cmd.Parameters.AddWithValue("@thisuser", Session["userName"].ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rpt1.DataSource = dt;
                rpt1.DataBind();
            }
            else
            {
                lblError.Text = "You have no rental activity on record.";
            }
            conn.Close();

        }

        private int Availability(int id)
        {
            int amount;
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cars WHERE CarID=@cid", conn);
            cmd.Parameters.AddWithValue("@cid", id);
            conn.Open();
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            amount = Convert.ToInt32(rdr["amt"]);
            rdr.Close();
            conn.Close();
            return amount;
        }

        private string CarName(int id)
        {
            string carname;
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT ModelName FROM Cars WHERE CarID=@cid", conn);
            cmd.Parameters.AddWithValue("@cid", id);
            conn.Open();
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            carname = rdr["ModelName"].ToString();
            rdr.Close();
            conn.Close();
            return carname;
        }

        private bool AvailabilityChange(int id)
        {
            bool success = false;
            int newamount = Availability(id) + 1;
            if (newamount >= 0)
            {
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string sqlString = "UPDATE Cars SET Amt=@amount WHERE CarID=@cid";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@cid", id);
                cmd.Parameters.AddWithValue("@amount", newamount);
                cmd.ExecuteNonQuery();
                conn.Close();
                success = true;
            }
            else
            {
                lblError.Text = "There is a problem with renting this car. Please select another.";
            }
            return success;
        }
    }
}