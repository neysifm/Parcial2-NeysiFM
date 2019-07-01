using Parcial2_NeysiFM.UI.Consultas;
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

        private void MetroTile6_Click(object sender, EventArgs e)
        {
            ConsultaEstudiante ConEst = new ConsultaEstudiante();
            ConEst.ShowDialog();
        }

        private void MetroTile5_Click(object sender, EventArgs e)
        {
            ConsultaAsignatura ConAsig = new ConsultaAsignatura();
            ConAsig.ShowDialog();
        }

        private void MetroTile4_Click(object sender, EventArgs e)
        {
            ConsultaIncripcion ConIns = new ConsultaIncripcion();
            ConIns.ShowDialog();
        }
    }
}
