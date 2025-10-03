using System;
using PromoWeb.Negocio;
using PromoWeb.Dominio;

namespace PromoWeb.Web
{
    public partial class Registro : System.Web.UI.Page
    {
        private readonly ClienteNegocio _neg = new ClienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CodigoVoucher"] == null || Session["PremioId"] == null)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Visible = false;

            var dni = txtDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni)) return;

            var cli = _neg.ObtenerPorDni(dni);
            if (cli != null)
            {
                txtNombre.Text = cli.Nombre;
                txtApellido.Text = cli.Apellido;
                txtEmail.Text = cli.Email;
                txtDireccion.Text = cli.Direccion;
                txtCiudad.Text = cli.Ciudad;
                txtCP.Text = cli.CP;
            }
            else
            {
                // limpiar campos si no existe
                txtNombre.Text = txtApellido.Text = txtEmail.Text = "";
                txtDireccion.Text = txtCiudad.Text = txtCP.Text = "";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            // En el próximo paso haremos: validar Page.IsValid, guardar cliente, vincular voucher y mostrar éxito.
            lblMsg.Text = "Falta implementar el guardado (siguiente paso).";
            lblMsg.Visible = true;
        }
    }
}
