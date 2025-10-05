using System;
using System.Text.RegularExpressions;
using PromoWeb.Negocio;
using PromoWeb.Dominio;

namespace PromoWeb.Web
{
    public partial class Registro : System.Web.UI.Page
    {
        private readonly ClienteNegocio _clientes = new ClienteNegocio();
        private readonly VoucherNegocio _vouchers = new VoucherNegocio();
        private static readonly Regex DniRegex = new Regex(@"^\d{6,8}$", RegexOptions.Compiled);

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

            var dni = (txtDni.Text ?? "").Trim();

            
            if (!DniRegex.IsMatch(dni))
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCiudad.Text = string.Empty;
                txtCP.Text = string.Empty;
                return;
            }

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
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCiudad.Text = string.Empty;
                txtCP.Text = string.Empty;
            }
        }

        protected void valTyC_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = chkTyC.Checked;
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;

            
            Page.Validate("reg");
            if (!Page.IsValid) return;

            
            var dni = (txtDni.Text ?? "").Trim();
            if (!DniRegex.IsMatch(dni))
            {
                lblMsg.Text = "DNI inválido. Usá solo números (6 a 8 dígitos).";
                lblMsg.Visible = true;
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
                var cli = _clientes.ObtenerPorDni(dni) ?? new Cliente { DNI = dni };

                cli.DNI = dni;
                cli.Nombre = (txtNombre.Text ?? "").Trim();
                cli.Apellido = (txtApellido.Text ?? "").Trim();
                cli.Email = (txtEmail.Text ?? "").Trim();
                cli.Direccion = (txtDireccion.Text ?? "").Trim();
                cli.Ciudad = (txtCiudad.Text ?? "").Trim();
                cli.CP = (txtCP.Text ?? "").Trim();

                var idCli = _clientes.Guardar(cli);

                var codigo = (string)Session["CodigoVoucher"];
                _vouchers.MarcarParaCliente(codigo, idCli);

                var premioTexto = "Premio seleccionado: " + (Session["PremioId"]?.ToString() ?? "");
                EmailHelper.EnviarRegistroExitoso(cli.Email, cli.Nombre, codigo, premioTexto);

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
