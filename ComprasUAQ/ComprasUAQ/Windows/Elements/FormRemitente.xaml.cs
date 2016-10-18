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
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;

namespace ComprasUAQ.Windows.Elements
{
    /// <summary>
    /// Interaction logic for FormRemitente.xaml
    /// </summary>
    public partial class FormRemitente : UserControl
    {
        public FormRemitente()
        {
            InitializeComponent();
        }

        private void validarId(object sender, TextCompositionEventArgs e)
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

        private void nuevoRemitente(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IdRemitente.Text);
            String nombre = Nombre.Text;
            String apellidoPaterno = ApellidoMaterno.Text;
            String apellidoMaterno = ApellidoMaterno.Text;
            Remitente remitente = new Remitente(id, nombre, apellidoPaterno, apellidoMaterno);
            RemitenteDAO remitenteDAO = new RemitenteDAO();
            int f = remitenteDAO.Insert(remitente);
            if (f == 0)
            {
                MessageBox.Show("Se agrego correctamente el comprador");
                IdRemitente.Text = "IdRemitente";
                Nombre.Text = "";
                ApellidoMaterno.Text = "";
                ApellidoPaterno.Text = "";
            }
        }

        private void limpiar(object sender, RoutedEventArgs e)
        {
            IdRemitente.Clear();
        }
    }
}
