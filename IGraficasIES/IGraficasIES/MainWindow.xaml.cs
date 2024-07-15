using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Collections.Generic; //para IEnumerable
using System.Linq;//para LINQ
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static IGraficasIES.ClaseWPFAuxiliar;
using static IGraficasIES.IEmpleadoPublico;
using static IGraficasIES.Profesor;
using static System.Runtime.InteropServices.JavaScript.JSType;

using static System.Net.Mime.MediaTypeNames;
using IGraficasIES.modelos;
using IGraficasIES.Contexto;
using Microsoft.EntityFrameworkCore;

namespace IGraficasIES
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Lista donde se introducirán los profesores que hay en el archivo
        List<ProfesorFuncionario> lProfesores = new List<ProfesorFuncionario>();
        List<ProfesorExtendido> lProfesoresE = new List<ProfesorExtendido>();
        //ProfesorFuncionario temporal para crear instancia antes de subirlo a la base de datos
        ProfesorFuncionario pTemporalBase= new ProfesorFuncionario();
        //Rutas de las imágenes
        const string rutaSalir = "salir.jpg";
        const string rutaAnterior = "anterior.png";
        const string rutaSiguiente = "siguiente.png";
        const string rutaUltimo = "ultimo.png";
        const string rutaPrimero = "primero.png";
        const string rutaAvatar = "avatar.png";
        const string rutaAgregar = "agregar_usuario.png";
        const string rutaBorrar = "borrar_usuario.png";
        const string rutaModificar = "actualizar_usuario.png";
        const string rutaCancelar = "cancelado.png";
        const string rutaGuardar = "guardar.png";
        //Constantes para rellenar combo de edad
        const int edadMinima = 22;
        const int edadMaxima = 70;
        //Índice que controla la posición en la lista de profesores
        int iIndice = 0;

        public MainWindow()
        {
            InitializeComponent();
            // Relleno combobox de edad
            RellenaComboEdad();
            //relleno imágenes
            menuSalir.Source = CargaImg(rutaSalir);
            imgAnterior.Source = CargaImg(rutaAnterior);
            imgSiguiente.Source = CargaImg(rutaSiguiente);
            imgUltimo.Source = CargaImg(rutaUltimo);
            imgPrimero.Source = CargaImg(rutaPrimero);
            imgFoto.Source = CargaImg(rutaAvatar);
            imgAgregar.Source = CargaImg(rutaAgregar);
            imgEliminar.Source = CargaImg(rutaBorrar);
            imgModificar.Source = CargaImg(rutaModificar);
            imgCancelar.Source = CargaImg(rutaCancelar);
            imgGuardar.Source = CargaImg(rutaGuardar);
            lProfesores = LeerTodosBase();
            lProfesoresE = LeerTodosBaseExtendido();



            //deshabilito menús según enunciado
            menuFiltros.IsEnabled = false;
            menuAgrupacion.IsEnabled = false;
            Grid_Central.IsEnabled = false;
            desahabilitarbotones();
            //Cambio la fuente de la interfaz
            FontFamily = new FontFamily("Comic Sans MS");
        }

        private void desahabilitarbotones()
        {
            btnPrimero.IsEnabled = false;
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = false;
            btnUltimo.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnAgregar.IsEnabled = true;
        }

        //Método para rellenar el combo de edades
        private void RellenaComboEdad()
        {
            for (int edad = edadMinima; edad <= edadMaxima; edad++)
            {
                cbEdad.Items.Add(edad);
            }
        }
        //Acción del botón salir
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
        //Método del botón abrir para que puedas seleccionar el txt donde estará la base de datos de los profesores.
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            if (lProfesores.Count == 0)
            {
                //Para que nos aparezca el buscador de archivos para elegir el que queremos abrir y que comience en el mismo directorio que está la aplicación
                OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                lProfesoresE = ProfesorExtendido.GetProfesE();
                //Para filtar archivos que sean solo tipo texto
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == true) //Cuando el usuario le dé a Aceptar
                {
                    try
                    {

                        var lineas = File.ReadLines(openFileDialog.FileName);
                        menuFiltros.IsEnabled = true;
                        menuAgrupacion.IsEnabled = true;
                        //Grid_Central.IsEnabled = true; no lo habilitamos ya que no vamos a permitir hacer cambios
                        Grid_Botones.IsEnabled = true;
                        CargaLista(lineas, ref lProfesores);
                        MuestraProfesor();
                        BotonesPrevOff();
                        RellenarBaseDatos();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    
                }
            }
            else
            {
                menuFiltros.IsEnabled = true;
                menuAgrupacion.IsEnabled = true;
                Grid_Botones.IsEnabled = true;
                MuestraProfesor();
                BotonesPrevOff();
            }


        }

        private void RellenarBaseDatos()
        {
            for (int i = 0; i < lProfesores.Count; i++)
            {
                lProfesores[i].profesorExtendido = lProfesoresE[i];
                lProfesoresE[i].ProfesorFuncionarioId = lProfesores[i].Id;
            }
            try
            {
                lProfesoresE = ProfesorExtendido.GetProfesE();
                using (MyContext context = new MyContext())
                {
                    foreach (ProfesorFuncionario prof in lProfesores)
                    {
                        context.Profesores.Add(prof);
                        
                    }
                    context.SaveChanges();
                }

                using (MyContext context = new MyContext())
                {
                    foreach (ProfesorExtendido profe in lProfesoresE)
                    {
                        context.OtrosDatosProfesores.Add(profe);
                        
                    }
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        //Método para rellenaro con los datos del maestro la interfaz
        private void MuestraProfesor()
        {

            if (lProfesores.Count > 0)
            {
                txtNombre.Text = lProfesores[iIndice].SNombre;
                txtApellidos.Text = lProfesores[iIndice].SApellidos;
                txtMail.Text = lProfesores[iIndice].Id;
                txtAnno.Text = lProfesores[iIndice].IAnyoIngresoCuerpo.ToString();

                imgFoto.Source = CargaImg(lProfesores[iIndice].SRutaFoto);
                if (lProfesores[iIndice].BDestinoDefinitivo)
                {
                    chb_DestinoDefinitivo.IsChecked = true;
                }
                cbEdad.SelectedValue = Convert.ToInt32(lProfesores[iIndice].IEdad);

                if (lProfesores[iIndice].TipoSeguro == TipoMedico.SeguridadSocial)
                {
                    lbSeguro.SelectedValue = "S.Social";
                }
                else
                {
                    lbSeguro.SelectedValue = "Muface";
                }
                if (lProfesores[iIndice].TipoProfesor == TipoFuncionario.EnPracticas)
                {
                    rdbPracticas.IsChecked = true;
                }
                else if (lProfesores[iIndice].TipoProfesor == TipoFuncionario.DeCarrera)
                {
                    rdbCarrera.IsChecked = true;
                }
            }
        }
        //Método que de la lectura del archivo carga la lista de los profesores funcionarios
        private void CargaLista(IEnumerable<string> lineas, ref List<ProfesorFuncionario> listaProfesores)
        {
            foreach (var linea in lineas)
            {
                string rutaFoto;
                string[] saProfesores = linea.Split(';');
                string nombre = saProfesores[0];
                string apellidos = saProfesores[1];
                int edad = int.Parse(saProfesores[2]);
                string email = saProfesores[3];
                string materia = saProfesores[4];
                TipoFuncionario tipoFuncionario = (TipoFuncionario)Enum.Parse(typeof(TipoFuncionario), saProfesores[5]);
                int annoIngreso = int.Parse(saProfesores[6]);
                bool destinoDefinitivo = bool.Parse(saProfesores[7]);
                TipoMedico tipoMedico = (TipoMedico)Enum.Parse(typeof(TipoMedico), saProfesores[8]);

                if (saProfesores.Length == 9)
                {

                    rutaFoto = rutaAvatar;

                    lProfesores.Add(new ProfesorFuncionario { SNombre = nombre, SRutaFoto = rutaFoto, SApellidos = apellidos, IEdad = edad, SMateria = materia, TipoProfesor = tipoFuncionario, BDestinoDefinitivo = destinoDefinitivo, IAnyoIngresoCuerpo = annoIngreso, TipoSeguro = tipoMedico, Id = email });

                }
                else
                {
                    rutaFoto = saProfesores[9];
                    lProfesores.Add(new ProfesorFuncionario { SNombre = nombre, SRutaFoto = rutaFoto, SApellidos = apellidos, IEdad = edad, SMateria = materia, TipoProfesor = tipoFuncionario, BDestinoDefinitivo = destinoDefinitivo, IAnyoIngresoCuerpo = annoIngreso, TipoSeguro = tipoMedico, Id = email });

                }


            }
            
        }
        //Acción del botón siguiente que muestra el siguiente profesor de la lista
        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            BotonesPrevOn();
            if (iIndice < lProfesores.Count - 1)
            {
                iIndice++; // Incrementa el índice si hay más profesores disponibles
                MuestraProfesor();
            }
            else
            {
                BotonesPostOff();
                MessageBox.Show("No hay más profesores disponibles.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //Acción del botón anterior que muestra el anterior profesor de la lista
        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            BotonesPostOn();
            if (iIndice > 0)
            {
                iIndice--; // Decrementa el índice si hay más profesores disponibles
                MuestraProfesor();
            }
            else
            {
                BotonesPrevOff();
                MessageBox.Show("No hay más profesores disponibles.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //Acción del botón primero que muestra el primer profesor de la lista
        private void Primero_Click(object sender, RoutedEventArgs e)
        {
            iIndice = 0;
            MuestraProfesor();
            BotonesPrevOff();
            BotonesPostOn();
        }
        //Acción del botón último que muestra el último profesor de la lista
        private void Ultimo_Click(object sender, RoutedEventArgs e)
        {
            iIndice = lProfesores.Count - 1;
            MuestraProfesor();
            BotonesPostOff();
            BotonesPrevOn();
        }
        //Método de filtro por edad
        private void Edad_Click(object sender, RoutedEventArgs e)
        {
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = lProfesores
                .Join(lProfesoresE, l => l.Id, s => s.SEmail, (l, s) => new { l.SNombre, l.SApellidos, l.IEdad, l.SMateria })
                .Where(l => l.IEdad > 35);

            Profes.ToList().ForEach(item =>
            {
                salida += $"Nombre: {item.SNombre}\nApellidos: {item.SApellidos}\nEdad: {item.IEdad}\nMateria: {item.SMateria}\n\n";
            });
            //MuestraResultado(salida, "edad");
            MuestraResultadoFiltro("edad", Profes);

        }
        //Método de filtro por año de ingreso
        private void Anno_Click(object sender, RoutedEventArgs e)
        {
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = lProfesores
            .Join(lProfesoresE, l => l.Id, s => s.SEmail, (l, s) => new
            {
                l.SNombre,
                l.SApellidos,
                l.IEdad,
                l.SMateria,
                Anno = l.IAnyoIngresoCuerpo,
                Destino = l.BDestinoDefinitivo ? "Sí" : "No",
                Seguro = l.TipoSeguro,
                l.TipoProfesor,
                l.Id,
                l.SRutaFoto
            })
             .Where(l => l.Anno >= 2010)
             .Select(item => $"Año ingreso Cuerpo: {item.Anno}\nDestino definitivo: {item.Destino}\nTipo médico: {item.Seguro}\nMateria: {item.SMateria}\nNombre: {item.SNombre}\nApellidos: {item.SApellidos}\nTipo: {item.TipoProfesor}\nEdad: {item.IEdad}\nEmail: {item.Id}\nRuta foto: {item.SRutaFoto}\n\n");

            MuestraResultado(string.Join("", Profes), "año de ingreso");
            //MuestraResultadoFiltro("año de ingreso", Profes);
        }
        //Método que usa las dos listas para mostrar agrupación por estado civil
        private void EstadoCivil_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         let estadoCiv = (s.TipoEstado)
                         group new
                         {
                             l.SNombre,
                             l.SApellidos,
                             l.IEdad,
                             s.IPeso,
                             s.IEstatura
                         }
                         by estadoCiv
                         into profAgrupados
                         select new
                         {
                             Status = profAgrupados.Key,
                             Valores = profAgrupados
                         };
            foreach (var item in Profes)
            {
                i++;
                salida = salida + "\n------------------------------------" + $"\nGRUPO: {item.Status}\n";
                foreach (var prof in item.Valores)
                {
                    salida = salida + $"\nNombre: {prof.SNombre}\nApellidos: {prof.SApellidos}\nEdad: {prof.IEdad}\nPeso: {prof.IPeso}\nEstatura: {prof.IEstatura}";
                }
            }
            MuestraResultadoGrupo(salida, "E.Civil: nombre, apellidos, edad, peso y estatura");
        }
        //Método que usa las dos listas para mostrar agrupación por estado civil y cuenta los integrantes de cada estado
        private void EstadoCount_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int j = 0;
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         let estadoCiv = (s.TipoEstado)
                         group new
                         {
                             l.SNombre

                         }
                         by estadoCiv
                         into profAgrupados
                         select new
                         {
                             Status = profAgrupados.Key,
                             Valores = profAgrupados
                         };
            foreach (var item in Profes)
            {
                i++;
                salida = salida + "\n------------------------------------" + $"\nGRUPO {item.Status} hay: \n";
                foreach (var prof in item.Valores)
                {
                    j++;
                }
                salida = salida + j;
                j = 0;
            }

            MuestraResultadoGrupo(salida, "E.Civil y cuenta");
        }
        ////Método que usa las dos listas para mostrar agrupación por edad
        private void Edad_groùp_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         let grupoEdad = (l.IEdad < 40 ? "joven" : (l.IEdad < 60 ? "maduro" : "por jubilarse"))
                         orderby l.IEdad descending
                         group new
                         {
                             l.SNombre,
                             l.SApellidos,
                             l.IEdad

                         }
                         by grupoEdad
                         into profAgrupados
                         select new
                         {
                             Status = profAgrupados.Key,
                             Valores = profAgrupados
                         };
            foreach (var item in Profes)
            {
                i++;
                salida = salida + "\n------------------------------------" + $"\nGRUPO {item.Status} hay: \n";
                foreach (var prof in item.Valores)
                {
                    salida = salida + $"\nNombre: {prof.SNombre}\nApellidos: {prof.SApellidos}\nEdad: {prof.IEdad}\n";
                }

            }
            MuestraResultadoGrupo(salida, "rangos de Edad ordenados por Edad descendente");
        }
        //Método que usa las dos listas para mostrar agrupación por tipo de seguro médico
        private void Seguro_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         where l.IEdad > 39
                         let segMedico = (l.TipoSeguro)
                         orderby s.IPeso, l.SApellidos
                         group new
                         {
                             l.SNombre,
                             l.SApellidos,
                             l.TipoSeguro,
                             s.IPeso

                         }
                         by segMedico
                         into profAgrupados
                         select new
                         {
                             Status = profAgrupados.Key,
                             Valores = profAgrupados
                         };
            foreach (var item in Profes)
            {
                i++;
                salida = salida + "\n------------------------------------" + $"\nGRUPO {item.Status} hay: \n";
                foreach (var prof in item.Valores)
                {
                    salida = salida + $"\nNombre: {prof.SNombre}\nApellidos: {prof.SApellidos}\nSeguro: {prof.TipoSeguro}\nPeso: {prof.IPeso}\n";
                }
            }
            MuestraResultadoGrupo(salida, "S.Médico, ordenado por Peso y Apellidos para mayores de 39 años");
        }
        //Filtro por año y estado civil
        private void AnnoEstado_Click(object sender, RoutedEventArgs e)
        {
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         where l.IAnyoIngresoCuerpo >= 2010
                         where s.TipoEstado == ProfesorExtendido.ECivil.Casado
                         select new
                         {
                             Nombre = l.SNombre,
                             Apellidos = l.SApellidos,
                             Anno = l.IAnyoIngresoCuerpo,
                             Estado = s.TipoEstado,

                         };

            foreach (var item in Profes)
            {
                salida += $"Año ingreso Cuerpo: {item.Anno}\nNombre: {item.Nombre}\nApellidos: {item.Apellidos}\nEstado: {item.Estado}\n\n";
            }
            //MuestraResultado(salida, "año de ingreso y estado civil");
            MuestraResultadoFiltro("año de ingreso y estado civil", Profes);
        }
        //Método de filtrado por estatura
        private void Estatura_Click(object sender, RoutedEventArgs e)
        {
            string salida = "";
            List<ProfesorExtendido> lProfesoresE = ProfesorExtendido.GetProfesE();
            var Profes = from l in lProfesores
                         join s in lProfesoresE on l.Id equals s.SEmail
                         where s.IEstatura > 160
                         orderby s.IEstatura descending, s.IPeso descending
                         select new
                         {
                             Nombre = l.SNombre,
                             Apellidos = l.SApellidos,
                             Edad = l.IEdad,
                             Estatura = s.IEstatura,
                             Peso = s.IPeso

                         };

            foreach (var item in Profes)
            {
                salida += $"Nombre: {item.Nombre}\nApellidos: {item.Apellidos}\nEdad: {item.Edad}\nEstatura: {item.Estatura}\nPeso: {item.Peso}\n\n";
            }
            //MuestraResultado(salida, "estatura");
            MuestraResultadoFiltro("estatura", Profes);
        }
        //Acción del click en el menú negrita que pone las fuentes en negrita
        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {
            negrita.IsChecked = true;
            FontWeight = FontWeights.Bold;

        }
        //Acción del desclicar en el menú negrita que pone las fuentes en normal
        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {
            negrita.IsChecked = false;
            FontWeight = FontWeights.Normal;

        }
        //Acción del click en el menú cursiva que pone las fuentes en cursiva
        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {
            cursiva.IsChecked = true;
            FontStyle = FontStyles.Italic;

        }
        //Acción del desclicar en el menú cursiva que pone las fuentes en normal
        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {
            cursiva.IsChecked = false;
            FontStyle = FontStyles.Normal;


        }
        //Método que desactiva los botones de primero y anterior
        private void BotonesPrevOff()
        {
            btnAnterior.IsEnabled = false;
            btnPrimero.IsEnabled = false;
        }
        //Método que activa los botones de primero y anterior
        private void BotonesPrevOn()
        {
            btnAnterior.IsEnabled = true;
            btnPrimero.IsEnabled = true;
        }
        //Método que desactiva los botones de último y siguiente
        private void BotonesPostOff()
        {
            btnSiguiente.IsEnabled = false;
            btnUltimo.IsEnabled = false;
        }
        //Método que desactiva los botones de último y siguiente
        private void BotonesPostOn()
        {
            btnSiguiente.IsEnabled = true;
            btnUltimo.IsEnabled = true;
        }

        private void Nuevo_click(object sender, RoutedEventArgs e)
        {
            Reseteo();

        }

        private void Reseteo()
        {
            Grid_Central.IsEnabled = true;
            txtMail.IsEnabled = false;
            LimpiarCampos();
            btnCancelar.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            imgFoto.Visibility = Visibility.Hidden;
            txtRutaFoto.Visibility = Visibility.Visible;
            lblRutaFoto.Visibility = Visibility.Visible;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtAnno.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtBlockMedico.Text = string.Empty;
            txtRutaFoto.Text = string.Empty;
        }

        private void ActivaCorreo(object sender, RoutedEventArgs e)
        {

            pTemporalBase.SNombre = txtNombre.Text;
            pTemporalBase.SApellidos = txtApellidos.Text;
            pTemporalBase.Id = "x";
            txtMail.Text = pTemporalBase.Id;
        }

        private void Cancelar_click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Está seguro de que desea Cancelar la operación", "Cancelar", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Reseteo();
                Grid_Central.IsEnabled = false;
                MuestraProfesor();
                BotonesPrevOn();
                BotonesPostOn();
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;


            }

        }
    }
}