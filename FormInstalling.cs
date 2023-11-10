using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirixUpdater
{
    public partial class FormInstalling : Form
    {
        public ProgressBar InstallingProgressBar
        {
            get { return progressBar1; }
            set { progressBar1 = value; }
        }

        public TextBox InstallingTextBox
        {
            get { return textBox1; }
            set { textBox1 = value; }
        }

        public FormInstalling()
        {
            InitializeComponent();

        } // end constructor

    } // end class FormInstalling

} // end namespace
