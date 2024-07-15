using _IGraficasIES;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8._IGraficasIES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // Se cargan las imagenes de las fotos
            const string rutaImagenes = "..\\..\\..\\imagenes\\";
            const string rutaPrim = "primero.jpg";
            const string rutaAnt = "anterior.jpg";
            const string rutaSig = "siguiente.jpg";
            const string rutaUlt = "ultimo.jpg";
            string rutaProfe = "mujer.jpg";


            // Se cargan las imagenes de los botones
            imgFoto.Source = NewMethod(rutaImagenes, rutaProfe);
            imgPrimero.Source = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + rutaPrim) as ImageSource;
            imgAnterior.Source = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + rutaAnt) as ImageSource;
            imgSiguiente.Source = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + rutaSig) as ImageSource;
            imgUltimo.Source = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + rutaUlt) as ImageSource;






            // Se inhabilitan los menús y mallas indicados
            menuFiltros.IsEnabled = false;
            menuAgrupacion.IsEnabled = false;
            GridCentral.IsEnabled = false;
            GridBotones.IsEnabled = false;

        }

        private static ImageSource? NewMethod(string rutaImagenes, string rutaProfe)
        {
            return (new ImageSourceConverter()).ConvertFromString(rutaImagenes + rutaProfe) as ImageSource;
        }

        private void destino_Checked(object sender, RoutedEventArgs e)
        {

            chkDestino.IsChecked = true;
        }

        private void cmbEdad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 22; i < 71; i++)
            {
                cmbEdad.Items.Add(i);
            }
            //cmbEdad.SelectedValue = Convert.ToInt32(profesor.Edad);
            // Donde se crea la instancia profesor?
            // Para que se crea profesor? se van a mostrar los datos de un profesor?
            // Si es solo para insertar datos, no hace falta hacer el comando anterior
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si se van a mostrar datos, habra que recoger el dato y convertirlo a string para mostrarlo en la interfaz
            // Hacer un if para recoger el dato??
            lstSeguro.SelectedValue = "S.Social";
        }

        private void rbPracticas_Checked(object sender, RoutedEventArgs e)
        {
            // Se desea rescatar los datos?
            if (rbPracticas.IsChecked == true)
            {
                rbPracticas.IsChecked = true;
            }
        }

        private void Click_Abrir(object sender, RoutedEventArgs e)
        {
            // Ventana para abrir el archivo deseado
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true) //Cuando el usuario le dé a Aceptar
            {
                try
                {
                    var lineas = File.ReadLines(openFileDialog.FileName);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void Click_Salir(object sender, RoutedEventArgs e)
        {

        }

        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Click_btPrimero(object sender, RoutedEventArgs e)
        {

        }

        private void Click_btAnterior(object sender, RoutedEventArgs e)
        {

        }

        private void Click_btSiguiente(object sender, RoutedEventArgs e)
        {

        }

        private void Click_btUltimo(object sender, RoutedEventArgs e)
        {

        }
    }
}
