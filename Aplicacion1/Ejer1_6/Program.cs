namespace Ejer1_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iEdad;
            string sCarneCond;
            bool bPermiso = false;
            Console.WriteLine("Indica tu edad: ");
            iEdad = Convert.ToInt32(Console.ReadLine());
            if (iEdad <= 0 || iEdad > 120)
            {
                Console.WriteLine("Edad erronea: ");
            }
            else
            {
                if (iEdad >= 18)
                {
                    Console.WriteLine("Indica si posees carné de conducir si (S) o no (N): ");
                    sCarneCond = Console.ReadLine().ToLower();
                    if (sCarneCond == "n" || sCarneCond == "s")
                    {
                        if (sCarneCond == "s")
                        {
                            bPermiso = true;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Respuesta errónea");
                    }


                }
            }
            if (bPermiso)
            {
                Console.WriteLine("Puede conducir");
            }
            else
            {
                Console.WriteLine("No puede conducir");
            }
        }
    }
}