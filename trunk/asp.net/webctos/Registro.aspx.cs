using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Net.Mail;
public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
        con.Open();
        SQLiteCommand comm = new SQLiteCommand("select username from usuarios where username=@nombre", con);
        comm.Parameters.AddWithValue("@nombre", txtUser.Text);
        SQLiteDataReader reader = comm.ExecuteReader();
        if (reader[0].ToString() == "")
        {
            comm = new SQLiteCommand("insert into usuarios values(@id,@user,@pass,@mail,0)", con);
            comm.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
            comm.Parameters.AddWithValue("@user", txtUser.Text);
            comm.Parameters.AddWithValue("@pass", Encriptacion.convertirMD5(txtPass.Text));
            comm.Parameters.AddWithValue("@mail", txtEmail.Text);
            comm.ExecuteNonQuery();
            enviarMail();
            Response.Redirect("mensajeregistro.aspx");
            
        }
        else {
            lblUsuarioExiste.Text = "El usuario existe.";
        }
        con.Close();
    }
    private void enviarMail() {
        MailAddress from = new MailAddress("softdejp@gmail.com", "Soft de JP");
        MailAddress to = new MailAddress(txtEmail.Text, txtUser.Text);
        MailMessage msg = new MailMessage(from, to);
        msg.Subject = "Confirmacion de mail";
        StringBuilder body = new StringBuilder();
        body.Append("<html>");
        body.Append("<body>");
        body.Append("Gracias por registrarte a nuestro sistema de administración de contactos.<p>");
        body.Append("<u>Datos de cuenta:</u>");
        body.Append("<br><b>usuario: "+txtUser.Text+"<br>contraseña:"+txtPass.Text+"</b><p>");
        body.Append("Para validar tu mail y poder iniciar sesión haz clic ");
        body.Append("<a href=" + '"' + "http://jpblanco/contactos/finRegistro.aspx?user=" + txtUser.Text + "&clave=" + Encriptacion.convertirMD5(txtUser.Text + "papasFritas") + '"' + ">aquí.</a>");
        body.Append("</body>");
        body.Append("</html>");
        msg.Body = body.ToString();
        msg.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        smtp.Credentials = new System.Net.NetworkCredential("softdejp@gmail.com", "autofill");
        smtp.Send(msg);
    }
}
