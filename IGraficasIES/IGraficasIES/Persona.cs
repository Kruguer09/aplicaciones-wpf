using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES
{
    //descripción de la clase persona con sus parámetros nombre, apellidos, edad y email con sus getter y setter
    public class Persona : IEquatable<Persona>
    {
        private string sNombre;
        public string SNombre
        {
            get { return sNombre; }
            set { sNombre = FormatoNombre(value); }
        }
        private string sRutaFoto;
        public string SRutaFoto
        {
            get { return sRutaFoto; }
            set { sRutaFoto = value; }
        }
        private string sApellidos;
        public string SApellidos
        {
            get { return sApellidos; }
            set
            {
                sApellidos = FormatoNombre(value);
                // = FormatoMail();//inicializo el correo
            }
        }
        private int iEdad;
        public int IEdad
        {
            get { return iEdad; }
            set { iEdad = value; }
        }
        private string sEmail;
        public string Id
        {
            get { return sEmail; }
            set {
                if (!value.EndsWith("trass.com"))
                {
                    // Utilizar el método FormatoMail()
                    sEmail = FormatoMail();
                }
                else
                {
                    // Utilizar el valor de mandadoProfesorExtendido
                    sEmail =value;
                }
            }
        }
        //Constructor vacío
        public Persona()
        {
        }
        //Constructor al que le pasámos como parámetros nombre, apellidos y edad
        public Persona(string sNombre, string sApellidos, int iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            Id = sEmail;
        }
        //Constructor al que le pasámos como parámetros nombre, ruta de la foto, apellidos y edad
        public Persona(string sNombre, string sRutaFoto, string sApellidos, int iEdad)
        {
            SNombre = sNombre;
            SRutaFoto = sRutaFoto;
            SApellidos = sApellidos;
            IEdad = iEdad;
            Id = sEmail;
        }
        //Método que da formato al nombre
        private string FormatoNombre(string nombre)
        {
            string sSalida = "";
            string sTemporal = "";
            string[] sNombre = nombre.Split(' ');
            for (int i = 0; sNombre.Length > i; i++)
            {
                sTemporal = sNombre[i].FirstLetterToUpper();
                sSalida = sSalida + sTemporal + " ";
            }


            return sSalida;

        }
        // Método para dar formato al email autogenerado
        protected virtual string FormatoMail()
        {
            string sSalida = "";
            string[] aApellidos = sApellidos.TrimEnd().Split(' ');
            if (sApellidos.WordCount() < 2)
            {
                sSalida = sSalida + aApellidos[0].Substring(0, 2).ToLower() + aApellidos[0].Substring(0, 2).ToLower();
            }
            else
            {
                sSalida = sSalida + aApellidos[0].Substring(0, 2).ToLower() + aApellidos[1].Substring(0, 2).ToLower();
            }
            sSalida = sSalida + sNombre.Substring(0, 2).ToLower() + "@trass.com";

            return sSalida;
        }
        // Método de salida por consola de la información del objeto persona
        public virtual String ToString()
        {
            string sSalida = SNombre.PadRight(10) + SApellidos.PadRight(15) + Id.PadRight(18) + IEdad.ToString().PadRight(5);

            return sSalida;
        }
        //método Equals para comparar dos personas
        public bool Equals(Persona? other)
        {
            return (other.sApellidos == this.sApellidos && other.sNombre == this.sNombre && other.IEdad == this.IEdad);
        }
        //Métodos para sobrecargar operadores > <
        public static bool operator <(Persona p, Persona o) => (p.IEdad < o.IEdad) ? true : false;
        public static bool operator >(Persona p, Persona o) => (p.IEdad > o.IEdad) ? true : false;
        public static bool operator <=(Persona p, Persona o) => (p.IEdad <= o.IEdad) ? true : false;
        public static bool operator >=(Persona p, Persona o) => (p.IEdad >= o.IEdad) ? true : false;
        public static bool operator ==(Persona p, Persona o) => (p.IEdad == o.IEdad) ? true : false;
        public static bool operator !=(Persona p, Persona o) => (p.IEdad != o.IEdad) ? true : false;


    }
}
