using System;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Summary description for Encriptacion
/// </summary>
public class Encriptacion
{
	public Encriptacion()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    public static string convertirMD5(string texto)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(texto));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}
