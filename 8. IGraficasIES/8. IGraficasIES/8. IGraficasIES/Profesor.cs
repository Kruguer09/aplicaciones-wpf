using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IGraficasIES
{
    public abstract class Profesor : Persona
    {
        //                                              ******************************************
        //                                              ********** PROPIEDADES DE CLASE **********

        private string materia;

        public string Materia
        {
            get { return materia; }
            set { materia = FormatoNombre(value); }
        }

        public enum TipoFuncionario : uint
        {
            Interino = 1,
            En_Practicas = 2,
            De_Carrera = 3
        }
        public TipoFuncionario TipoProfesor
             { get; set; }


        //                                              ********************************************
        //                                              ********** CONSTRUCTORES DE CLASE **********

        public Profesor(string nombre, string apellidos, uint edad)
            : base(nombre, apellidos, edad) { }

        public Profesor(string nombre, string apellidos, uint edad, string foto)
            : base(nombre, apellidos, edad, foto) { }

        //                                              **************************************
        //                                              ********** MÉTODOS DE CLASE **********

        public abstract string ToString();
        
        public string ToStringProfesor() => base.ToString() + materia.PadRight(15) + Convert.ToString(TipoProfesor).PadRight(15);
    }
}
