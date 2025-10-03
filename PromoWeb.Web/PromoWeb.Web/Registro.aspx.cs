using System;
using PromoWeb.Negocio;
using PromoWeb.Dominio;

namespace PromoWeb.Web
{
    public partial class Registro : System.Web.UI.Page
    {
        private readonly ClienteNegocio _clientes = new ClienteNegocio();
        private readonly VoucherNegocio _vouchers = new VoucherNegocio();

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

            var cli = _clientes.ObtenerPorDni(dni);
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
                txtNombre.Text = txtApellido.Text = txtEmail.Text = "";
                txtDireccion.Text = txtCiudad.Text = txtCP.Text = "";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            lblTyC.Visible = false;

            Page.Validate();
            if (!Page.IsValid) return;

            if (!chkTyC.Checked)
            {
                lblTyC.Text = "Debés aceptar los términos y condiciones.";
                lblTyC.Visible = true;
                return;
            }

            if (Session["CodigoVoucher"] == null || Session["PremioId"] == null)
            {
                Response.Redirect("~/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                var dni = txtDni.Text.Trim();
                var cli = _clientes.ObtenerPorDni(dni) ?? new Cliente();

                cli.DNI = dni;
                cli.Nombre = txtNombre.Text.Trim();
                cli.Apellido = txtApellido.Text.Trim();
                cli.Email = txtEmail.Text.Trim();
                cli.Direccion = txtDireccion.Text.Trim();
                cli.Ciudad = txtCiudad.Text.Trim();
                cli.CP = txtCP.Text.Trim();

                var idCli = _clientes.Guardar(cli);

                var codigo = (string)Session["CodigoVoucher"];
                _vouchers.MarcarParaCliente(codigo, idCli);

                Session["RegistroOk"] = true;
                Response.Redirect("~/Exito.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "No pudimos completar el registro: " + ex.Message;
                lblMsg.Visible = true;
            }
        }
    }
}
