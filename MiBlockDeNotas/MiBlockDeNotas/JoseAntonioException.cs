using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    internal class JoseAntonioException : ApplicationException
    {
        public JoseAntonioException() : base("No es un NIF válido")
        {
        }
        public JoseAntonioException(int Uno) : base("La nota debe ser igual o superior a 5")
        {
        }
    }
}
