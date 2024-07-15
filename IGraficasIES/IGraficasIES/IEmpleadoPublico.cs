using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES
{
    //Interfaz que será implementada en la clase ProfesorFuncionario
    public interface IEmpleadoPublico
    {
        public enum TipoMedico : uint
        {
            SeguridadSocial = 1,
            Muface = 2
        }
        TipoMedico TipoSeguro { get; set; }
        // Método para calcular el tiempo de servicio
        // Devuelve una tupla formada por tres enteros: años, días y meses.
        (int años, int dias, int meses) TiempoDeServicio();

        // Método para obtener los sexenios
        // Devuelve un número entero
        int GetSexenios();

        // Método para obtener los trienios
        // Devuelve un número entero
        int GetTrienios();
    }

}
