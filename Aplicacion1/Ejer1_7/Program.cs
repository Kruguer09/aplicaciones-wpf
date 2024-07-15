namespace Ejer1_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dTemp;
            Console.WriteLine("Ingresa la temperatura:");
            dTemp = Convert.ToDouble(Console.ReadLine());
            if (dTemp < -50 || dTemp > 70)
            {
                Console.WriteLine("Temperatura fuera de rango");
            }
            else if (dTemp < 10)
            {
                Console.WriteLine("Tipo de clima frío");
            }
            else if (dTemp >= 10 && dTemp <= 20)
            {
                Console.WriteLine("Tipo de clima nublado");
            }
            else if (dTemp > 20 && dTemp <= 30)
            {
                Console.WriteLine("Tipo de clima calor");
            }
            else
            {
                Console.WriteLine("Tipo de clima tropical");
            }
        }
    }
}