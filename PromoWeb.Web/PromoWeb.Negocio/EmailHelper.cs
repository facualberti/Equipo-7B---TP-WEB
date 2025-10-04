using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PromoWeb.Negocio
{
    public static class EmailHelper
    {
        private static string C(string k)
        {
            var v = System.Configuration.ConfigurationManager.AppSettings[k];
            if (string.IsNullOrWhiteSpace(v))
                throw new InvalidOperationException("Falta appSetting '" + k + "' en Web.config.");
            return v;
        }

        public static void EnviarCorreo(string para, string asunto, string html, string replyTo = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var host = C("SmtpHost");
            var port = int.TryParse(C("SmtpPort"), out var p) ? p : 587;
            var user = C("SmtpUser");
            var pass = C("SmtpPassword");
            var from = C("SmtpFrom");
            var fromName = C("SmtpFromName");

            var msg = new MailMessage
            {
                From = new MailAddress(from, fromName, Encoding.UTF8),
                Subject = asunto,
                Body = html,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };
            msg.To.Add(para);
            if (!string.IsNullOrWhiteSpace(replyTo))
                msg.ReplyToList.Add(new MailAddress(replyTo));

            using (var smtp = new SmtpClient(host, port))
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(user, pass);
                smtp.Send(msg);
            }
        }

        public static void EnviarRegistroExitoso(string para, string nombre, string codigoVoucher, string premio)
        {
            var asunto = "¡Registro exitoso en Promo Ganá!";
            var cuerpo = $@"
                <p>Hola {WebUtility.HtmlEncode(nombre)},</p>
                <p>Tu participación fue registrada correctamente.</p>
                <p><b>Voucher:</b> {WebUtility.HtmlEncode(codigoVoucher)}<br/>
                   <b>Premio elegido:</b> {WebUtility.HtmlEncode(premio)}</p>
                <p>¡Gracias por participar!</p>";

            EnviarCorreo(para, asunto, cuerpo);
        }
    }
}
