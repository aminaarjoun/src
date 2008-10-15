using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Default3 : System.Web.UI.Page
{
    public List<Contacto> lst;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["lst"] == null)
        {
            lst = new List<Contacto>();
            Contacto cto = new Contacto();
            cto.Nombre = "Ruben";
            cto.Apellido = "Lopez";
            cto.EsHombre = true;
            cto.FechaNacimiento = new DateTime(1980, 4, 23);
            cto.Mail = "rlopez@mail.com";
            cto.Celular = "099012345";

            lst.Add(cto);

            cto = new Contacto();
            cto.Nombre = "Analia";
            cto.Apellido = "Martinez";
            cto.EsHombre = false;
            cto.FechaNacimiento = new DateTime(1985, 2, 8);
            cto.Mail = "apches@gmail.com";
            cto.Celular = "099974124";

            lst.Add(cto);

            Session["lst"] = lst;



        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Contacto c1 = new Contacto();
        c1.Nombre = txtNombre.Text;
        c1.Apellido = txtApellido.Text;
        c1.Celular = txtCel.Text;
        c1.EsHombre = ddlSexo.SelectedValue == "M";
        string[] fechaArr = txtFechaNac.Text.Split('/');

        c1.FechaNacimiento = new DateTime(Convert.ToInt32(fechaArr[2]), Convert.ToInt32(fechaArr[1]), Convert.ToInt32(fechaArr[0]));
        c1.Mail = txtMail.Text;

        List<Contacto> lista = (List<Contacto>)Session["lst"];


        lista.Insert(0, c1);

        Session["lst"] = lista;

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtApellido.Text = "";
        txtCel.Text = "";
        txtFechaNac.Text = "";
        txtMail.Text = "";
        txtNombre.Text = "";
        ddlSexo.SelectedValue = "";

        Server.Transfer("~/Default.aspx");
    }
}
