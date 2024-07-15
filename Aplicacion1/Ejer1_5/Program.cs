namespace Ejer1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dame un número del 1 al 7");
            int numDia = Convert.ToInt32(Console.ReadLine());
            switch (numDia)
            {
                case 1:
                    Console.WriteLine("Lunes");
                    break;
                case 2:
                    Console.WriteLine("Martes");
                    break;
                case 3:
                    Console.WriteLine("Miercoles");
                    break;
                case 4:
                    Console.WriteLine("Jueves");
                    break;
                case 5:
                    Console.WriteLine("Viernes");
                    break;
                case 6:
                    Console.WriteLine("Sábado");
                    break;
                case 7:
                    Console.WriteLine("Domingo");
                    break;

                default:
                    Console.WriteLine("Error en la respuesta, empiece de nuevo.");
                    break;
            }
            if (numDia == 1) { Console.WriteLine("Lunes"); }
            else if (numDia == 2) { Console.WriteLine("Martes"); }
            else if (numDia == 3) { Console.WriteLine("Miercoles"); }
            else if (numDia == 4) { Console.WriteLine("Jueves"); }
            else if (numDia == 5) { Console.WriteLine("Viernes"); }
            else if (numDia == 6) { Console.WriteLine("Sábado"); }
            else if (numDia == 7) { Console.WriteLine("Domingo"); }
            else { Console.WriteLine("Dato erroneo"); }
        }
    }