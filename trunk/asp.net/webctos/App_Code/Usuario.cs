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
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    private string mID;
    private string mNombre;
	public Usuario(string id,string nombre)
	{
        mID = id;
        mNombre = nombre;
	}
    public string id {
        get {
            return mID;
        }
    }
    public string nombre {
        get {
            return mNombre;
        }
    }
}

