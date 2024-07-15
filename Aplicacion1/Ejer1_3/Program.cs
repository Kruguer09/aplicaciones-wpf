using System.Text;

namespace Ejer1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string diaSemana;
            Console.WriteLine("¿Qué dia de la semana es?");
            diaSemana = Console.ReadLine().ToLower();
            switch (diaSemana)
            {
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                case "viernes": Console.WriteLine("No es fin de demana");
                    break;
                case "sabado":
                case "domingo": Console.WriteLine("Es fin de demana");
                    break;
                default: Console.WriteLine("No es un día de la semana");
                    break;
            }

        }
    }
}