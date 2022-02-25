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
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_Users();
        }

        private void Show_Users()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Profile ORDER BY Role, FullName", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rpt1.DataSource = dt;
            rpt1.DataBind();
            conn.Close();
        }

        protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RoleChange")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = "UPDATE Profile SET Role=@role WHERE UserID=@uid";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@uid", id);
                cmd.Parameters.AddWithValue("@role", RoleChange(id));
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("users.aspx");
            }
        }

        private string RoleChange(int thisId)
        {
            string newRole;
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT Role FROM Profile WHERE UserID=@uid", conn);
            cmd.Parameters.AddWithValue("@uid", thisId);
            conn.Open();
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            newRole = Convert.ToString(rdr["Role"]) == "Admin" ? "User" : "Admin";
            rdr.Close();
            conn.Close();
            return newRole;
        }
    }
}