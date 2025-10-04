using System;
using System.Net;
using PromoWeb.Negocio;

namespace PromoWeb.Web
{
    public partial class Contact : System.Web.UI.Page
    {
        
        private const string DestinoContacto = "promotpweb@gmail.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOk.Visible = false;
            lblError.Visible = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                var nombre = (txtNombre.Text ?? "").Trim();
                var email = (txtEmail.Text ?? "").Trim();
                var mensaje = (txtMensaje.Text ?? "").Trim();

                var asunto = $"[Contacto] {nombre}";
                var cuerpo = $@"
                    <p><b>Nombre:</b> {WebUtility.HtmlEncode(nombre)}</p>
                    <p><b>Email:</b> {WebUtility.HtmlEncode(email)}</p>
                    <p><b>Mensaje:</b><br/>{WebUtility.HtmlEncode(mensaje).Replace("\n", "<br/>")}</p>";

                
                EmailHelper.EnviarCorreo(DestinoContacto, asunto, cuerpo, replyTo: email);

                lblOk.Text = "¡Gracias! Tu mensaje fue enviado correctamente.";
                lblOk.Visible = true;

                txtNombre.Text = txtEmail.Text = txtMensaje.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblError.Text = "No pudimos enviar tu mensaje: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
