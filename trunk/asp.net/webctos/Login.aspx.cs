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
using System.Data.SQLite;

public partial class Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["action"] == "signout")
        {
            Session.RemoveAll();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (SignIn())
        {
            if (Session["redirigir"] != null)
            {
                string url =(string) Session["redirigir"];
                Response.Redirect(url);
            }
            else {
                Response.Redirect("ctos/Contactos.aspx");    
            }
        }
    }
    private bool SignIn() {
        SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("select id,username,mailvalido from usuarios where username=@username and pass=@pass",con);
        command.Parameters.AddWithValue("@username", txtUser.Text);
        command.Parameters.AddWithValue("@pass",Encriptacion.convertirMD5( txtPass.Text));
        SQLiteDataReader reader= command.ExecuteReader();
        
        if (reader[0].ToString() != "")
        {
            if (Convert.ToInt32(reader[2].ToString()) == 1)
            {
                Session["idusuario"] =reader[0].ToString(); 
                Session["nombreusuario"]=reader[0].ToString();
                con.Close();
                return true;
            }
            else {
                lblError.Text = "mail no comprobado aún.";
                con.Close();
                return false;
            }
        }
        else {
            lblError.Text = "Datos inválidos";
            con.Close();
            return false;
        }
    }
}
