using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PromoWeb.Negocio
{
    public static class EmailHelper
    {
        static string C(string k)
        {
            var v = System.Configuration.ConfigurationManager.AppSettings[k];
            if (string.IsNullOrWhiteSpace(v))
                throw new InvalidOperationException("Falta appSetting '" + k + "' en Web.config.");
            return v;
        }

        public static void EnviarRegistroExitoso(string para, string nombre, string codigoVoucher, string premio)
        {
            // Fuerza TLS 1.2 (requerido por Gmail)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var host = C("SmtpHost");          // smtp.gmail.com
            var portStr = C("SmtpPort");          // 587 (STARTTLS) o 465 (SSL implícito)
            var user = C("SmtpUser");          // promotpweb@gmail.com
            var pass = C("SmtpPassword");      // app password (16 chars sin espacios)
            var from = C("SmtpFrom");          // DEBE ser el mismo que user en Gmail
            var fromName = C("SmtpFromName");

            if (!int.TryParse(portStr, out var port)) port = 587;

            var asunto = "¡Registro exitoso en Promo Ganá!";
            var cuerpo = $@"
                <p>Hola {nombre},</p>
                <p>Tu participación fue registrada correctamente.</p>
                <p><b>Voucher:</b> {codigoVoucher}<br/>
                   <b>Premio elegido:</b> {premio}</p>
                <p>¡Gracias por participar!</p>";

            var msg = new MailMessage
            {
                From = new MailAddress(from, fromName, Encoding.UTF8),
                Subject = asunto,
                Body = cuerpo,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };
            msg.To.Add(para);

            using (var smtp = new SmtpClient(host, port))
            {
                // Para Gmail:
                // - 587 usa STARTTLS (EnableSsl=true)
                // - 465 usa SSL implícito (EnableSsl=true también)
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(user, pass);

                // Opcional, a veces ayuda con STARTTLS en 587
                // smtp.TargetName = "STARTTLS/smtp.gmail.com";

                smtp.Send(msg);
            }
        }
    }
}
