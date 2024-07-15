using IGraficasIES.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES
{
    //Clase que extiende la información del ProfesorFuncionario para poder hacer los join y
    //comparar las dos listas a través del campo común correo
    public class ProfesorExtendido
    {
        public int Id { get; set; }
        public enum ECivil : uint
        {
            Soltero = 1,
            Casado = 2,
            Divorciado = 3,
            Viudo=4
        }
        public ECivil TipoEstado { get; set; }

        private string sEmail;
        public string SEmail
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        private int iPeso;
        public int IPeso
        {
            get { return iPeso; }
            set { iPeso = value; }
        }
        private int iEstatura;
        public int IEstatura
        {
            get { return iEstatura; }
            set { iEstatura = value; }
        }
        public string ProfesorFuncionarioId { get; set; }

        
        //Método para cargar los profesores requeridos
        public static List<ProfesorExtendido> GetProfesE()
        {
            List<ProfesorExtendido> lProfesoresE = new List<ProfesorExtendido>();

            lProfesoresE.Add(new ProfesorExtendido {TipoEstado= ECivil.Soltero, SEmail = "fecoe@trass.com",iPeso= 57,iEstatura= 166 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Casado, SEmail = "lorea@trass.com", iPeso = 39, iEstatura = 159 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Divorciado, SEmail = "dires@trass.com", iPeso = 44, iEstatura = 182 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Viudo, SEmail = "luluj@trass.com", iPeso = 65, iEstatura = 185 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Soltero, SEmail = "diler@trass.com", iPeso = 57, iEstatura = 170 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Casado, SEmail = "grfem@trass.com", iPeso = 31, iEstatura = 175 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Divorciado, SEmail = "fecam@trass.com", iPeso = 48, iEstatura = 178 });
            lProfesoresE.Add(new ProfesorExtendido { TipoEstado = ECivil.Viudo, SEmail = "caexa@trass.com", iPeso = 60, iEstatura = 168 });

            return lProfesoresE;
        }
    }
}
