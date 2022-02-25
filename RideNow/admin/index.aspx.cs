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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            Show_Slider();
            OurBrands();
            ShowCar_Advertised();
        }

        private void OurBrands()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT BrandName FROM Cars ORDER BY BrandName", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rptBrands.DataSource = dt;
            rptBrands.DataBind();
            conn.Close();

        }

        private void Show_Slider()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM ShowCases WHERE ShowType=@type";
            cmd.Parameters.AddWithValue("@type", "1");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rpt.DataSource = dt;
                rpt.DataBind();
            }
            else
            {
                lblError.Text = " Please go to the <a href='editshowcase.aspx'>Edit Showcase</a> page to select a showcase to become active. ";
            }
            conn.Close();
        }

        private void ShowCar_Advertised()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Cars WHERE ShowType=@type";
            cmd.Parameters.AddWithValue("@type", "1");
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
                lblError.Text = " Please return soon to view our latest advertised specials! ";
            }
            conn.Close();
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
            amount = Convert.ToInt32(rdr["Amt"]);
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