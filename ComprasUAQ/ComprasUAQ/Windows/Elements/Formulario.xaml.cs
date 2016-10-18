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
    /// Interaction logic for Formulario.xaml
    /// </summary>
    public partial class Formulario : UserControl
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void GuardarRecepcioNalmacen(object sender, RoutedEventArgs e)
        {
            RequisicionDAO reuisicionDAO = new RequisicionDAO();
            Requisicion idRequisicion = reuisicionDAO.FindById(Int32.Parse(IdRequicicion.Text));
            RemitenteDAO proveedorDAO = new RemitenteDAO();
            Remitente idProveedor = proveedorDAO.FindById(Int32.Parse(IdProveedor.Text));
            int idRecepcionAlmacen = Int32.Parse(IdRecepcionAlmacen.Text);
            int claveRecepcion= Int32.Parse(ClaveRecepcionAlmacen.Text);
            DateTime fecharecepcion = DateTime.Parse(FechaRecepcion.Text);
            decimal monto = decimal.Parse(Monto.Text);
            DateTime fechaEntrega = DateTime.Parse(FechaEntrega.Text);
            string numeroResguardo = NumeroDeResguardo.Text;
            
            RecepcionAlmacen recepcionAlmacen = new RecepcionAlmacen(idRecepcionAlmacen,idRequisicion,idProveedor,claveRecepcion,fechaEntrega,fecharecepcion,monto,numeroResguardo);
            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();
            int f = recepcionAlmacenDAO.Insert(recepcionAlmacen);
            if (f == 0)
            {
                MessageBox.Show("Se agrego correctamente el proveedor");
                IdProveedor.Text = "";
                IdRequicicion.Text = "";
                IdRecepcionAlmacen.Text = "IdProveedor";
                ClaveRecepcionAlmacen.Text = "";
                FechaRecepcion.Text = "";
                FechaEntrega.Text = "";
                Monto.Text = "";
                NumeroDeResguardo.Text = "";
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

        private void limpiarIdRecepcion(object sender, RoutedEventArgs e)
        {
            IdRecepcionAlmacen.Clear();
        }

        private void limpiarFechaRecepcion(object sender, RoutedEventArgs e)
        {
            FechaRecepcion.Clear();
        }

        private void limpiarFechaEntrega(object sender, RoutedEventArgs e)
        {
            FechaEntrega.Clear();
        }
    }
}
