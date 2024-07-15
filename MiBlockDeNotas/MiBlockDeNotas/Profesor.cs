using _2HerenciaSimpleIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    //descripción de la clase profesor que hereda de persona con sus parámetros nombre, apellidos, edad, email y materia con sus getter y setter
    public abstract class Profesor : Persona, IEquatable<Profesor>
    {
        //Atributos específicos de la clase Profesor que hereda de Persona
        private string sMateria;
        public string SMateria {  
            get { return sMateria; } 
            set { sMateria = value; } 
        }
        public enum TipoFuncionario: uint
        {
            Interino=1,
            EnPracticas=2,
            DeCarrera=3
        }
        public TipoFuncionario TipoProfesor {  get; set; }
        //Constructor al que se le pasan los datos de nombre apellidos y edad y usa métodos de construcción heredados del constructor base
        protected Profesor(string sNombre, string sApellidos, int iEdad) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
        }
        public bool Equals(Profesor? other)
        {
            throw new NotImplementedException();
        }
        // Método para controlar la salida por consola de la información del objeto profesor, heredada de persona
        public abstract string toString();
        // Método que añade a la salida las características propias
        public string toStringProfesor()
        {
            //string sTipoProfesor = typeof(TipoFuncionario).Name;
            //string sTipoProfesor=TipoProfesor.GetType().ToString();
            string sSalida = base.toString() + sMateria.PadRight(10) +TipoProfesor.ToString().PadRight(13);
            return sSalida;
        }
    }

    
}
