using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public static class ExtensionClass
    {
        public static int WordCount(this string word)
        {
            string[] aPalabras = word.TrimEnd().Split(' ','.',',' );
            return aPalabras.Length;
        }
        public static string FirstLetterToUpper(this string word)
        {
            string sSalida = word.ToLower();
            sSalida = char.ToUpper(sSalida[0]) + sSalida.Substring(1);

            return sSalida;
        }
        public static bool SeekRemove(this List<Persona> lPersona,Persona Ppersona)
        {
            bool sSalida = false;
            for (int i = 0; i < lPersona.Count; i++)
            
                if (lPersona[i].SNombre.Equals(Ppersona.SNombre) && lPersona[i].SApellidos.Equals(Ppersona.SApellidos))
                {
                    lPersona.Remove(lPersona[i]);
                    sSalida= true;
                }
            
            return sSalida;
        }
    }
}
