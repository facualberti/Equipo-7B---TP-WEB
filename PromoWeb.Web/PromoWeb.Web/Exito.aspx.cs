using System;

namespace PromoWeb.Web
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RegistroOk"] == null)
                Response.Redirect("~/Default.aspx", false);
        }
    }
}
