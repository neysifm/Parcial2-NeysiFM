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
    public partial class ConsultaIncripcion : MetroFramework.Forms.MetroForm
    {
       public ConsultaIncripcion()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            var Lista = new List<Inscripciones>();
            RepositorioInscripcion contexto = new RepositorioInscripcion();

            if (CriteriometroTextBox.Text.Trim().Length > 0)
            {
                try
                {
                    switch (FiltrometroComboBox.SelectedIndex)
                    {
                        // Filtrar Todo
                        case 0:
                            Lista = contexto.GetList(I => true);
                            break;
                        // Filtrar Por IncripcionID
                        case 1:
                            int id = Convert.ToInt32(CriteriometroTextBox.Text);
                            Lista = contexto.GetList(I => I.InscripcionId == id);
                            break;
                        // Filtrar Por EstudianteID
                        case 2:
                            int id2 = Convert.ToInt32(CriteriometroTextBox.Text);
                            Lista = contexto.GetList(I => I.EstudianteId == id2);
                            break;

                    }
                    Lista = Lista.Where(E => E.Fecha >= DesdemetroDateTime.Value.Date && E.Fecha <= HastametroDateTime.Value.Date).ToList();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                Lista = contexto.GetList(p => true);
            }
            Lista = Lista.Where(E => E.Fecha >= DesdemetroDateTime.Value.Date  && E.Fecha <= HastametroDateTime.Value.Date ).ToList();

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = Lista;
        }

        private void BuscarmetroButton_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
