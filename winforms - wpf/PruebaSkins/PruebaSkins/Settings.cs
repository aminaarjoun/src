using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace PruebaSkins
{
   public static class Settings
    {
       public static string skin {
           get {
               using (SQLiteConnection con = new SQLiteConnection(@"data source="+Environment.CurrentDirectory+@"\settings.db")) {
                   con.Open();
                   SQLiteCommand command = new SQLiteCommand("select skin from settings", con);
                   return (string)(command.ExecuteScalar());
               }
           }

           set {
               using (SQLiteConnection con = new SQLiteConnection(@"data source=" + Environment.CurrentDirectory + @"\settings.db"))
               {
                   con.Open();
                   SQLiteCommand command = new SQLiteCommand("update settings set skin=@skin", con);
                   command.Parameters.AddWithValue("@skin", value);
                   command.ExecuteNonQuery();
               }
           }
       }

       public static string nombre
       {
           get
           {
               using (SQLiteConnection con = new SQLiteConnection(@"data source=" + Environment.CurrentDirectory + @"\settings.db"))
               {
                   con.Open();
                   SQLiteCommand command = new SQLiteCommand("select nombre from settings", con);
                   return (string)(command.ExecuteScalar());
               }
           }

           set {
               using (SQLiteConnection con = new SQLiteConnection(@"data source=" + Environment.CurrentDirectory + @"\settings.db"))
               {
                   con.Open();
                   SQLiteCommand command = new SQLiteCommand("update settings set nombre=@nombre", con);
                   command.Parameters.AddWithValue("@nombre", value);
                   command.ExecuteNonQuery();
               }
           }
       }
    }
}
