using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Contacto
/// </summary>
public class Contacto
{
    private string mNombre;
    private string mApellido;
    private string mEmail;
    private string mCelular;
    private string mTelCasa;
    private string mTelTrabajo;
    private int mCalidad;
    private string mIdContacto;
	public Contacto(string nombre,string apellido,
        string email,string celular,string telcasa,string teltrabajo,int calidad,string id)
	{
        mNombre = nombre;
        mApellido = apellido;
        mEmail = email;
        mCelular = celular;
        mTelCasa = telcasa;
        mTelTrabajo = teltrabajo;
        mCalidad = calidad;
        mIdContacto = id;
	}
    public string nombre{
        get
        {
            return mNombre;
        }
    }
    public string apellido {
        get {
            return mApellido;
        }
    }
    public string email {
        get {
            return mEmail;
        }
    }
    public string celular {
        get {
            return mCelular;
        }
    }
    public string telCasa {
        get {
            return mTelCasa;
        }
    }
    public string telTrabajo {
        get {
            return mTelTrabajo;
        }
    }
    public int calidad {
        get {
            return mCalidad;
        }
    }

    public string getIdContacto() {
        return mIdContacto;
    }

}
