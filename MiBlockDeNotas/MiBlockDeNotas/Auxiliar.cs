using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    public static class Auxiliar
    {
        // Función que controla el ciclo para agregar más personas
        public static void masPersonas(ref bool bControlaCiclo, ref bool bControlPersonas)
        {
            do
            {
                Console.Write("\t\t=>¿Desea introducir más personas? (SI/NO:) ");
                string sRespuesta = Console.ReadLine().ToLower();
                if (sRespuesta.Equals("si") || sRespuesta.Equals("s"))
                {
                    bControlPersonas = true;
                }
                else if (sRespuesta.Equals("no") || sRespuesta.Equals("n"))
                {
                    bControlPersonas = true;
                    bControlaCiclo = true;

                }
                else
                {
                    Console.WriteLine("Datos incorrectos.");
                }

            } while (!bControlPersonas);
        }
        // Función que controla la salida por consola de la lista de profesores
        public static void imprimeLista(List<Profesor> lPersonas)
        {
            Console.WriteLine("NOMBRE".PadRight(20) + "APELLIDOS".PadRight(30) + "EMAIL".PadRight(30) + "EDAD".PadRight(20) + "MATERIA");
            for (int i = 0; i < lPersonas.Count; i++)
            {
                Console.WriteLine(lPersonas[i].toString());
            }
        }
        // Función que controla la salida por consola de la lista de alumnos
        public static void imprimeLista(List<Alumno> lPersonas)
        {
            Console.WriteLine("NOMBRE".PadRight(20) + "APELLIDOS".PadRight(30) + "EMAIL".PadRight(30) + "EDAD".PadRight(20) + "Nº DE EXPEDIENTE");
            for (int i = 0; i < lPersonas.Count; i++)
            {
                Console.WriteLine(lPersonas[i].toString());
            }
        }
        // Función que controla la salida por consola de la lista de personas
        public static void imprimeLista(List<Persona> lPersonas)
        {
            Console.WriteLine("NOMBRE".PadRight(20) + "APELLIDOS".PadRight(30) + "EMAIL".PadRight(30) + "EDAD");
            for (int i = 0; i < lPersonas.Count; i++)
            {
                Console.WriteLine(lPersonas[i].toString());
            }
        }
        // Método de salida de programa
        public static void salir() => System.Console.WriteLine("\n\n¡Hasta pronto!\n\n");
        // Método para obtener 

        public static string anyoActual()
        {
            int anyo=DateTime.Now.Year % 100;
            string anyoActual=anyo.ToString();
            return anyoActual;
        }
        // Método que compara que Persona es mayor y utiliza la recarga de operadores
        public static void ComparaEdad(Persona pPersonaUno, Persona pPersonaDos)
        {
            if (pPersonaUno > pPersonaDos)
            {
                Console.WriteLine("PERSONA MÁS MAYOR\n" + pPersonaUno.toString());

            }
            else if (pPersonaUno < pPersonaDos)
            {
                Console.WriteLine("PERSONA MÁS MAYOR\n" + pPersonaDos.toString());
            }
            else
            {
                Console.WriteLine("PERSONAS DE IGUAL EDAD\n" + pPersonaUno.toString() + "\n" + pPersonaDos.toString());
            }
        }
        // Método que revisa que la edad tenga un rango
        public static int revisaEdad()
        {
            int iEdadPersonas;
            do
            {
                Console.Write("EDAD (entre 0-120): ");
            } while (!Int32.TryParse(Console.ReadLine(), out iEdadPersonas) || iEdadPersonas < 0 || iEdadPersonas > 120);
            return iEdadPersonas;
        }
        //Método de control de la salida de pantalla de la lista de personas
        public static void ImprimeListaPersonas(List<Persona> lPersonas)
        {
            Console.Clear();
            Console.WriteLine("##########  LISTADO DE ALUMNOS Y PROFESORES  ##########\n\n---- ALUMNOS----");
            Console.WriteLine("NOMBRE".PadRight(10) + "APELLIDOS".PadRight(15) + "EMAIL".PadRight(18) + "EDAD".PadRight(5) + "Nº DE EXPEDIENTE".PadRight(5));
            for (int i = 0; i < lPersonas.Count; i++)
            {
                if (lPersonas[i] is Alumno)
                    Console.WriteLine(((Alumno)lPersonas[i]).toString());
            }
            Console.WriteLine("\n\n----Profesores----\n\n");
            Console.WriteLine("NOMBRE".PadRight(10) + "APELLIDOS".PadRight(15) + "EMAIL".PadRight(18) + "EDAD".PadRight(5) + "MATERIA".PadRight(10) + "FUNCIONARIO".PadRight(13) + "AÑO".PadRight(13) + "DEFINITIVO".PadRight(15) + "S. MEDICO".PadRight(10));
            for (int i = 0; i < lPersonas.Count; i++)
            {
                if (lPersonas[i] is ProfesorInterino || lPersonas[i] is ProfesorFuncionario)
                {
                    if (lPersonas[i] is ProfesorInterino)
                    {
                        Console.WriteLine(((ProfesorInterino)lPersonas[i]).toString());
                    }
                    else
                    {
                        Console.WriteLine(((ProfesorFuncionario)lPersonas[i]).toString());
                    }
                }


            }
        }
        //Método pR comprarar y borrar persona si la encuentra
        public static void BuscaYBorraPersonas(List<Persona> lPersonas)
        {
            Persona pTemporal = new Persona();
            bool bPersona = false;
            Console.WriteLine("#######  BORRADO DE PERSONAS #######");
            Console.Write("NOMBRE: ");
            pTemporal.SNombre = Console.ReadLine();
            Console.Write("APELLIDOS: ");
            pTemporal.SApellidos = Console.ReadLine();
            pTemporal.IEdad = Auxiliar.revisaEdad();
            bPersona = lPersonas.SeekRemove(pTemporal);
            if (bPersona)
            {
                Console.WriteLine("Persona borrada");
            }
            else
            {
                Console.WriteLine("La persona no estaba en la lista");
            }
        }
        // Método que compara la edad de dos personas
        public static void ComparaPersonas()
        {
            Persona pPersonaUno = new Persona();
            Persona pPersonaDos = new Persona();
            Console.WriteLine("#######  COMPRAR DOS PERSONAS #######");
            Console.Write("NOMBRE: ");
            pPersonaUno.SNombre = Console.ReadLine();
            Console.Write("APELLIDOS: ");
            pPersonaUno.SApellidos = Console.ReadLine();
            pPersonaUno.IEdad = Auxiliar.revisaEdad();
            Console.WriteLine("\nNOMBRE: ");
            pPersonaDos.SNombre = Console.ReadLine();
            Console.Write("APELLIDOS: ");
            pPersonaDos.SApellidos = Console.ReadLine();
            pPersonaDos.IEdad = Auxiliar.revisaEdad();
            Auxiliar.ComparaEdad(pPersonaUno, pPersonaDos);
        }
        // Función que controla si un objeto persona está repetido en la lista
        public static bool personaRepetida(List<Persona> lPersonas, Alumno personaNueva)
        {
            foreach (Alumno personaExistente in lPersonas)
            {
                if (personaExistente.SNombre.Equals(personaNueva.SNombre) &&
                    personaExistente.SApellidos.Equals(personaNueva.SApellidos))
                {
                    return true;
                }
            }
            return false;
        }
        // Función sobrecargada que controla si un objeto Profesor interino está repetido en la lista
        public static bool personaRepetida(List<Persona> lPersonas, ProfesorInterino personaNueva)
        {
            foreach (Persona personaExistente in lPersonas)
            {
                if (personaExistente.SNombre.Equals(personaNueva.SNombre) &&
                    personaExistente.SApellidos.Equals(personaNueva.SApellidos))
                {
                    return true;
                }
            }
            return false;
        }
        // Función sobrecargada que controla si un objeto ProfesorFuncionario está repetido en la lista
        public static bool personaRepetida(List<Persona> lPersonas, ProfesorFuncionario personaNueva)
        {
            foreach (Persona personaExistente in lPersonas)
            {
                if (personaExistente.SNombre.Equals(personaNueva.SNombre) &&
                    personaExistente.SApellidos.Equals(personaNueva.SApellidos))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
