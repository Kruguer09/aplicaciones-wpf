namespace Ejer1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valorUno, valorDos, valorTres, temporal;
            Console.WriteLine("Vamos  introducir 3 números enteros: ");
            Console.WriteLine("Valor Uno:");
            valorUno= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor Dos:");
            temporal = Convert.ToInt32(Console.ReadLine());
            if (temporal > valorUno)
            {
                valorDos = temporal;
            }
            else { valorDos = valorUno;
                valorUno = temporal;
            }
            Console.WriteLine("Valor Tres:");
            temporal = Convert.ToInt32(Console.ReadLine());
            if (temporal > valorDos)
            {
                valorTres = temporal;
            }
            else
            {
                if (temporal < valorUno)
                {
                    valorTres= valorDos;
                    valorDos = valorUno;
                    valorUno = temporal;

                }
                else
                {
                    valorTres = valorDos;
                    valorDos = temporal;
                    
                }
                
                
            }
            Console.WriteLine("Los valores ordenados de mayor a menor son::" + valorTres + ">" + valorDos + ">" + valorUno);
        }
    }
}