using System;
using System.Collections;
using System.Configuration;
using System.Data.SQLite;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class finRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink1.Visible = false;
        string user = Request["user"];
        string hash = Request["clave"];
        string claveFija = "papasFritas";
        if (String.IsNullOrEmpty(user) && string.IsNullOrEmpty(hash))
        {
            Response.Redirect("login.aspx");
        }
        else { 
            if (hash == Encriptacion.convertirMD5(user + claveFija))
            {
                //clave valida
                SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
                con.Open();
                SQLiteCommand command = new SQLiteCommand("select username,mailvalido from usuarios where username=@username", con);
                command.Parameters.AddWithValue("@username", user);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader[0].ToString() != "")//existe el usuario
                {
                    if (Convert.ToInt32( reader[1].ToString())== 0)
                    {
                        command = new SQLiteCommand("update usuarios set mailvalido=1 where username=@name",con);
                        command.Parameters.AddWithValue("@name", user);
                        command.ExecuteNonQuery();
                        lblMensaje.Text = "Tu cuenta ha sido validada correctamente";
                        HyperLink1.Visible = true;
                    }
                    else {
                        lblMensaje.Text = "Tu mail ya ha sido validado previamente";
                    }
                }
                else
                {
                    lblMensaje.Text = "El usuario "+user +" no existe en la base de datos";
                }
                con.Close();
            }
            else {
                lblMensaje.Text = "Ha ocurrido un error al intentar validar tu e-mail.";
            }
            
        }
    }
}
