using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public class ProfesorInterino : Profesor
    {
        //Constructor al que se le pasan los datos de nombre apellidos y edad y usa métodos de construcción heredados del constructor base
        public ProfesorInterino(string sNombre, string sApellidos, int iEdad) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
        }
        //Constructor al que se le pasan los datos de nombre apellidos, edad, y tipo de funcionarioy  usa métodos de construcción heredados del constructor base
        public ProfesorInterino(string sNombre, string sApellidos, int iEdad, string sMateria, TipoFuncionario tipoProfesor) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SMateria = sMateria;
            SEmail = FormatoMail();
            TipoProfesor = tipoProfesor;
        }
        //Método de sallida por consola de profersor interino, heredada de Profesor
        public override string toString()
        {
            return toStringProfesor();
        }
    }
}
