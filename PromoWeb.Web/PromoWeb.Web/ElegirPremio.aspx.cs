using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PromoWeb.Negocio;
using PromoWeb.Dominio;

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
                    return;
                }

                var data = _neg.ListarPremios();
                if (data.Count == 0)
                {
                    lblMsg.Text = "No hay premios disponibles por el momento.";
                    lblMsg.Visible = true;
                }
                repPremios.DataSource = data;
                repPremios.DataBind();
            }
        }

        protected void repPremios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "elegir")
            {
                Session["PremioId"] = e.CommandArgument.ToString();
                Response.Redirect("~/Registro.aspx", false);
            }
        }

        protected void repPremios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var art = e.Item.DataItem as Articulo;
            if (art == null) return;

            var repThumbs = e.Item.FindControl("repThumbs") as Repeater;
            if (repThumbs != null)
            {
                repThumbs.DataSource = art.Imagenes ?? Enumerable.Empty<string>();
                repThumbs.DataBind();
            }
        }

        protected void repThumbs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var img = e.Item.FindControl("imgThumb") as HtmlImage;
            var urlHid = e.Item.FindControl("hidThumbUrl") as HiddenField;
            if (img == null || urlHid == null) return;

            var url = ResolveUrl(urlHid.Value);

            var outerItem = (RepeaterItem)e.Item.NamingContainer.NamingContainer;
            var hidMain = outerItem.FindControl("hidMainId") as HiddenField;
            var mainId = hidMain != null ? hidMain.Value : "";

            img.Src = url;
            img.Attributes["onclick"] = $"swapImg('{mainId}', '{url}')";
        }
    }
}
