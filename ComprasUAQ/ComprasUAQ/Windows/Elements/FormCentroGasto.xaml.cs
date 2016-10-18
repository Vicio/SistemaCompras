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
    /// Interaction logic for FormCentroGasto.xaml
    /// </summary>
    public partial class FormCentroGasto : UserControl
    {
        public FormCentroGasto()
        {
            InitializeComponent();
        }

        private void GuardarCentroGasto(object sender, RoutedEventArgs e)
        {
            String nombre = Nombre.Text;
            int id = Int32.Parse(IdCentroGasto.Text);
            CentroGasto centroGasto = new CentroGasto(id,nombre);
            CentroGastoDAO centroGastoDao = new CentroGastoDAO();
            int f = centroGastoDao.Insert(centroGasto);
            if (f == 0)
            {
                MessageBox.Show("Se agrego correctamente el Centro de Gasto");
                Nombre.Text = "";
                IdCentroGasto.Text = "IdCentroGasto";
            }
        }

        private void ValidarID(object sender, TextCompositionEventArgs e)
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

        private void limpiar(object sender, RoutedEventArgs e)
        {
            IdCentroGasto.Clear();
        }
    }
}
