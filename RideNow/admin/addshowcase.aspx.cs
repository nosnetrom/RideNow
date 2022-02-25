using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow.admin
{
    public partial class addshowcase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void AddShowcase_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("/images/");
            if (FileUpload.HasFile)
            {
                FileInfo fi = new FileInfo(FileUpload.FileName);
                if (fi.Extension != ".jpg" && fi.Extension != ".gif" && fi.Extension != ".png")
                {
                    lblError.Text = "Wrong file type used; please try uploading a JPG, GIF or PNG.";
                }
                else
                {
                    lblError.Text = "";
                    string filename = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + FileUpload.FileName;
                    FileUpload.SaveAs(path + filename);
                    string photopath = "/images/" + filename;
                    string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO ShowCases (ShortDescr, LongDescr, BrandName, ShowType, PhotoPath) VALUES (@shortdescr, @longdescr, @brandname, @salestype, @photopath)";
                    cmd.Parameters.AddWithValue("@shortdescr", shortdescr.Value);
                    cmd.Parameters.AddWithValue("@longdescr", longdescr.Value);
                    cmd.Parameters.AddWithValue("@brandname", brandname.Value);
                    cmd.Parameters.AddWithValue("@salestype", salestype.Value);
                    cmd.Parameters.AddWithValue("@photopath", photopath);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("showinfo.aspx");
                }
            }
        }
    }
}