using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AssManager(object sender, EventArgs e)
        {
            Response.Redirect("AssManagerR.aspx");
        }
        protected void Repsentative(object sender, EventArgs e)
        {
            Response.Redirect("RepsentativeR.aspx");
        }
        protected void Stadium(object sender, EventArgs e)
        {
            Response.Redirect("StadiumR.aspx");
        }
        protected void Fan(object sender, EventArgs e)
        {
            Response.Redirect("FanR.aspx");
        }
    }
}