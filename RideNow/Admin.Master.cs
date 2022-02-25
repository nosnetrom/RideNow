using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = Convert.ToString(Session["type"]);
            if (r != "Admin" || String.IsNullOrEmpty(r) || Session["userName"] == null) // 
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void lnkbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/index.aspx");
        }
    }
}