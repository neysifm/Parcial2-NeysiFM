using Parcial2_NeysiFM.BLL;
using Parcial2_NeysiFM.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_NeysiFM.UI.Consultas
{
    public partial class ConsultaAsignatura : MetroFramework.Forms.MetroForm
    {
        public ConsultaAsignatura()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var Lista = new List<Asignaturas>(); 
            RepositorioBase<Asignaturas> contexto = new RepositorioBase<Asignaturas>();

            if (CriteriometroTextBox.Text.Trim().Length > 0)
            {
                try
                {
                    switch (FiltrometroComboBox.SelectedIndex)
                    {
                        // Filtrar Todo
                        case 0:
                            Lista = contexto.GetList(N => true); 
                            break;
                        // Filtrar por ID
                        case 1:
                            int ID = Convert.ToInt32(CriteriometroTextBox.Text);
                            Lista = contexto.GetList(X => X.AsignaturaId == ID);
                            break;
                        // Filtrar por Descripcion
                        case 2:
                            Lista = contexto.GetList(N => N.Descripcion.Contains(CriteriometroTextBox.Text));
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                Lista = contexto.GetList(X => true); 
            }
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = Lista;
        }

        private void BuscarmetroButton_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
