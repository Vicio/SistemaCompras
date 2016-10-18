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
using ComprasUAQ.Windows;


namespace ComprasUAQ.Windows.Elements
{
    /// <summary>
    /// Interaction logic for Pendientes.xaml
    /// </summary>
    public partial class Pendientes : UserControl
    {
        public Pendientes()
        {
            InitializeComponent();
        }
        public void mostarPendientes()
        {
            RequisicionDAO requisicionesDao = new RequisicionDAO();
            List<Requisicion> requision = new List<Requisicion>();
            requision = requisicionesDao.FindAll();
            
            foreach(var contenido in requision)
            {
                var clave = contenido.GetClave();
                var estado = contenido.GetEstado();

                switch (estado)
                {
                    case 'c':
                        break;
                    case 'f':
                        controlPendientes controlpendientesF = new controlPendientes();
                        controlpendientesF.lbClave.Content = clave;
                        controlpendientesF.lbestado.Content = "Firmas";
                        listBoxPendientes.Items.Add(controlpendientesF);
                        break;
                    case 'a':
                        controlPendientes controlpendientesA = new controlPendientes();
                        controlpendientesA.lbClave.Content = clave;
                        controlpendientesA.lbestado.Content = "Aprovado";
                        listBoxPendientes.Items.Add(controlpendientesA);
                        break;
                    case 'r':
                        controlPendientes controlpendientesR = new controlPendientes();
                        controlpendientesR.lbClave.Content = clave;
                        controlpendientesR.lbestado.Content = "Almacen";
                        listBoxPendientes.Items.Add(controlpendientesR);
                        break;

                }
                
            }
        }
    }
}
