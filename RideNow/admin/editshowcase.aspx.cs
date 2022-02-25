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
    public partial class editshowcase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Keys.Count == 0)
            {
                lblError.Text = "You must first select a showcase for editing. Please <a href='showinfo.aspx'>go here</a> and select a showcase.";
            }
            else if (!String.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                lblError.Text = "";
                Show_ShowcaseInfo();
                if (!IsPostBack)
                {
                    Populate();
                }
            }
            else
            {
                lblError.Text = "You must first select a showcase for editing. Please <a href='showinfo.aspx'>go here</a> and select a showcase.";
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "DELETE FROM ShowCases WHERE ShowID=@sid";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@sid", Request.QueryString["id"].ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("showinfo.aspx");
        }

        protected void UpdateShowcase_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "UPDATE ShowCases SET ShortDescr=@shortdescr, LongDescr=@longdescr, BrandName=@brandname, ShowType=@salestype WHERE ShowID=@sid";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@shortdescr", shortdescr.Value);
            cmd.Parameters.AddWithValue("@longdescr", longdescr.Value);
            cmd.Parameters.AddWithValue("@brandname", brandname.Value);
            cmd.Parameters.AddWithValue("@salestype", showtype.Value);
            cmd.Parameters.AddWithValue("@sid", Request.QueryString["id"].ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("editshowcase.aspx?id=" + Request.QueryString["id"].ToString());
        }

        private void Show_ShowcaseInfo()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "SELECT * FROM ShowCases WHERE ShowID=@sid";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@sid", Request.QueryString["id"].ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rpt1.DataSource = dt;
            rpt1.DataBind();
            conn.Close();
        }

        private void Populate()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string strSql = "SELECT * FROM ShowCases WHERE ShowID=@sid";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddWithValue("@sid", Request.QueryString["id"].ToString());
            conn.Open();
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            brandname.Value = rdr["BrandName"].ToString();
            shortdescr.Value = rdr["ShortDescr"].ToString();
            longdescr.Value = rdr["LongDescr"].ToString();
            showtype.Value = rdr["ShowType"].ToString();
            rdr.Close();
            conn.Close();
        }
    }
}