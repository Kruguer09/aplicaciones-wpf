using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    //descripción de la clase persona con sus parámetros nombre, apellidos, edad y email con sus getter y setter
    public class Persona : IEquatable<Persona>
    {
        private string sNombre;
        public string SNombre
        {
            get { return sNombre; } 
            set {sNombre =FormatoNombre(value); }
        }
        private string sApellidos;
        public string SApellidos
        { get { return sApellidos; } 
        set { sApellidos=FormatoNombre(value);
                SEmail = FormatoMail();//inicializo el correo
            }
        }
        private int iEdad;
        public int IEdad
        {
            get { return iEdad; }
            set {  iEdad = value; }
        }
        private string sEmail;
        public string SEmail
        {   get { return sEmail; } 
            set {  sEmail = FormatoMail(); } 
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
            SEmail = sEmail;
        }
        //Método que da formato al nombre
        private string FormatoNombre(string nombre)
        {
            string sSalida = "";
            string sTemporal = "";
            string[]sNombre=nombre.Split(' ');
            for(int i = 0; sNombre.Length > i; i++)
            {
                sTemporal = sNombre[i].FirstLetterToUpper();
                //sTemporal = char.ToUpper(sTemporal[0]) + sTemporal.Substring(1);
                sSalida = sSalida + sTemporal+" ";
            }
            

            return sSalida;

        }
        // Método para dar formato al email autogenerado
        protected virtual string FormatoMail()
        {
            string sSalida = "";
            string[] aApellidos = sApellidos.TrimEnd().Split(' ');
            if (sApellidos.WordCount()< 2)
            {
                sSalida = sSalida + aApellidos[0].Substring(0,2).ToLower()+ aApellidos[0].Substring(0, 2).ToLower();
            }
            else
            {
                sSalida = sSalida + aApellidos[0].Substring(0, 2).ToLower() + aApellidos[1].Substring(0, 2).ToLower();
            }
            sSalida=sSalida+sNombre.Substring(0, 2).ToLower()+"@tras.com";

            return sSalida;
        }
        // Método de salida por consola de la información del objeto persona
        public String toString()
        {
            string sSalida = SNombre.PadRight(10) + SApellidos.PadRight(15) + SEmail.PadRight(18) + IEdad.ToString().PadRight(5);

            return sSalida;
        }
        //método Equals para comparar dos personas
        public bool Equals(Persona? other)
        {
            if (other.sApellidos == this.sApellidos|| other.sNombre == this.sNombre)
            {
                return true;
            }
            else {
                return false;
            }

            //throw new NotImplementedException();
        }
        //Métodos para sobrecargar operadores > <
        public static bool operator <(Persona p,Persona o) => (p.IEdad < o.IEdad) ? true : false;
        public static bool operator >(Persona p, Persona o) => (p.IEdad > o.IEdad) ? true : false;
        public static bool operator <=(Persona p, Persona o) => (p.IEdad <= o.IEdad) ? true : false;
        public static bool operator >=(Persona p, Persona o) => (p.IEdad >= o.IEdad) ? true : false;
        public static bool operator ==(Persona p, Persona o) => (p.IEdad == o.IEdad) ? true : false;
        public static bool operator !=(Persona p, Persona o) => (p.IEdad != o.IEdad) ? true : false;


    }
}
