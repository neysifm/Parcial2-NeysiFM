using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.BLL
{
    public interface IFormularioRegistro <T>
    {
        bool ValidarCampos();
        bool ValidarBuscar();
        bool ValidarEliminar();
        bool ValidarGuardar();
        bool ValidarModificar();
        void LimpiarCampos();
        T LlenaClase();
        void LlenaCampos(T obj);
    }
}
