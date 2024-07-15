using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static _IGraficasIES.IEmpleadoPublico;

namespace _IGraficasIES
{
    internal class ProfesorFuncionario : Profesor, IEmpleadoPublico
    {
        //                                              *****************************************
        //                                              ********** PARÁMETROS DE CLASE **********

        private int anyoIngresoCuerpo;
        public int AnyoIngresoCuerpo
        {
            get => anyoIngresoCuerpo;
            set => anyoIngresoCuerpo = value;
        }

        private string destinoDefinitivo;
        public string DestinoDefinitivo
        {
            get { return destinoDefinitivo; }
            set { destinoDefinitivo = value; }
        }

        private TipoSeguro seguroMedico;
        public TipoSeguro SeguroMedico
        {
            get => seguroMedico;
            set => seguroMedico = value;
        }


        //                                              ********************************************
        //                                              ********** CONSTRUCTORES DE CLASE **********

        public ProfesorFuncionario(string nombre, string apellidos, uint edad)
            : base(nombre, apellidos, edad) { }

        public ProfesorFuncionario(string nombre, string apellidos, uint edad, string materia, TipoFuncionario tipoProfesor, string destinoDefinitivo, int anyoIngresoCuerpo, TipoSeguro seguroMedico)
            : base(nombre, apellidos, edad)
        {
            Materia = materia;
            TipoProfesor = tipoProfesor;
            this.destinoDefinitivo = destinoDefinitivo;
            this.anyoIngresoCuerpo = anyoIngresoCuerpo;
            this.seguroMedico = seguroMedico;
        }
        public ProfesorFuncionario(string nombre, string apellidos, uint edad, string foto)
            : base(nombre, apellidos, edad, foto) { }

        public ProfesorFuncionario(string nombre, string apellidos, uint edad, string foto, string materia, TipoFuncionario tipoProfesor, string destinoDefinitivo, int anyoIngresoCuerpo, TipoSeguro seguroMedico)
            : base(nombre, apellidos, edad, foto)
        {
            Materia = materia;
            TipoProfesor = tipoProfesor;
            this.destinoDefinitivo = destinoDefinitivo;
            this.anyoIngresoCuerpo = anyoIngresoCuerpo;
            this.seguroMedico = seguroMedico;
        }


        //                                              **************************************
        //                                              ********** MÉTODOS DE CLASE **********

        public override string ToString() => ToStringProfesor() + anyoIngresoCuerpo.ToString().PadRight(10) + DestinoDefinitivo.ToString().PadRight(15) + SeguroMedico.ToString().PadRight(15);
        
        public (int anyos, int meses, int dias) TiempoServicio()
        {
            DateTime fechaActual = DateTime.Today;
            DateTime fechaIngreso = new DateTime(AnyoIngresoCuerpo, 9, 1);
            DateDiff tiempoServicio = new DateDiff(fechaIngreso, fechaActual);

            int anyos = tiempoServicio.ElapsedYears;
            int meses = tiempoServicio.ElapsedMonths;
            int dias = tiempoServicio.ElapsedDays;

            return (anyos, meses, dias);
        }

        public int GetSexenios() => TiempoServicio().Item1 / 6;

        public int GetTrienios() => TiempoServicio().anyos / 3;
    }
}
