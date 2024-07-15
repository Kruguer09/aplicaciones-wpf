namespace Aplicacion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrayDeChars = "Saludos".ToCharArray(); //matriz de chars
            foreach (var ch in arrayDeChars)
            {
                Console.Write(ch); //ch es char
                Console.WriteLine();
            }

        }
    }
}