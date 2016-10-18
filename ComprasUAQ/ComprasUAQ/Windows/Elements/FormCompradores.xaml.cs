using System;
using System.Collections.Generic;
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
using ComprasUAQ.POCO;
using ComprasUAQ.DAO;

namespace ComprasUAQ.Windows.Elements
{
    /// <summary>
    /// Interaction logic for FormCompradores.xaml
    /// </summary>
    public partial class FormCompradores : UserControl
    {
        public FormCompradores()
        {
            InitializeComponent();
        }

        private void ValidarId(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void nuevoComprador(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IdCompra.Text);
            String nombre = Nombre.Text;
            String apellidoPaterno = ApellidoMaterno.Text;
            String apellidoMaterno = ApellidoMaterno.Text;
            Comprador comprador = new Comprador(id, nombre, apellidoPaterno, apellidoMaterno);
            CompradorDAO compradorDAO = new CompradorDAO();
            int f = compradorDAO.Insert(comprador);
            if(f == 0)
            {
                MessageBox.Show("Se agrego correctamente el comprador");
                IdCompra.Text = "IdComprador";
                Nombre.Text = "";
                ApellidoMaterno.Text = "";
                ApellidoPaterno.Text = "";
            }
        }

        private void limpiar(object sender, RoutedEventArgs e)
        {
            IdCompra.Clear();
        }
    }
}
