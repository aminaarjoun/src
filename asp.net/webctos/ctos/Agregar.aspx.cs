using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SQLite;

public partial class ctos_Agregar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idusuario"] == null)
        {
            Session["redirigir"] = "ctos/Agregar.aspx";
            Response.Redirect("../Login.aspx");
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        AgregarContacto();
        lblMensaje.Text = txtNombre.Text + " se ha agregado correctamente.";
        limpiarControles();
    }

    private void AgregarContacto()
    {
        SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("insert into contactos values(@id,@idusuario,@nombre,@apellido,@email,@celular,@telcasa,@teltrab,@calidad)", con);
        command.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
        string id = (string)Session["idusuario"];
        command.Parameters.AddWithValue("@idusuario", id);
        command.Parameters.AddWithValue("@nombre", txtNombre.Text);
        command.Parameters.AddWithValue("@apellido", txtApellido.Text);
        command.Parameters.AddWithValue("@email", txtEmail.Text);
        command.Parameters.AddWithValue("@celular", txtCelular.Text);
        command.Parameters.AddWithValue("@telcasa", txtCasa.Text);
        command.Parameters.AddWithValue("@teltrab", txtTelTrab.Text);
        command.Parameters.AddWithValue("@calidad", Convert.ToInt32(dropCalidad.SelectedValue));
        command.ExecuteNonQuery();
        con.Close();
    }
    private void limpiarControles() {
        txtNombre.Text = "";
        txtApellido.Text="";
        txtEmail.Text = "";
        txtCelular.Text = "";
        txtCasa.Text = "";
        txtTelTrab.Text = "";
        dropCalidad.SelectedIndex = 0;


    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        AgregarContacto();
        Response.Redirect("contactos.aspx");
    }
}
