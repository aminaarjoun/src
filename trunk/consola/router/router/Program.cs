using System;
using System.Collections.Generic;
using System.Text;
using WatiN.Core;
using WatiN.Core.DialogHandlers;
using System.Threading;
namespace router
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IE ie = new IE("http://192.168.0.1/pppoestatus.htm");
            LogonDialogHandler dhdlLogon = new LogonDialogHandler("admin", "password");
            ie.AddDialogHandler(dhdlLogon);
            ie.GoTo("http://192.168.0.1/pppoestatus.htm");
            Console.WriteLine("Desconecto...");
            ie.Button(Find.ByValue(" Disconnect ")).Click();
            Thread.Sleep(10000);
            //ie.GoTo("http://192.168.0.1/pppoestatus.htm");
            Console.WriteLine("Conecto...");
            ie.Button(Find.ByValue(" Connect ")).Click();
            ie.Dispose();
        }
    }
}
