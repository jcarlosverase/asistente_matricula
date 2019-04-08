namespace WCF_NotificacionService
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;

    public class Mail
    {
        private MailMessage mail;
        private Attachment attachment;
        private string Correo = string.Empty;
        private string Contrasenia = string.Empty;
        private string strHost = string.Empty;
        private int intPort = 0;

        public Mail() { }

        public Mail(string strHost, string Correo, string Contrasenia, int intPort = 587, string DisplayName = null)
        {
            this.strHost = strHost;
            this.Correo = Correo;
            this.Contrasenia = Contrasenia;
            this.intPort = intPort;
            mail = new MailMessage();
            if (DisplayName != null && DisplayName.Trim().Length != 0)
                mail.From = new MailAddress(Correo, DisplayName.Trim());
            else
                mail.From = new MailAddress(Correo);
        }

        /// <summary>
        /// Datos que el receptor visualizara
        /// </summary>
        /// <param name="CorreoReceptor">Correo del receptor </param>
        /// <param name="Asunto">Asunto</param>
        /// <param name="Mensaje">Mensaje</param>
        public void ValorDelReceptor(string CorreoReceptor, string Asunto, string Mensaje)
        {
            mail.To.Add(CorreoReceptor);
            mail.Subject = Asunto;
            mail.Body = Mensaje;
            mail.IsBodyHtml = true;
        }
        
        public void AgregarArchivoByte(byte[] value, string NombreArchivo)
        {
            if (value == null)
                return;
            this.attachment = new Attachment((Stream)new MemoryStream(value), NombreArchivo);
            ContentDisposition contentDisposition = this.attachment.ContentDisposition;
            contentDisposition.CreationDate = DateTime.Now;
            contentDisposition.ModificationDate = DateTime.Now;
            contentDisposition.DispositionType = DispositionTypeNames.Attachment;
            this.mail.Attachments.Add(this.attachment);
        }
        /// <summary>
        /// Envía email
        /// </summary>
        public void EnviarEmail()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = strHost;
            smtp.Port = intPort;
            smtp.Credentials = new NetworkCredential(Correo, Contrasenia);
            smtp.EnableSsl = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors){ return true; };
            smtp.Send(mail);
            if (attachment != null) { attachment.Dispose(); }
            smtp.Dispose();
            mail.Dispose();
        }
    }
}