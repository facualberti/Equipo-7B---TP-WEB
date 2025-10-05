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

        static bool CBool(string k, bool def = false)
            => bool.TryParse(System.Configuration.ConfigurationManager.AppSettings[k], out var b) ? b : def;

        static int CInt(string k, int def)
            => int.TryParse(System.Configuration.ConfigurationManager.AppSettings[k], out var n) ? n : def;

        public static void EnviarCorreo(string para, string asunto, string html, string replyTo = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var host = C("SmtpHost");
            var port = CInt("SmtpPort", 587);
            var user = C("SmtpUser");
            var pass = C("SmtpPassword");
            var from = C("SmtpFrom");
            var fromName = C("SmtpFromName");
            var useSsl = CBool("SmtpEnableSsl", true);
            var timeoutMs = CInt("SmtpTimeout", 15000);

            // Si usás Gmail, el From debe coincidir con el usuario.
            if (user.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) &&
                !from.Equals(user, StringComparison.OrdinalIgnoreCase))
            {
                from = user;
            }

            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(from, fromName, Encoding.UTF8);
                msg.To.Add(para);
                if (!string.IsNullOrWhiteSpace(replyTo))
                    msg.ReplyToList.Add(new MailAddress(replyTo));

                msg.Subject = asunto;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Body = html;

                // Fallback de texto plano simple
                var plain = StripTags(html);
                var altPlain = AlternateView.CreateAlternateViewFromString(plain, Encoding.UTF8, "text/plain");
                var altHtml = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, "text/html");
                msg.AlternateViews.Add(altPlain);
                msg.AlternateViews.Add(altHtml);

                using (var smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = useSsl;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(user, pass);
                    smtp.Timeout = timeoutMs;

                    smtp.Send(msg);
                }
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

        static string StripTags(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;
            var sb = new StringBuilder(html.Length);
            bool inside = false;
            foreach (var ch in html)
            {
                if (ch == '<') { inside = true; continue; }
                if (ch == '>') { inside = false; continue; }
                if (!inside) sb.Append(ch);
            }
            return WebUtility.HtmlDecode(sb.ToString())
                .Replace("\r", "").Replace("\n", " ")
                .Replace("  ", " ").Trim();
        }
    }
}
