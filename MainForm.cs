using Parcial2_NeysiFM.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_NeysiFM
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MetroTile1_Click(object sender, EventArgs e)
        {
            RegistroEstudiantes Rest = new RegistroEstudiantes();
            Rest.ShowDialog();
        }

        private void MetroTile2_Click(object sender, EventArgs e)
        {
            RegistroAsignatura Rasg = new RegistroAsignatura();
            Rasg.ShowDialog();
        }

        private void MetroTile3_Click(object sender, EventArgs e)
        {
            RegistroIncripciones Rins = new RegistroIncripciones();
            Rins.ShowDialog();
        }
    }
}
