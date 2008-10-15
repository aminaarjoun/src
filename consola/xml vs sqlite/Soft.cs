using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using xml_vs_sqlite.Properties;
namespace xml_vs_sqlite
{

    class Soft
    {
        DateTime d;
        List<Cliente> clientes = null;
        Resultados r = new Resultados();
        DateTime fechaComienzo;

        public Soft() {
            StreamReader reader = new StreamReader("saludo.jpt", System.Text.Encoding.GetEncoding("iso-8859-1"));
            Console.Write(reader.ReadToEnd());
            Console.ReadLine();
            fechaComienzo = DateTime.Now;
            int[] cantidades = new int[5];
            cantidades[0] = Settings.Default.cantClientes1;
            cantidades[1] = Settings.Default.cantClientes2;
            cantidades[2] = Settings.Default.cantClientes3;
            cantidades[3] = Settings.Default.cantClientes4;
            cantidades[4] = Settings.Default.cantClientes5;

            for(int i=0;i<5;i++){
                Console.WriteLine("\n\nETAPA {1}: {0} Clientes",cantidades[i],i+1);
                d = DateTime.Now;
                Console.Write("\nCreando Clientes en memoria...");
                clientes = DatosDePrueba.GenerarClientes(cantidades[i]);
                Console.WriteLine("OK ({0})\n", DateTime.Now - d);
                Console.WriteLine("\n---XML---\n");
                d = DateTime.Now;
                SerializarXML(cantidades[i],i);
                DeserializarXML(cantidades[i], i);
                Console.WriteLine("\n---SQLite---\n");
                SerializarSQL(cantidades[i], i);
                DeserializarSQL(cantidades[i], i);
                GuardarResultados();
            }
            GenerarReporte();
            Console.ReadLine();
        
        }
        private void GenerarReporte()
        {
            
        }
        private void GuardarResultados() {
            try
            {
                /*XmlSerializer serializer = new XmlSerializer(typeof(Resultados));
                TextWriter writer = new StreamWriter(fechaComienzo.ToString("ddMMyy_hhmmss") + ".xml");
                serializer.Serialize(writer, r);
                writer.Close();*/

                XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<int,TimeSpan>));
                TextWriter writer = new StreamWriter("aver.xml");
                Dictionary<int, TimeSpan> d = new Dictionary<int, TimeSpan>();
                d.Add(1, new TimeSpan());
                serializer.Serialize(writer, d);
                writer.Close();
            }
            catch (Exception ex) {
                int a = 5;
            }
        }
        private void SerializarSQL(int cantidad, int etapa)
        {

            Console.Write("Guardando en Disco...");
            d = DateTime.Now;
            GuardarDatosSQL(cantidad.ToString() + "registros.db");
            r.TiemposGuardadoSQL.Add(cantidad,DateTime.Now - d);
            Console.WriteLine("OK ({0})", r.TiemposGuardadoSQL[cantidad]);
            FileInfo f = new FileInfo(cantidad.ToString() + "registros.db");
            r.TamañosArchivosSQL[cantidad] = f.Length;
            Console.WriteLine("Tamaño del archivo: {0}", convTamaño(f.Length));
        }

        private void SerializarXML(int cantidad, int etapa)
        {
            Console.Write("Guardando en Disco...");
            GuardarDatosXML(cantidad.ToString() + "registros.xml");
            r.TiemposGuardadoXML.Add(cantidad, DateTime.Now - d);
            Console.WriteLine("OK ({0})", r.TiemposGuardadoXML[cantidad]);
            FileInfo f = new FileInfo(cantidad.ToString() + "registros.xml");
            r.TamañosArchivosXML.Add(cantidad, f.Length);
            Console.WriteLine("Tamaño del archivo: {0}", convTamaño(f.Length));
        }
        private void DeserializarXML(int cantidad, int etapa)
        {
            Console.Write("Recuperando registros...");
            clientes = new List<Cliente>();
            d = DateTime.Now;
            clientes = RecuperarDatosXML(cantidad.ToString() + "registros.xml");
            r.TiemposRecuperacionXML.Add(cantidad,DateTime.Now - d);
            Console.WriteLine("OK ({0})", r.TiemposRecuperacionXML[cantidad]);
        }
        private void DeserializarSQL(int cantidad, int etapa)
        {
            Console.Write("Recuperando registros...");
            clientes = new List<Cliente>();
            d = DateTime.Now;
            clientes = RecuperarDatosSQL(cantidad.ToString() + "registros.db");
            r.TiemposRecuperacionSQL.Add(cantidad,DateTime.Now - d);
            Console.WriteLine("OK ({0})", r.TiemposRecuperacionSQL[cantidad]);
        }
        private List<Cliente> RecuperarDatosSQL(string bd)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=" + bd))
            {
                con.Open();
                SQLiteCommand comAutos = new SQLiteCommand("select * from autos", con);
                SQLiteDataReader readerAutos = comAutos.ExecuteReader();
                while (readerAutos.Read())
                {
                    Auto a = new Auto();
                    a.Matricula = (string)readerAutos["matricula"];
                    a.Marca = (string)readerAutos["marca"];
                    a.Modelo = (string)readerAutos["modelo"];

                    Cliente c = new Cliente();
                    c.Id = (long)readerAutos["idcliente"];

                    if (clientes.Contains(c))
                    {
                        if (c.Autos == null)
                        {
                            List<Auto> autos = new List<Auto>();
                            c.Autos = autos;
                        }
                        c.Autos.Add(a);
                    }
                    else
                    {
                        SQLiteCommand comClientes = new SQLiteCommand("select * from clientes where idcliente=@idcliente", con);
                        comClientes.Parameters.AddWithValue("@idcliente", c.Id);
                        SQLiteDataReader readerClientes = comClientes.ExecuteReader();
                        readerClientes.Read();
                        c.Nombre = (string)readerClientes["nombre"];
                        c.Apellido = (string)readerClientes["apellido"];
                        c.Autos = new List<Auto>();
                        c.Autos.Add(a);
                        clientes.Add(c);
                    }
                }

            }
            return clientes;
        }
        private List<Cliente> RecuperarDatosXML(string archivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = null;
            try
            {
                fs = new FileStream(archivo, FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("error al cargar los datos");
            }
            List<Cliente> clientes = new List<Cliente>();
            if (fs != null)
            {
                XmlReader reader = XmlReader.Create(fs);
                clientes = (List<Cliente>)serializer.Deserialize(reader);
                fs.Close();
            }
            return clientes;
        }

        private void GuardarDatosXML(string nombre)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            TextWriter writer = new StreamWriter(nombre);
            serializer.Serialize(writer, clientes);
            writer.Close();
        }


        private void GuardarDatosSQL(string bd)
        {
            if (File.Exists(bd))
            {
                File.Delete(bd);
            }
            using (SQLiteConnection con = new SQLiteConnection("data source=" + bd))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    SQLiteCommand command = new SQLiteCommand("create table clientes(idcliente INTEGER primary key,nombre TEXT not null,apellido TEXT not null);", con);
                    command.ExecuteNonQuery();
                    command = new SQLiteCommand("create table autos(matricula TEXT,marca TEXT,modelo TEXT,idcliente INTEGER);", con);
                    command.ExecuteNonQuery();

                    for (int i = 0; i < clientes.Count; i++)
                    {
                        command = new SQLiteCommand("insert into clientes values(@id,@nombre,@apellido);", con);
                        command.Parameters.AddWithValue("@id", clientes[i].Id);
                        command.Parameters.AddWithValue("@nombre", clientes[i].Nombre);
                        command.Parameters.AddWithValue("@apellido", clientes[i].Apellido);
                        command.ExecuteNonQuery();

                        for (int j = 0; j < clientes[i].Autos.Count; j++)
                        {
                            command = new SQLiteCommand("insert into autos values(@matricula,@marca,@modelo,@idcliente)", con);
                            command.Parameters.AddWithValue("@matricula", clientes[i].Autos[j].Matricula);
                            command.Parameters.AddWithValue("@marca", clientes[i].Autos[j].Marca);
                            command.Parameters.AddWithValue("@modelo", clientes[i].Autos[j].Modelo);
                            command.Parameters.AddWithValue("@idcliente", clientes[i].Id);
                            command.ExecuteNonQuery();
                        }
                    }


                    transaction.Commit();
                }
            }


        }
        private String convTamaño(long tam)
        {
            String ret = "";
            double val = tam;
            if (tam > 1024 * 1024 * 1024)
            {
                val = (val / (1024 * 1024 * 1024));
                val = Math.Round(val, 2);
                ret += val;
                ret += " Gb";
            }
            else
            {
                if (tam > 1024 * 1024)
                {
                    val = (val / (1024 * 1024));
                    val = Math.Round(val, 2);
                    ret += val;
                    ret += " Mb";
                }
                else
                {
                    if (tam > 1024)
                    {
                        val = val / 1024;
                        val = Math.Round(val, 2);
                        ret += val;
                        ret += " Kb";
                    }
                    else
                    {
                        ret += val;
                        ret += " bytes";
                    }
                }
            }
            return ret;
        }


    }
}