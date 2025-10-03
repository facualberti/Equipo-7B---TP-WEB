using System;
using PromoWeb.Negocio;

namespace PromoWeb.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly VoucherNegocio _neg = new VoucherNegocio();

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Page.Validate(); if (!Page.IsValid) return;

            var codigo = txtVoucher.Text.Trim().ToUpper();
            try
            {
                if (_neg.EsValidoDisponible(codigo))
                {
                    Session["CodigoVoucher"] = codigo;
                    Response.Redirect("~/ElegirPremio.aspx", false);
                }
                else
                {
                    Response.Redirect("~/VoucherInvalido.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al validar el voucher: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
