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
using ComprasUAQ.Windows.Forms;

namespace ComprasUAQ.Windows.Elements
{
    /// <summary>
    /// Interaction logic for MenuDesplegable.xaml
    /// </summary>
    public partial class MenuDesplegable : UserControl
    {
        public MenuDesplegable()
        {
            InitializeComponent();
        }

        private void DentroRequisiciones(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(165, 153, 153));
            label.Background = brush;
        }

        private void FueraRequisiciones(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            label.Background = brush;
        }

        private void DentroCompradores(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(165, 153, 153));
            label.Background = brush;
        }

        private void FueraCompradores(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            label.Background = brush;
        }

        private void DentroProveedores(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(165, 153, 153));
            label.Background = brush;
        }

        private void FUeraProveedores(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            label.Background = brush;
        }

        private void DentroCentroGastos(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(165, 153, 153));
            label.Background = brush;
        }

        private void FueraCentroGastos(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            label.Background = brush;
        }

        private void DentroAlmacen(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(165, 153, 153));
            label.Background = brush;
        }

        private void FueraAlmacen(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            Brush brush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            label.Background = brush;
        }

    }
}
