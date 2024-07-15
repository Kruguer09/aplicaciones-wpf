namespace Ejer1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double precio;
            Console.WriteLine("Cuánto vale el producto?:");
            double temporal= Convert.ToDouble(Console.ReadLine());
            if (temporal >=0 )
            {
                precio = temporal;
            }
            else
            {
                Console.WriteLine("El precio debe ser un valor positivo, pero lo paso por tí");
                precio = temporal * -1;
            }
            Console.WriteLine("Forma de pago, efectivo o tarjeta");
            string tipoPago= Console.ReadLine().ToLower();
            switch (tipoPago)
            {
                case "efectivo":
                    Console.WriteLine("Gracias por su pago en efectivo");
                    break;
                case "tarjeta":
                    Console.WriteLine("Introduzca número de cuenta: ");
                    double numCuenta = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Gracias, para terminar pulse enter");
                    break;
                default:
                    Console.WriteLine("Error en la respuesta, empiece de nuevo.");
                    break;
            }
        }
    }
}