using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HerenciaSimpleIES
{
    internal class AlumnoFP : Alumno
    {
        private bool bRepetidor;
        public bool BRepetidor
        {
            get { return bRepetidor; }
            set { bRepetidor = value; }
        }
        private float notaAcceso;
        public float NotaAcceso
        {
            get { return notaAcceso; }
            set { notaAcceso = value; }
        }
        public enum ModoAcceso : uint
        {
            Bachillerato = 1,
            GradoMedio = 2
        }
        public ModoAcceso TipoAcceso { get; set; }
        public enum Curso : uint
        {
            DAM1 = 1,
            DAM2 = 2
        }
        public Curso TipoCurso { get; set; }

        public AlumnoFP()
        {
        }
        public AlumnoFP(string sNombre, string sApellidos, int iEdad, int iNumeroExpediente) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
            INumeroExpediente = iNumeroExpediente;
        }
        public AlumnoFP(string sNombre, string sApellidos,string nif, int iEdad, int iNumeroExpediente, bool bRepetidor, float notaAcceso, ModoAcceso tipoAcceso, Curso tipoCurso) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
            INumeroExpediente = iNumeroExpediente;
            BRepetidor = bRepetidor;
            TipoAcceso = tipoAcceso;
            TipoCurso = tipoCurso;
            Nif = nif;
        }

        public override string ToString()
        {
            string repetidor;
            if (BRepetidor) { repetidor = "Sí es repetidor"; } else { repetidor = "No es repetidor"; }
            string salida = "Nombre: " + SNombre.PadRight(20) + "Apellidos: " + SApellidos.PadRight(50) + "\n" +
                "NIF: " + Nif.ToString().PadRight(20) + "Edad:" + IEdad.ToString().PadRight(50) + "\n" +
                "Nº Expediente: " + INumeroExpediente.ToString().PadRight(20) + "Email: " + SEmail.PadRight(50) + "\n" +
                repetidor.PadRight(20) + "Nota acceso: " + NotaAcceso.ToString().PadRight(50) + "\n" +
                "Modo de Acceso: " + TipoAcceso.ToString().PadRight(20) + "Curso: " + TipoCurso.ToString().PadRight(50) + "\n";
            return salida;
        }
        public override string FormatoMail()
        {
            return FormatoMailAlumno();
        }
        public override string FormatoMailAlumno()
        {
            string sSalida = "";
            int iAnyoActual = DateTime.Now.Year % 100;
            iAnyoActual.ToString();
            string[] aApellidos = SApellidos.TrimEnd().Split(' ');

            if (aApellidos.Length < 2)
            {
                sSalida += aApellidos[0].Substring(0, 2).ToLower() + aApellidos[0].Substring(0, 2).ToLower();
            }
            else
            {
                sSalida += aApellidos[0].Substring(0, 2).ToLower() + aApellidos[1].Substring(0, 2).ToLower();
            }

            sSalida += SNombre.Substring(0, 2).ToLower() + iAnyoActual + "fp@tras.com";

            return sSalida;
        }
    }
}
