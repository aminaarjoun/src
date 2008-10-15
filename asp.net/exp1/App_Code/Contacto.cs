using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Contacto
/// </summary>
public class Contacto
{
    private string _nombre;
    private string _apellido;
    private string _mail;
    private bool _esHombre;
    private string _celular;
    private DateTime _fechaNac;

	public Contacto()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DateTime FechaNacimiento {
        get {
            return _fechaNac;
        }
        set {
            _fechaNac = value;
        }
    }
    public bool EsHombre {
        get {
            return _esHombre;
        }
        set {
            _esHombre = value;
        }
    }
    public string Nombre {
        get {
            return _nombre;
        }
        set {
            _nombre = value;
        }
    }
    public string Apellido {
        get {
            return _apellido;
        }
        set {
            _apellido = value;
        }
    }
    public string Mail {
        get {
            return _mail;
        }
        set {
            _mail = value;
        }
    }

    public string Celular {
        get {
            return _celular;
        }
        set {
            _celular = value;
        }
    }
}
