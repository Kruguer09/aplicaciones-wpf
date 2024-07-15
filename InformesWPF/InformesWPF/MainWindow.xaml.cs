using Microsoft.Reporting.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using DataSet = System.Data.DataSet;




namespace InformesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbTablas.Items.Add("Usuarios");
            cmbTablas.Items.Add("CentrosDeportivos");
            cmbTablas.Items.Add("Directores");
            cmbTablas.Items.Add("Pistas");
        }
        //Nos devuelve la tabla que contiene los datos asociados al INFORME
        private static DataTable GetData(string nomTabla)
        {
            DataSet ds = new DataSet();

            //Cadena de conexión
            string con = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CentrosDeportivos; " +
               "Integrated Security = True; Connect Timeout = 30; Encrypt = False; " +
               "TrustServerCertificate = False; ApplicationIntent = ReadWrite; " +
               "MultiSubnetFailover = False";

            //Creo la sentencia SQL, le asocio la cadena de conexión y preparo la consulta
            SqlCommand com = new SqlCommand();
            com.Connection = new SqlConnection(con);


            string sqlQuery = "SELECT * FROM " + nomTabla;

            //Creo un nuevo DataAdapter
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();

            //Ejecuto la sentencia SQL
            myDataAdapter.SelectCommand = new SqlCommand(sqlQuery, com.Connection);
            
            //Abro
            com.Connection.Open();

            //Relleno el DataSet con una nueva tabla 
            //cuyo contenido va a ser lo que haya en el DataAdapter
            myDataAdapter.Fill(ds, nomTabla);

            //Cierro
            com.Connection.Close();

            //Devuelvo la tabla del DataSet
            return ds.Tables[0];
        }
        private void GenerarInforme(string nomTabla)
        {
            string rutaIni = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string subcadena = rutaIni.Substring(0, rutaIni.LastIndexOf("bin"));
            string parametro;
            // cambio la ruta para el elemento Pistas deportivas
            
            string ruta = subcadena + "\\Reportes\\" + nomTabla + ".rdlc";
            reportViewer1.LocalReport.ReportPath = ruta;
            reportViewer1.LocalReport.DataSources.Clear();

            //El nuevo DataSource debe tener el mismo nombre que le hemos puesto
            //en el INFORME y la tabla cuyos datos queremos mostrar
            //vuelvo a cambiar el nombre de la tabla para el informe

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetData(nomTabla)));

            ReportParameter[] parameters = new ReportParameter[1];
            // Cambio el nombre del parámetro por el que tenga en el informe en funcion de la tabla
            if (nomTabla == "Usuarios")
                parametro = "Lista de los usuarios de los centros deportivos";
            else if (nomTabla == "CentrosDeportivos")
                parametro = "Información de los centros deportivos";
            else if (nomTabla == "Directores")
                parametro = "Directores de los centros deportivos";
            else if (nomTabla == "Pistas")
                parametro = "Todas las pistas de los centros deportivos";
            else
                parametro = "";


            parameters[0] = new ReportParameter("ReportParameter1", parametro);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();

        }
        private void btnInforme_OnClick(object sender, RoutedEventArgs e)
        {
            // Reviso que se haya seleccionado una tabla
            if (cmbTablas.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Debe seleccionar una tabla", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                GenerarInforme(cmbTablas.SelectedValue.ToString());
            }
            
        }
    }
}