using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace MyOCR
{
    class Email
    {
        public static void EnviarEmail()
        {
  
            //var fromAddress = new MailAddress("erik.fernandess@hotmail.com", "Erik");
            //var toAddress = new MailAddress("erik.fernandess@hotmail.com", "Destinatário");
            //const string fromPassword = "";
            //const string subject = "Assunto do Email";
            //const string body = "Conteúdo do Email";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.hotmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //};
            //smtp.Send(message);
            //Console.WriteLine("Email enviado com sucesso!");



            for (int tentativa = 0; tentativa < 10; tentativa++)
            {
                Console.WriteLine("Errou");
                tentativa --;
            }
            Console.WriteLine("acertou");

        }
    }
}
