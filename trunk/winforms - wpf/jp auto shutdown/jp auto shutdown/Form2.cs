using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jp_auto_shutdown
{
    public partial class Form2 : Form
    {
        private int mHor;
        private int mMin;
        private int mSeg;

        public int horas {
            get {
                return mHor;
            }
            set {
                mHor = value;
            }
        }
        public int minutos {
            get {
                return mMin;
            }
            set {
                mMin = value;
            }
        }
        public int segundos {
            get {
                return mSeg;
            }
            set {
                mSeg = value;
            }
        }
        public Form2()
        {
            InitializeComponent();
            mHor = 0;
            mMin = 30;
            mSeg = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            mHor =(int) numH.Value;
            mMin = (int)numM.Value;
            mSeg = (int)numSeg.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}