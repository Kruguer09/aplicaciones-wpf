using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _IGraficasIES
{
    public static class ExtensionClass
    {
        public static int WordCount(this String cadena) => cadena.Split (new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;        // Crea un array de string de determinado por la longitud de la cadena original. 
        // Almacena en cada posición un string de la cadena original, separándola cuando se encuentra el separador (1er argumento entre {}). El parámetro opcional , elimina los elementos vacios (2o argumento).

        public static string FirstLetterToUpper(this String cadena) => cadena = string.Concat(cadena.Substring(0, 1).ToUpper(), cadena.Substring(1)) + ' ';     // Convierte la primera letra en mayúscula

        public static bool SeekRemove(this List<Persona> listaPersonas, Persona personaBuscada) => listaPersonas.Remove(personaBuscada);                        // Busca y elimina de la lista a la persona coincidente
    }
}
