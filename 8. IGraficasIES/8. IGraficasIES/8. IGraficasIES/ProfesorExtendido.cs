using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IGraficasIES
{
    internal class ProfesorExtendido
    {
        //                                              ******************************************
        //                                              ********** PROPIEDADES DE CLASE **********

        public enum ECivil : uint
        {
            Soltero = 1,
            Casado = 2,
            Divorciado = 3,
            Viudo = 4
        }

        public ECivil Estado { get; set; }

        private string email;
        private string Email
        {
            get { return email; } set { email = value; }
        }
        
        public int Peso { get; set; }
        public int Estatura { get; set;}


        //                                              **************************************
        //                                              ********** MÉTODOS DE CLASE **********

        public List<ProfesorExtendido> GetProfeExten()
        {
            List<ProfesorExtendido> listaProfExt = new List<ProfesorExtendido>();

            //listaProfExt.Add();

            return listaProfExt;
        }
    }
}
