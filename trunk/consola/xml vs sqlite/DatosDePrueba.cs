using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

    public class DatosDePrueba
    {
        private static string RandomString(int size,int min,int max)
        {
            System.Threading.Thread.Sleep(25);
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            int ran;
            for (int i = 0; i < size; i++)
            {
                ran = random.Next(min, max);
                ch = Convert.ToChar(ran);
                ran = random.Next(0, 2);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        private static List<Auto> cargarAutos()
        {
            List<Auto> listaAutos = new List<Auto>();
            using (TextReader reader = new StreamReader("modelos.car")) {
                string linea = reader.ReadLine();
                while (!String.IsNullOrEmpty(linea)) {
                    Auto a = new Auto();
                    a.Marca = linea.Split(',')[0];
                    a.Modelo= linea.Split(',')[1];
                    a.Matricula = GenerarMatricula();
                    listaAutos.Add(a);
                    linea = reader.ReadLine();
                }
            }

            return listaAutos;

            
        }
        private static string GenerarMatricula()
        { 
            string m="S";
            m = m + DatosDePrueba.RandomString(2, 65, 90);
            Random ran = new Random();
            m = m + String.Format("{0:0000}", ran.Next(0, 9999));
            return m;
        }

        public static List<Cliente> GenerarClientes(int cantidad) {
            List<Auto> listaAutos = DatosDePrueba.cargarAutos();
            List<Cliente> clientes = new List<Cliente>();
            string[] nombres = { "ana", "alfonso", "beatriz","bernardo","carla","maria","roberto","juan","pedro","lucia","jose","natalia","lurdes" };
            string[] apellidos = { "blanco", "rodriguez", "martinez", "gomez", "alonso", "barreiro", "vazquez", "garcia", "lopez", "ramirez", "gutierrez", "cruz", "iglesias" };

            Cliente c=null;
            Random r=new Random();
            for (int i = 0;i<cantidad; i++ ) {
                System.Threading.Thread.Sleep(15);
                c = new Cliente();
                c.Id = i;
                
                c.Nombre = nombres[r.Next(0, nombres.Length-1)];
                c.Apellido = apellidos[r.Next(0, apellidos.Length - 1)];
                c.Autos = GenerarAutos(listaAutos);
                clientes.Add(c);

            }
            return clientes;
        }
        private static List<Auto> GenerarAutos(List<Auto> autos)
        {
            int cantidad = new Random().Next(1, 3);
            int indice= new Random().Next(0, autos.Count-4);
            return autos.GetRange(indice, cantidad);
        }
    }


