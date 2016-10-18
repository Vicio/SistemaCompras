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
using System.Windows.Shapes;
using ComprasUAQ.POCO;
using ComprasUAQ.DAO;
using ComprasUAQ.Windows.Elements;


namespace ComprasUAQ.Windows.Forms
{
    /// <summary>
    /// Interaction logic for VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        Formulario formAlmacen = new Formulario();
        public VentanaPrincipal()
        {
            InitializeComponent();
            this.Pendientes.mostarPendientes();
        }

        private void Departamentos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < Departamentos.PanelImagenes.Children.Count; i++)
            {
                if (Departamentos.PanelImagenes.Children[i].IsMouseOver)
                {
                    string nombreImagen = Departamentos.RegresarNombreImagen(Departamentos.PanelImagenes.Children[i]);
                    RequisicionesDepartamento.MostrarContenido(nombreImagen);
                    RequisicionesDepartamento.CambiarTitulo(nombreImagen);
                    cambiarFecha(nombreImagen);

                }

            }

        }
        
        private void cambiarFecha(String titulo)
        {
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            List<Requisicion> requisicion = new List<Requisicion>();

            calendario.SelectedDate = null;
            requisicion = requisicionDAO.FindByCentroGasto(titulo);
            List<DateTime?> fechas = new List<DateTime?>();
            foreach (var fila in requisicion)
            {
                
                DateTime fecha = new DateTime();
                fecha = DateTime.Today;
                DateTime? fechaentrega = fila.GetFechaEntrega();

                if (fechaentrega != null)
                {
                    if (fechaentrega >= fecha)
                    {
                        calendario.SelectedDate= (DateTime)fechaentrega;
                    }
                }
               
                
            }
            
        }

       

        private void CerrarVentana(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Minimizar(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        
        private void SeleccionMenu(object sender, MouseEventArgs e)
        {
            
            imagenMenu.Source = new BitmapImage(new Uri("/ComprasUAQ;component/Images/Iconos/menu_boton_2.png", UriKind.Relative));
        }

        private void CreacionMenu(object sender, MouseButtonEventArgs e)
        {
            if (menuDespegable.IsVisible)
            {
                imagenMenu.Source = new BitmapImage(new Uri("/ComprasUAQ;component/Images/Iconos/menu_boton.png", UriKind.Relative));
                menuDespegable.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                imagenMenu.Source = new BitmapImage(new Uri("/ComprasUAQ;component/Images/Iconos/menu_boton_2.png", UriKind.Relative));
                menuDespegable.Visibility = System.Windows.Visibility.Visible;
            }
           
        }
        private void creaForm(object sender,MouseButtonEventHandler e)
        {
            for (int i = 0; i < menuDespegable.panel.Children.Count; i++)
            {
                if (menuDespegable.panel.Children[i].IsMouseOver)
                {
                    this.CreaFormulario(i);

                }

            }

        }

        private void MaximizarVentana(object sender, MouseButtonEventArgs e)
        {
            if( WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

            }
            else
            {
                WindowState = WindowState.Maximized;

            }
            
        }

        private void ArrastarVentana(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void CreaFormulario(int elemento)
        {
            switch (elemento)
            {
                case 0:
                    Departamentos.Visibility = Visibility.Visible;
                    RequisicionesDepartamento.Visibility = Visibility.Visible;
                    Pendientes.Visibility = Visibility.Visible;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;

                case 1:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Visible;
                    formCentroGasto.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Visible;
                    formComprador.Visibility = Visibility.Hidden;
                    formCentroGasto.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;

                case 3:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Hidden;
                    formCentroGasto.Visibility = Visibility.Visible;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;

                case 4:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Visible;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Hidden;
                    formCentroGasto.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Hidden;
                    formCentroGasto.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Visible;
                    formOrdenCompra.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    Departamentos.Visibility = Visibility.Hidden;
                    RequisicionesDepartamento.Visibility = Visibility.Hidden;
                    Pendientes.Visibility = Visibility.Hidden;
                    menuDespegable.Visibility = Visibility.Hidden;
                    FormAlmacen.Visibility = Visibility.Hidden;
                    formProveedor.Visibility = Visibility.Hidden;
                    formComprador.Visibility = Visibility.Hidden;
                    formCentroGasto.Visibility = Visibility.Hidden;
                    formRemitente.Visibility = Visibility.Hidden;
                    formOrdenCompra.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void creaForm(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < menuDespegable.panel.Children.Count; i++)
            {
                if (menuDespegable.panel.Children[i].IsMouseOver)
                {
                    this.CreaFormulario(i);
                }
            }
        }

        private void LeaveMenu(object sender, MouseEventArgs e)
        {
            imagenMenu.Source = new BitmapImage(new Uri("/ComprasUAQ;component/Images/Iconos/menu_boton.png", UriKind.Relative));
        }

        private void esconderMenu(object sender, MouseEventArgs e)
        {
            menuDespegable.Visibility = Visibility.Hidden;
        }
    }
}
