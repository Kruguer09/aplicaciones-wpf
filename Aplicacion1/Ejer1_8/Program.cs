namespace Ejer1_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iPreguntas, iRespuestas;
            double dResultado;
            Console.WriteLine("Cantidad total preguntas: ");
            iPreguntas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cantidad total preguntas correctas: ");
            iRespuestas = Convert.ToInt32(Console.ReadLine());
            dResultado = (double)(iRespuestas * 100) / iPreguntas;
            if (dResultado > 100 || dResultado < 0)
            {
                Console.WriteLine("Datos introducidos erróneos: ");
            }
            else if (dResultado >= 90)
            {
                Console.WriteLine("Nivel máximo de porcentaje, " + dResultado + " %");
            }
            else if (dResultado >= 75)
            {
                Console.WriteLine("Nivel medio de porcentaje, " + dResultado + " %");
            }
            else if (dResultado >= 50)
            {
                Console.WriteLine("Nivel regular de porcentaje, " + dResultado + " %");
            }
            else 
            {
                Console.WriteLine("Fuera de nivel de porcentaje, " + dResultado + " %");
            }
        }
    }
}