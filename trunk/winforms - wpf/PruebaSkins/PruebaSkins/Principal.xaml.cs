using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PruebaSkins.Properties;
using System.IO;
using System.Windows.Markup;
namespace PruebaSkins
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.skin = cboSkin.SelectedItem.ToString();
            Settings.nombre = txtNombre.Text;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombre.Text = Settings.nombre;
            cboSkin.Items.Add("No usar");
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory+@"\Skins");
            foreach (FileInfo f in di.GetFiles()) {
                cboSkin.Items.Add(f.Name);
            }
            cboSkin.SelectedItem = Settings.skin;

            if (Settings.skin != "No usar") {
                ResourceDictionary rd = null;
                using (FileStream fs = new FileStream(@"Skins\" + Settings.skin , FileMode.Open, FileAccess.Read))
                {
                    rd = (ResourceDictionary)XamlReader.Load(fs);
                }
                Application.Current.Resources = rd;    
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.skin = cboSkin.SelectedItem.ToString();
            Settings.nombre = txtNombre.Text;
        }

        private void cboSkin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboSkin.SelectedItem.ToString() != "No usar")
            {
                ResourceDictionary rd = null;
                using (FileStream fs = new FileStream(@"Skins\" + cboSkin.SelectedItem.ToString(), FileMode.Open, FileAccess.Read))
                {
                    rd = (ResourceDictionary)XamlReader.Load(fs);
                }
                Application.Current.Resources = rd;
            }
            else {

                Application.Current.Resources = null;
            }
        }

        
    }
}
