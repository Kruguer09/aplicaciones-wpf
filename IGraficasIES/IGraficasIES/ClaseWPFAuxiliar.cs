using IGraficasIES.Contexto;
using IGraficasIES.modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IGraficasIES
{
    //Clase auxiliar estática con métodos que pueden ser externos a la aplicación
    public static class ClaseWPFAuxiliar
    {
        //Método para contar palabras de un string
        //Devuelve un entero
        public static int WordCount(this string word)
        {
            string[] aPalabras = word.TrimEnd().Split(' ', '.', ',');
            return aPalabras.Length;
        }
        //Método para Poner primera letra en mayuscula y resto en minuscula de una palabra
        //Devuelve un string
        public static string FirstLetterToUpper(this string word)
        {
            string sSalida = word.ToLower();
            sSalida = char.ToUpper(sSalida[0]) + sSalida.Substring(1);

            return sSalida;
        }
        //Método para cargar imágenes en una interfaz a la que se le pasa la ruta de la imagen
        public static ImageSource CargaImg(String ruta)
        {
            const string rutaImagenes = "..\\..\\..\\imagenes\\";
            ImageSource salida = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + ruta) as ImageSource;
            return salida;
        }
        //Método que genera la salida de filtros
        public static void MuestraResultado(string salida, string tipo)
        {
            MessageBox.Show(salida, "FILTRAR POR: " + tipo, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //Método que genera la salida de agrupaciones
        public static void MuestraResultadoGrupo(string salida, string tipo)
        {
            MessageBox.Show(salida, "AGRUPAR POR: " + tipo, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //Método que genera la salida de filtros usando el método System.Reflection genérica para todos
        //se le pasa el resultado de la consulta
        public static void MuestraResultadoFiltro <T>( string tipo,IEnumerable<T> consulta)
        {
            string salida = "";
            System.Reflection.PropertyInfo[] filtrado = typeof(T).GetProperties();
            foreach (var item in consulta)
            {
                foreach (var prof in filtrado)
                {
                    salida += $"{prof.Name}: {prof.GetValue(item)}\n";
                }
                salida += "\n";
            }
            MessageBox.Show(salida, "AGRUPAR POR: " + tipo, MessageBoxButton.OK, MessageBoxImage.Information);
           
        }
        public static List<ProfesorFuncionario> LeerTodosBase()
        {
            using (MyContext context = new MyContext())
            {
                return context.Profesores.ToList();
            }
        }
        public static List<ProfesorExtendido> LeerTodosBaseExtendido()
        {
            using (MyContext context = new MyContext())
            {
                return context.OtrosDatosProfesores.ToList();
            }
        }


    }
}
