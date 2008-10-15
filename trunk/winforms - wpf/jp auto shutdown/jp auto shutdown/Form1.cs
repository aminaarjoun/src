using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jp_auto_shutdown
{
    public partial class Form1 : Form
    {

        private int segRestantes;
        private bool cerroDesdeMenu;
        public Form1()
        {
            InitializeComponent();
            segRestantes = 1800;
            cerroDesdeMenu = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled){
                timer1.Enabled = false;
            }

            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.OK) {
                segRestantes = f2.horas * 3600 + f2.minutos * 60 + f2.segundos;
                actualizarReloj();
            }
        }
        private void seg2Date(ref int h, ref int min, ref int seg) {
            int auxRestantes = segRestantes;
                h = (int)auxRestantes / 3600;
                auxRestantes = auxRestantes - h * 3600;
                min = auxRestantes /60;
                auxRestantes = auxRestantes - min * 60;
                seg = auxRestantes;
        }
        private void actualizarReloj() {
            label1.Text = "";
            int horas = 0;
            int minutos = 0;
            int segundos = 0;
            seg2Date(ref horas, ref minutos, ref segundos);

            if (horas < 10)
            {
                label1.Text += "0" + horas.ToString() + ":";
            }
            else {
                label1.Text +=  horas.ToString() + ":";
            }
            if (minutos < 10)
            {
                label1.Text += "0" + minutos.ToString() + "'";
            }
            else {
                label1.Text +=minutos.ToString() + "'";
            }
            if (segundos < 10)
            {
                label1.Text += "0" + segundos.ToString() + "''";
            }
            else {
                label1.Text += segundos.ToString() + "''";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button1.Image = global::jp_auto_shutdown.Properties.Resources.exit3;
            }
            else {
                button1.Image = global::jp_auto_shutdown.Properties.Resources.exit;
            }
           timer1.Enabled = !timer1.Enabled;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segRestantes > 0)
            {
                segRestantes--;
                actualizarReloj();
            }
            else { 
                //apagar!!!
                timer1.Enabled = false;
                System.Diagnostics.Process.Start("ShutDown","/t 0 /s");
            }
        }

        private void onRez(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }


      

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerroDesdeMenu = true;
            this.Close();
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (cerroDesdeMenu)
            {
                notifyIcon1.Visible = false;
            }
            else {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                this.Hide();
            }
            
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.BalloonTipText = label1.Text;
            notifyIcon1.ShowBalloonTip(800);
        }

        private void onDclks(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();

        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
        }

        private void detenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

    }
}