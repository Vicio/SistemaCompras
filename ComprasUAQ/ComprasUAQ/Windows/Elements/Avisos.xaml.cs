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
    /// Interaction logic for Avisos.xaml
    /// </summary>
    public partial class Avisos : UserControl
    {
        public Avisos()
        {
            InitializeComponent();
        }
        public void mostarAvisos()
        {
            RequisicionDAO requisicionesDao = new RequisicionDAO();
            List<Requisicion> requision = new List<Requisicion>();
            requision = requisicionesDao.FindAll();

            foreach (var contenido in requision)
            {
                var clave = contenido.GetClave();
                var estado = contenido.GetEstado();
                this.listBoxAvisos.Items.Add(clave + "        " + estado);
            }
        }
    }
}
