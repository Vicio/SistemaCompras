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
    /// Interaction logic for FormOrdenCompra.xaml
    /// </summary>
    public partial class FormOrdenCompra : UserControl
    {
        public FormOrdenCompra()
        {
            InitializeComponent();
        }

        private void validarClave(object sender, TextCompositionEventArgs e)
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

        private void validarIdRequicicion(object sender, TextCompositionEventArgs e)
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

        private void validarIdCompra(object sender, TextCompositionEventArgs e)
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

        private void nuevoOrdenCompra(object sender, RoutedEventArgs e)
        {
            Requisicion requisicion = new Requisicion();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            long id = long.Parse(IdCompra.Text);
            int idRe = Int32.Parse(IdRequicicion.Text);
            requisicion = requisicionDAO.FindById(idRe);
            int? clave = Int32.Parse(Clave.Text);
            char tipoOrden = char.Parse(TipoOrden.Text);
            decimal monto = decimal.Parse(MotoCompra.Text);
            DateTime fechaOrden = DateTime.Parse(FechaOrden.Text);
            DateTime? fechaLimite = DateTime.Parse(FechaLimite.Text);
            DateTime? fechaEnviada = DateTime.Parse(FechaEnviada.Text);
            DateTime? fechaDevuelta = DateTime.Parse(FechaDeVuelta.Text);

            OrdenCompra ordenCompra = new OrdenCompra(id, requisicion, clave, tipoOrden, monto, fechaOrden, fechaLimite, fechaEnviada, fechaDevuelta);
            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            int f = ordenCompraDAO.Insert(ordenCompra);
            if (f == 0)
            {
                MessageBox.Show("Se agrego correctamente la orden de compra");
                IdCompra.Text = "IdCompra";
                IdRequicicion.Text = "IdRequisicion";
                Clave.Text = "Clave";
                TipoOrden.Text = "";
                MotoCompra.Text = "";
                FechaOrden.Text = "";
                FechaLimite.Text = "";
                FechaEnviada.Text = "";
                FechaDeVuelta.Text = "";
            }
        }

        private void limpiarClave(object sender, RoutedEventArgs e)
        {
            Clave.Clear();
        }

        private void limpiarIdRequisicion(object sender, RoutedEventArgs e)
        {
            IdRequicicion.Clear();
        }

        private void limpiarIdCompra(object sender, RoutedEventArgs e)
        {
            IdCompra.Clear();
        }

        private void limpiarTipoOrden(object sender, RoutedEventArgs e)
        {
            TipoOrden.Clear();
        }

        private void limpiarFechaOrden(object sender, RoutedEventArgs e)
        {
            FechaOrden.Clear();
        }

        private void limpiarFechaElavoracion(object sender, RoutedEventArgs e)
        {
            FechaLimite.Clear();
        }

        private void limpiarFechaEnviada(object sender, RoutedEventArgs e)
        {
            FechaEnviada.Clear();
        }

        private void limpiarFechaDevuelta(object sender, RoutedEventArgs e)
        {
            FechaDeVuelta.Clear();
        }
    }
}
