using System;
using PromoWeb.Negocio;

namespace PromoWeb.Web
{
    public partial class ElegirPremio : System.Web.UI.Page
    {
        private readonly ArticuloNegocio _neg = new ArticuloNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CodigoVoucher"] == null)
                {
                    Response.Redirect("~/Default.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                var data = _neg.ListarPremios();
                if (data.Count == 0)
                {
                    lblMsg.Text = "No hay premios disponibles por el momento.";
                    lblMsg.Visible = true;
                    repPremios.DataSource = null;
                    repPremios.DataBind();
                    return;
                }

                repPremios.DataSource = data;
                repPremios.DataBind();
            }
        }

        protected void repPremios_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "elegir")
            {
                Session["PremioId"] = e.CommandArgument.ToString();
                Response.Redirect("~/Registro.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}
