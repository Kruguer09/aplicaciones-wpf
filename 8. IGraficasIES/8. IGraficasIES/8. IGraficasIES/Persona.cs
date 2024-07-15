using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _IGraficasIES
{
    public class Persona : IEquatable<Persona>
    {
        //                                              ******************************************
        //                                              ********** PROPIEDADES DE CLASE **********

        private string nombre;  // Campo de respaldo
        public string Nombre    // Propiedad
        {   // Descriptores de acceso con llaves
            get { return nombre; }
            set { nombre = FormatoNombre(value); }
        }

        private string apellidos;
        public string Apellidos
        {   // Descriptores de acceso con lambda (expresión corporal)
            get => apellidos;
            set => apellidos = FormatoNombre(value);
        }

        private uint edad;
        public uint Edad
        {   // Descriptores de acceso con llaves y lambda (expresión corporal)
            get { return edad; }
            set { edad = value; }
        }

        private string email;

        public string Email
        {   // Descriptores de acceso con lambda (expresión corporal)
            get => email;
            set => email = GenerarEmail();
        }

        public string RutaFoto { get; set; }


        //                                              ********************************************
        //                                              ********** CONSTRUCTORES DE CLASE **********

        public Persona() { }

        public Persona(string nombre, string apellidos, uint edad)
        {   // Se llaman a las propiedades para ejecutar los métodos. Si no hay métodos, se pueden llamar a los campos de respaldo
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Email = "X";                                                                                                
        }

        public Persona(string nombre, string apellidos, uint edad, string foto)
        {   // Se llaman a las propiedades para ejecutar los métodos. Si no hay métodos, se pueden llamar a los campos de respaldo
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Email = "X";
            RutaFoto = foto;
        }


        //                                              **************************************
        //                                              ********** MÉTODOS DE CLASE **********

        public string FormatoNombre(string nombre)
        {
            string[] nombreCompuesto = nombre.ToLower().Split(' ', ',', '.');                                           // Almacena en distintas posiciones de un array cada una de las palabras (para casos de nombres y/o apellidos compuestos)
            nombre = "";                                                                                                // Limpia la variable para meter el dato nuevo
            foreach (string nombres in nombreCompuesto)                                                                 // Recorre cada una de las palabras del array
            {
                nombre += ExtensionClass.FirstLetterToUpper(nombres);                                                   // Usa el método de extensión
                // nombre += string.Concat(nombres.Substring(0, 1).ToUpper(), nombres.Substring(1)) + ' ';              // Convierte la primera letra de cada palabra en mayúscula y la añade
                // nombre += char.ToUpper(nombres[0]) + nombres.Substring(1)+ ' ';                                      // Forma alternativa
            }
            return nombre;
        }
        public virtual string GenerarEmail()
        {
            string correo = "";
            string[] apellidosCompuesto = apellidos.Trim().Split(' ', ',', '.');
            correo = apellidosCompuesto[0].Substring(0, 2).ToLower();                                                    // Coloca las dos primeras letras del primer apellido
            if (ExtensionClass.WordCount(apellidos) < 2)                                                                // Llama al método para contar palabras del campo "apellido"
                correo += apellidosCompuesto[0].Substring(0, 2).ToLower();      // correo += correo;                    // Si tiene un solo apellido, repite las dos mismas letras
            else
                correo += apellidosCompuesto[1].Substring(0, 2).ToLower();                                              // Si tiene apellido compuesto, coloca las dos letras de la siguiente palabra

            correo += string.Concat(nombre.Substring(0, 1).ToLower(), "@trass.com");
            return correo;
        }

        public bool Equals(Persona personaActual) => (this.nombre.Equals(personaActual.nombre) && this.apellidos.Equals(personaActual.apellidos) && this.edad.Equals(personaActual.edad));     // Compara los datos para comprobar si es la misma persona
        // return this.nombre == personaActual.nombre && this.apellidos == personaActual.apellidos && this.edad == personaActual.edad;      // Forma alternativa de comparar

        public override string ToString() => string.Concat(nombre.PadRight(20), apellidos.PadRight(25), email.PadRight(25), edad.ToString().PadRight(10));                      // Sobreescribe el método ToString()


        //                                              **********************************************
        //                                              ********** SOBRECARGA DE OPERADORES **********
        
        public static bool operator > (Persona p1, Persona p2) => p1.edad > p2.edad;
        
        public static bool operator < (Persona p1, Persona p2) => p1.edad < p2.edad;
    }
}
