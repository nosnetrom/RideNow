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
    public partial class editcar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                lblError.Text = "No car has been selected for editing. Please select a car to edit.";
            }
            else
            {
                Show_CarInfo();
                if (!IsPostBack)
                {
                    Populate();
                }
                
            }
        }

        protected void Populate()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Cars WHERE CarID=@cid";
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"].ToString());
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            modelname.Value = rdr["ModelName"].ToString();
            brandname.Value = rdr["BrandName"].ToString();
            year.Value = rdr["Year"].ToString();
            description.Value = rdr["Descr"].ToString();
            numInStock.Value = rdr["Amt"].ToString();
            salestype.Value = rdr["ShowType"].ToString();
            rdr.Close();
            conn.Close();
        }

        protected void UpdateCar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Cars SET ModelName=@modelname, BrandName=@brandname, Year=@year, Descr=@descr, Amt=@amt, ";
            cmd.CommandText += "ShowType=@salestype WHERE CarID=@cid";
            cmd.Parameters.AddWithValue("@modelname", modelname.Value);
            cmd.Parameters.AddWithValue("@brandname", brandname.Value);
            cmd.Parameters.AddWithValue("@year", year.Value);
            cmd.Parameters.AddWithValue("@descr", description.Value);
            cmd.Parameters.AddWithValue("@amt", numInStock.Value);
            cmd.Parameters.AddWithValue("@salestype", salestype.Value);
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"].ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("editcar.aspx?id=" + Request.QueryString["id"].ToString());
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
                cmd.Parameters.AddWithValue("@cid", Request.QueryString["ID"].ToString());
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
                lblError.Text = "Please return to the previous page and pick a specific car.";

            }
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Cars WHERE CarID=@cid";
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"].ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("~/admin/index");
        }
    }
}