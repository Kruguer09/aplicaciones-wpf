using Microsoft.VisualBasic;
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

namespace MiBlockDeNotas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //7.	Interfaces Gráficas I (Grid, StackPanel, TextBox, Button, MessageBox), Ficheros y Excepciones
        //Primera aplicación de WPF que genera un block de notas donde podemos leer y escribir archivos de texto plano
        //Método que inicializa los componentes
        public MainWindow()
        {
            InitializeComponent();
        }
        //Método que define la funcionalidad del botón abrir. Abre archivo si existe
        private void buttonAbrir_Click(object sender, RoutedEventArgs e)
        {
            byte[] infoArchivo = new byte[1500];
            try
            {
                FileStream fsEscribir = new FileStream(txtOrigen.Text, FileMode.Open);
                try
                {
                    fsEscribir.Read(infoArchivo, 0, (int)fsEscribir.Length);
                    txtDocumento.Text = ASCIIEncoding.ASCII.GetString(infoArchivo);
                    fsEscribir.Close();
                }
                catch (Exception ex)
                {
                    SacaErrores("Tamaño de texto demasiado grande",txtDocumento);
                }




            }
            catch (ArgumentException ex)
            {
                SacaErrores("Campo de nombre de archivo vacío",txtOrigen);
                txtOrigen.Focus();
            }
            catch (FileNotFoundException ex)
            {
                string msg = ex.Message;
                SacaErrores(msg,txtOrigen);

            }
            }
        //Método que define la funcionalidad del botón abrir
        private void buttonBorrar_Click(object sender, RoutedEventArgs e)
        {
            txtOrigen.Clear();
            txtDestino.Clear();
            txtDocumento.Clear();
        }
        //Método del botón salir, que cierra el programa
        private void buttonSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //Método del botón guardar, que recoge el texto escrito y guarda el archivo. si existe lo sobreescribe.
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FileStream fsEscribir = new FileStream(txtDestino.Text, FileMode.Create);
                fsEscribir.Write(ASCIIEncoding.ASCII.GetBytes(txtDocumento.Text), 0, txtDocumento.Text.Length);
                fsEscribir.Close();
                txtOrigen.Clear();
                txtDestino.Clear();
                txtDocumento.Clear();
                MessageBox.Show("El archivo se ha guardado correctamente", "Informaciónn",MessageBoxButton.OK, MessageBoxImage.Information);
               
               
            }
            catch (ArgumentException ex)
            {
                SacaErrores("Campo de nombre de archivo vacío", txtDestino);

            }catch (IOException ex) {                
                SacaErrores("Acceso denegado a la ruta de guardado",txtDestino);

            }

        }
        //Método que gestiona el aviso de errores mediante MessageBox
        private void SacaErrores(String error, TextBox txt)
        {
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            txt.Focus();
        }
    }
}
