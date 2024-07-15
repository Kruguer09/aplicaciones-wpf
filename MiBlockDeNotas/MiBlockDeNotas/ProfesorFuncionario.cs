using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _2HerenciaSimpleIES.IEmpleadoPublico;

namespace _2HerenciaSimpleIES
{
    public class ProfesorFuncionario : Profesor, IEmpleadoPublico

    {
        // Delacaración de los atributos propios de profesor funcionario
        private int iAnyoIngresoCuerpo;
        public int IAnyoIngresoCuerpo
        {
            get { return iAnyoIngresoCuerpo; }
            set { iAnyoIngresoCuerpo = value; }
        }
        private bool bDestinoDefinitivo;
        public bool BDestinoDefinitivo
        {
            get { return bDestinoDefinitivo; }
            set { bDestinoDefinitivo = value; }
        }


        private TipoMedico tipoSeguro;
        public TipoMedico TipoSeguro
        {
            get { return tipoSeguro; }
            set { tipoSeguro = value; }
        }
        //Constructor al que se le pasan los datos de nombre apellidos y edad y usa métodos de construcción heredados del constructor base
        public ProfesorFuncionario(string sNombre, string sApellidos, int iEdad) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SEmail = FormatoMail();
        }
        //Constructor al que se le pasan los datos de nombre apellidos, edad, Tipo de funcionario, año de acceso al cuerto, tipo de destino y usa métodos de construcción heredados del constructor base
        public ProfesorFuncionario(string sNombre, string sApellidos, int iEdad, string sMateria, TipoFuncionario tipoProfesor, bool bDestinoDefinitivo, int iAnyoIngresoCuerpo, TipoMedico TipoSeguro) : base(sNombre, sApellidos, iEdad)
        {
            SNombre = sNombre;
            SApellidos = sApellidos;
            IEdad = iEdad;
            SMateria = sMateria;
            SEmail = FormatoMail();
            TipoProfesor = tipoProfesor;
            BDestinoDefinitivo = bDestinoDefinitivo;
            IAnyoIngresoCuerpo = iAnyoIngresoCuerpo;
            var TipoMedico = TipoSeguro;
        }
        // Método para calcular los sexenios del funcionario       
        public int GetSexenios()
        {
            int iNumeroSexenios;
            if (TiempoDeServicio().años >= 6)
            {
                return TiempoDeServicio().años / 6;
            }
            else
            {
                return 0;
            }
        }
        // Método para calcular los trienios del funcionario   
        public int GetTrienios()
        {
            int iNumeroSexenios;
            if (TiempoDeServicio().años >= 3)
            {
                return TiempoDeServicio().años / 3;
            }
            else
            {
                return 0;
            }
        }
        // Método para calcular el tiempo de servicio de un funcionario
        public (int años, int dias, int meses) TiempoDeServicio()
        {
            DateTime dtFechaTomaPosesion = new DateTime(IAnyoIngresoCuerpo, 9, 1); // 1 de septiembre del año de ingreso
            DateTime dtFechaActual = DateTime.Now;

            TimeSpan tsDiferencia = dtFechaActual - dtFechaTomaPosesion;

            int iDiasTotales = (int)tsDiferencia.TotalDays;

            int iAños = iDiasTotales / 365; // Asumiendo año de 365 días
            int iDiasRestantes = iDiasTotales % 365;

            int iMeses = iDiasRestantes / 30; // Asumiendo mes de 30 días
            int iDias = iDiasRestantes % 30;
            return (iAños, iMeses, iDias);
        }
        // Método sobrecargado para obtener la información de ProfesorFuncionario
        public override string toString()
        {
            return toStringProfesor()+ iAnyoIngresoCuerpo.ToString().PadRight(13)+((bDestinoDefinitivo) ? "si":"no").PadRight(15)+TipoSeguro.ToString().PadRight(10);
        }
    }
}
