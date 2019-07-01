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
    public partial class ConsultaEstudiante : MetroFramework.Forms.MetroForm
    {
        public ConsultaEstudiante()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscar()
        {
            var Lista = new List<Estudiantes>();
            RepositorioBase<Estudiantes> contexto = new RepositorioBase<Estudiantes>();

            if (CriteriometroTextBox.Text.Trim().Length > 0)
            {
                try
                {
                    switch (FiltrometroComboBox.SelectedIndex)
                    {
                        // Filtrar Todo
                        case 0:
                            Lista = contexto.GetList(A => true);
                            break;
                        // Filtrar Por ID
                        case 1:
                            int id = Convert.ToInt32(CriteriometroTextBox.Text);
                            Lista = contexto.GetList(E => E.EstudianteId == id);
                            break;
                        // Filtrar Por Nombres
                        case 2:
                            Lista = contexto.GetList(E => E.Nombres.Contains(CriteriometroTextBox.Text));
                            break;
                    }
                    Lista = Lista.Where(E => E.FechaIngreso >= DesdemetroDateTime.Value.Date && E.FechaIngreso <= HastametroDateTime.Value.Date).ToList();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                Lista = contexto.GetList(p => true);
            }
            Lista = Lista.Where(E => E.FechaIngreso >= DesdemetroDateTime.Value.Date  && E.FechaIngreso <= HastametroDateTime.Value.Date ).ToList();

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = Lista;
        }
    }
}
