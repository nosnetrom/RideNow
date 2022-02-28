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
                if (dt.Rows.Count > 0)
                {
                    rpt1.DataSource = dt;
                    rpt1.DataBind();
                }
                else
                {
                    lblError.Text = "That car cannot be found in inventory. Please try again, or contact a system administrator.";
                }
                conn.Close();
            }
            else
            {
                // Instructor's code retrieves the top 1 car (order by Descr)
                lblError.Text = "Please return to the <a href='index.aspx'>gallery</a> and pick a specific car.";

            }
        }

        protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Rent")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (AvailabilityChange(id))
                {
                    string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "INSERT INTO RentCars (UserName, FullName, CarID, CarName, isReturned) VALUES (@username, @fullname, @carid, @carname, @isreturn)";
                    cmd1.Parameters.AddWithValue("@username", Session["userName"].ToString());
                    cmd1.Parameters.AddWithValue("@fullname", Session["FullName"].ToString());
                    cmd1.Parameters.AddWithValue("@carid", id);
                    cmd1.Parameters.AddWithValue("@carname", CarName(id));
                    cmd1.Parameters.AddWithValue("@isreturn", 0);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("myrent.aspx");
                }
            }
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
            int newamount = Availability(id) - 1;
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