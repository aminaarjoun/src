using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Diagnostics;
namespace LinkSucker2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkSucker 2.0");
            while (true)
            {

                Console.WriteLine();
                Console.Write("\nIngresá la url: ");
                string url = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Procesando página...");

                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    HttpWebResponse response =(HttpWebResponse) request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string html = reader.ReadToEnd();
                    MatchCollection mc = Regex.Matches(html, "\"http://www.megaupload.com/.*?\"", RegexOptions.IgnoreCase);
                    string nombreFile=DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".txt";
                    StreamWriter writer = new StreamWriter(nombreFile,true);
                    foreach (Match m in mc)
                    {
                        writer.WriteLine(m.Value.Substring(1, m.Value.Length - 2));
                    }
                    writer.Close();
                    Console.Write("OK");
                    Process.Start(nombreFile);

                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
