using System;

namespace _2HerenciaSimpleIES
{
    //descripción de la clase alumno que hereda de persona con sus parámetros nombre, apellidos, edad, email y nº de expediente con sus getter y setter
    public class Alumno : Persona , IEquatable<Alumno>
    {
        //Se declaran los atributos propios de Alumno ue hereda de Persona
        private string nif;
        public string Nif
        {
            get { return nif; }
            set { nif= value; }
        }

        private int iNumeroExpediente;
        //Constructor vacío
        public Alumno()
        {
        }
        //Constructor al que se le pasan los datos de nombre apellidos y edad y usa métodos de construcción heredados del constructor base
        public Alumno(string sNombre, string sApellidos, int iEdad) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
        }
        //Constructor al que se le pasan los datos de nombre apellidos, dead, número de expediente y usa métodos de construcción heredados del constructor base
        public Alumno(string sNombre, string sApellidos, int iEdad, int iNumeroExpediente) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            INumeroExpediente = iNumeroExpediente;
            SEmail = FormatoMail();
        }
        //Método que hace el formato especial del objeto alumno
        public virtual string FormatoMailAlumno()
        {
            string sSalida = "a";
            int iAnyoActual = DateTime.Now.Year % 100;
            iAnyoActual.ToString();
            string[] aApellidos = SApellidos.TrimEnd().Split(' ');

            if (aApellidos.Length < 2)
            {
                sSalida += aApellidos[0].Substring(0, 2).ToLower() + aApellidos[0].Substring(0, 2).ToLower();
            }
            else
            {
                sSalida += aApellidos[0].Substring(0, 2).ToLower() + aApellidos[1].Substring(0, 2).ToLower();
            }

            sSalida += SNombre.Substring(0, 2).ToLower() + iAnyoActual + "@tras.com";

            return sSalida;
        }
        // Sobrecargar el método FormatoMail en la clase Alumno
        public virtual string FormatoMail()
        {
            return FormatoMailAlumno();
        }
        public int INumeroExpediente { 
            get { return iNumeroExpediente; } 
            set { iNumeroExpediente = value; } 
        }

        public bool Equals(Alumno? other)
        {
            throw new NotImplementedException();
        }
        // Método para controlar la salida por consola de la información del objeto alumno
        public string toString()
        {
 
            string sSalida = base.toString()+INumeroExpediente.ToString().PadRight(5);
            return sSalida;
        }
    }
}
