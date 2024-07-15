using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IGraficasIES
{
    internal interface IEmpleadoPublico
    {
        //                                              *********************************************
        //                                              ********** PROPIEDADES DE INTERFAZ **********

        public enum TipoSeguro : uint
        {
            SeguridadSocial = 1,
            Muface = 2
        }
        public TipoSeguro SeguroMedico
        { get; set; }


        //                                              *****************************************
        //                                              ********** MÉTODOS DE INTERFAZ **********

        public (int anyos, int meses, int dias) TiempoServicio();

        public int GetSexenios();

        public int GetTrienios();
    }
}
