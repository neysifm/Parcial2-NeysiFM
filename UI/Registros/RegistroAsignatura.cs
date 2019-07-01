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

namespace Parcial2_NeysiFM.UI.Registros
{
    public partial class RegistroAsignatura : MetroFramework.Forms.MetroForm, IFormularioRegistro<Asignaturas>
    {
        public RegistroAsignatura()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            throw new NotImplementedException();
        }

        public void LlenaCampos(Asignaturas obj)
        {
            throw new NotImplementedException();
        }

        public Asignaturas LlenaClase()
        {
            throw new NotImplementedException();
        }

        public bool ValidarBuscar()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCampos()
        {
            throw new NotImplementedException();
        }

        public bool ValidarEliminar()
        {
            throw new NotImplementedException();
        }

        public bool ValidarGuardar()
        {
            throw new NotImplementedException();
        }

        public bool ValidarModificar()
        {
            throw new NotImplementedException();
        }

        private void RegistroAsignatura_Load(object sender, EventArgs e)
        {

        }
    }
}
