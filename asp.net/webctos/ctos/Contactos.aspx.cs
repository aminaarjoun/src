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
using System.Collections.Generic;
using System.Data.SQLite;

public partial class ctos_Contactos : System.Web.UI.Page
{
    private int editandoContacto;
    private List<Contacto> listaContactos;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idusuario"] == null)
        {
            Session["redirigir"] = "ctos/Contactos.aspx";
            Response.Redirect("../Login.aspx");
        }
        else
        {
            //if (!IsPostBack)
            //{
                listaContactos = new List<Contacto>();
                SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("select nombre,apellido,email,celular,telcasa,teltrabajo,calidad,id from contactos where idusuario=@myid order by nombre", con);
                comm.Parameters.AddWithValue("@myid", ((string)Session["idusuario"]));
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    listaContactos.Add(new Contacto((string)reader[0], (string)reader[1],
                        (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[5],
                        Convert.ToInt32(reader[6]), (string)reader[7]));
                }
                con.Close();

                grdContactos.DataSource = listaContactos;

                grdContactos.DataBind();
            //}
        }
    }

    protected void borrandoFila(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void editandoFila(object sender, GridViewEditEventArgs e)
    {
        Contacto c = listaContactos[e.NewEditIndex];
        lblTituloTabla.Text = "Editar contacto";
        btnAgregar.Text = "Actualizar";
        txtNombre.Text = c.nombre;
        txtApellido.Text = c.apellido;
        txtEmail.Text = c.email;
        txtCelular.Text = c.celular;
        txtTelTrab.Text = c.telTrabajo;
        txtCasa.Text = c.telCasa;
        dropCalidad.SelectedValue = c.calidad.ToString();
        Session.Add("editandoContacto", c);
    }
    protected void alOrdenar(object sender, GridViewSortEventArgs e)
    {
        
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (btnAgregar.Text == "Agregar")
        {
            AgregarContacto();
        }
        else {
            EditarContacto();
        }
        Response.Redirect("contactos.aspx");
    }

    private void EditarContacto() {

        Contacto c = (Contacto)Session["editandoContacto"];
        SQLiteConnection con = new SQLiteConnection("data source=|DataDirectory|contactos");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("update contactos set nombre=@nombre,apellido=@apellido,email=@email,celular=@cel,telcasa=@tel,teltrabajo=@teltrab,calidad=@cal where id=@id", con);
        command.Parameters.AddWithValue("@nombre", txtNombre.Text);
        command.Parameters.AddWithValue("@apellido", txtApellido.Text);
        command.Parameters.AddWithValue("@email", txtEmail.Text);
        command.Parameters.AddWithValue("@cel", txtCelular.Text);
        command.Parameters.AddWithValue("@tel", txtCasa.Text);
        command.Parameters.AddWithValue("@teltrab", txtTelTrab.Text);
        command.Parameters.AddWithValue("@cal",Convert.ToInt32( dropCalidad.SelectedValue));
        command.Parameters.AddWithValue("@id", c.getIdContacto());
        command.ExecuteNonQuery();
        con.Close();

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
    private void limpiarControles()
    {
        btnAgregar.Text = "Agregar";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtEmail.Text = "";
        txtCelular.Text = "";
        txtCasa.Text = "";
        txtTelTrab.Text = "";
        dropCalidad.SelectedIndex = 0;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("contactos.aspx");
    }
}
