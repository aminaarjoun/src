using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using XihSolutions.DotMSN;
using System.Net;
namespace MSN2Mail
{
    class Program
    {
        static void Main(string[] args)
        {
            Prueba p = new Prueba();
            Console.ReadLine();
        }
    }
    public class Prueba{
        private XihSolutions.DotMSN.Messenger messenger;
        private List<Conversation> listaConversaciones;
        private Dictionary<string,DateTime> MsgPorfecha;

        public Prueba() {
            messenger = new XihSolutions.DotMSN.Messenger();
            listaConversaciones = new List<Conversation>();
            MsgPorfecha = new Dictionary<string, DateTime>();

            if (messenger.Connected)
            {
                messenger.Disconnect();
            }
            messenger.Credentials.Account = Properties.Settings.Default.msnUser;
            messenger.Credentials.Password = Properties.Settings.Default.msnPass;
            messenger.Credentials.ClientID = "msmsgs@msnmsgr.com";
            messenger.Credentials.ClientCode = "Q1P7W2E4J9R8U3S5";
            messenger.Nameserver.SignedIn += new EventHandler(Nameserver_SignedIn);
            messenger.Nameserver.SignedOff += new XihSolutions.DotMSN.SignedOffEventHandler(Nameserver_SignedOff);
            messenger.NameserverProcessor.ConnectingException += new XihSolutions.DotMSN.Core.ProcessorExceptionEventHandler(NameserverProcessor_ConnectingException);
            messenger.Nameserver.AuthenticationError += new XihSolutions.DotMSN.Core.HandlerExceptionEventHandler(Nameserver_AuthenticationError);
            messenger.Nameserver.ServerErrorReceived += new XihSolutions.DotMSN.Core.ErrorReceivedEventHandler(Nameserver_ServerErrorReceived);
            messenger.ConversationCreated += new XihSolutions.DotMSN.ConversationCreatedEventHandler(messenger_ConversationCreated);
            messenger.TransferInvitationReceived += new XihSolutions.DotMSN.DataTransfer.MSNSLPInvitationReceivedEventHandler(messenger_TransferInvitationReceived);
            messenger.Connect();
        }

        void messenger_TransferInvitationReceived(object sender, XihSolutions.DotMSN.DataTransfer.MSNSLPInvitationEventArgs e)
        {
            Console.WriteLine("messenger_TransferInvitationReceived");
        }

        void messenger_ConversationCreated(object sender, XihSolutions.DotMSN.ConversationCreatedEventArgs e)
        {
            listaConversaciones.Add(e.Conversation);
            e.Conversation.Switchboard.TextMessageReceived += new TextMessageReceivedEventHandler(Switchboard_TextMessageReceived);
        }

        void Switchboard_TextMessageReceived(object sender, TextMessageEventArgs e)
        {
            Console.WriteLine("Mensaje de {0}: {1}", e.Sender.Name, e.Message.Text,e.Sender.Mail);
            Historial.GuardarMensaje(DateTime.Now, e.Sender.Mail, e.Sender.Name, e.Message.Text);
            DateTime d = DateTime.Now;
            if (MsgPorfecha.ContainsKey(e.Sender.Mail))
            {
                //si el ultimo fue enviado hace mas de 15 mins mando mail
                DateTime fechaEnviado = MsgPorfecha[e.Sender.Mail];
                TimeSpan t= (TimeSpan) (d - fechaEnviado);
                if (t > Properties.Settings.Default.timespan) {
                    enviarMail(e.Sender.Name, e.Message.Text);
                }
            }
            else { 
                //mando mail y agrego en el dictionary
                MsgPorfecha.Add(e.Sender.Mail, d);
                enviarMail(e.Sender.Name,e.Message.Text);
            }
        }

        void Nameserver_ServerErrorReceived(object sender, XihSolutions.DotMSN.MSNErrorEventArgs e)
        {
            Console.WriteLine("Nameserver_ServerErrorReceived");
        }

        void Nameserver_AuthenticationError(object sender, XihSolutions.DotMSN.ExceptionEventArgs e)
        {
            Console.WriteLine("Fallo la autenticación!");
        }
        void NameserverProcessor_ConnectingException(object sender, XihSolutions.DotMSN.ExceptionEventArgs e)
        {
            Console.WriteLine("NameserverProcessor_ConnectingException");
        }

        void Nameserver_SignedOff(object sender, XihSolutions.DotMSN.SignedOffEventArgs e)
        {
            Console.WriteLine("Nameserver_SignedOff");
        }

        void Nameserver_SignedIn(object sender, EventArgs e)
        {
            Console.WriteLine("Conectado");
            messenger.Owner.Status = PresenceStatus.Online;
        }

        private void enviarMail(string strFrom, string strMsg)
        {
        
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("softdejp@gmail.com", "autofill");
      
            MailAddress from = new MailAddress("softdejp@gmail.com", "Soft de JP");
            MailAddress to = new MailAddress(Properties.Settings.Default.mailTo, "para vos");
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "msn im";
            msg.Body = strFrom + ": " + strMsg;
            msg.IsBodyHtml = false;
            
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }




    }
    
}
