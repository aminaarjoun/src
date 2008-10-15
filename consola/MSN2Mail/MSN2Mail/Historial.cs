using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;



namespace MSN2Mail
{
    public class Historial
    {
        public static void GuardarMensaje(DateTime fecha,string username,string apodo,string mensaje) {

            using (SQLiteConnection con = new SQLiteConnection("data source=hist.db3")) {
                con.Open();
                SQLiteCommand command = new SQLiteCommand("insert into mensajes values(@fecha,@user,@apodo,@mensaje);",con);
                command.Parameters.AddWithValue("@fecha",fecha);
                command.Parameters.AddWithValue("@user", username);
                command.Parameters.AddWithValue("@apodo", apodo);
                command.Parameters.AddWithValue("@mensaje", mensaje);

                command.ExecuteNonQuery();

            }
            
        }
    }
}
