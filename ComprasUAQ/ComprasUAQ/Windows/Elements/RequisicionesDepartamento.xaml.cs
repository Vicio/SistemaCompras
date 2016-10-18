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
    /// Interaction logic for RequisicionesDepartamento.xaml
    /// </summary>
    public partial class RequisicionesDepartamento : UserControl
    {
        public RequisicionesDepartamento()
        {
            InitializeComponent();
        }

        public void CambiarTitulo(string titulo)
        {
            idPanelCentral.Content = titulo;

            if (titulo == "CIENCIAS NATURALES")
            {
                Brush brush = new SolidColorBrush(Color.FromRgb(97, 166, 15));
                ColorPanelCentral.Background = brush;
            }
            else
            {
                if (titulo == "QUIMICA")
                {
                    Brush brush = new SolidColorBrush(Color.FromRgb(230, 60, 45));
                    ColorPanelCentral.Background = brush;
                }
                else
                {
                    if (titulo == "INGENIERIA")
                    {
                        Brush brush = new SolidColorBrush(Color.FromRgb(217, 35, 47));
                        ColorPanelCentral.Background = brush;
                    }
                    else
                    {
                        if (titulo == "DERECHO")
                        {
                            Brush brush = new SolidColorBrush(Color.FromRgb(144, 145, 149));
                            ColorPanelCentral.Background = brush;
                        }
                        else
                        {
                            if (titulo == "BELLAS ARTES")
                            {
                                Brush brush = new SolidColorBrush(Color.FromRgb(90, 67, 149));
                                ColorPanelCentral.Background = brush;
                            }
                            else
                            {
                                if (titulo == "CIENCIAS POLITICAS Y SOCIALES")
                                {
                                    Brush brush = new SolidColorBrush(Color.FromRgb(1, 174, 216));
                                    ColorPanelCentral.Background = brush;
                                }
                                else
                                {
                                    if (titulo == "MEDICINA")
                                    {
                                        Brush brush = new SolidColorBrush(Color.FromRgb(1, 85, 147));
                                        ColorPanelCentral.Background = brush;
                                    }
                                    else
                                    {
                                        if (titulo == "PSICOLOGIA")
                                        {
                                            Brush brush = new SolidColorBrush(Color.FromRgb(0, 97, 168));
                                            ColorPanelCentral.Background = brush;
                                        }
                                        else
                                        {
                                            if (titulo == "BACHILLERES")
                                            {
                                                Brush brush = new SolidColorBrush(Color.FromRgb(87, 178, 206));
                                                ColorPanelCentral.Background = brush;
                                            }
                                            else
                                            {
                                                if (titulo == "ENFERMERIA")
                                                {
                                                    Brush brush = new SolidColorBrush(Color.FromRgb(0, 168, 163));
                                                    ColorPanelCentral.Background = brush;
                                                }
                                                else
                                                {
                                                    if (titulo == "INFORMATICA")
                                                    {
                                                        Brush brush = new SolidColorBrush(Color.FromRgb(0, 104, 81));
                                                        ColorPanelCentral.Background = brush;
                                                    }
                                                    else
                                                    {
                                                        if (titulo == "LENGUAS Y LETRAS")
                                                        {
                                                            Brush brush = new SolidColorBrush(Color.FromRgb(234, 214, 55));
                                                            ColorPanelCentral.Background = brush;
                                                        }
                                                        else
                                                        {
                                                            if (titulo == "CONTABILIDAD")
                                                            {
                                                                Brush brush = new SolidColorBrush(Color.FromRgb(0, 74, 135));
                                                                ColorPanelCentral.Background = brush;
                                                            }
                                                            else
                                                            {
                                                                if (titulo == "FILOSOFIA")
                                                                {
                                                                    Brush brush = new SolidColorBrush(Color.FromRgb(254, 144, 21));
                                                                    ColorPanelCentral.Background = brush;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void MostrarContenido(string titulo)
        {
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            List<Requisicion> requisicion = new List<Requisicion>();

            requisicion = requisicionDAO.FindByCentroGasto(titulo);

            listBoxContenido.Items.Clear();
            foreach (var fila in requisicion)
            {
                var estado = fila.GetEstado();
                switch (estado)
                {
                    case 'c':
                        controlEstado controlestadoC = new controlEstado(); 
                        Brush brushC = new SolidColorBrush(Color.FromRgb(254, 0, 0));
                        controlestadoC.LaClaveRequisicion.Content = fila.GetClave();
                        controlestadoC.laProveedor.Content = fila.GetProveedor().GetNombre();
                        controlestadoC.rbCancelado.Fill = brushC;
                        listBoxContenido.Items.Add(controlestadoC);
                        
                        break;
                    case 'f':
                        controlEstado controlestadoF = new controlEstado();
                        Brush brushF = new SolidColorBrush(Color.FromRgb(254, 144, 21));
                        controlestadoF.LaClaveRequisicion.Content = fila.GetClave();
                        controlestadoF.laProveedor.Content = fila.GetProveedor().GetNombre();
                        controlestadoF.rbFirmas.Fill= brushF;
                        listBoxContenido.Items.Add(controlestadoF);
                        break;
                    case 'a':
                        controlEstado controlestadoA = new controlEstado();
                        Brush brushA = new SolidColorBrush(Color.FromRgb(0, 255, 1));
                        controlestadoA.LaClaveRequisicion.Content = fila.GetClave();
                        controlestadoA.laProveedor.Content = fila.GetProveedor().GetNombre();
                        controlestadoA.rbAprovado.Fill = brushA;
                        listBoxContenido.Items.Add(controlestadoA);
                        break;
                    case 'r':
                        controlEstado controlestadoR = new controlEstado();
                        Brush brushR = new SolidColorBrush(Color.FromRgb(1, 174, 216));
                        controlestadoR.LaClaveRequisicion.Content = fila.GetClave();
                        controlestadoR.laProveedor.Content = fila.GetProveedor().GetNombre();
                        controlestadoR.rbAlmacen.Fill= brushR;
                        listBoxContenido.Items.Add(controlestadoR);
                        break;

                }
                
                
            }
        }
    }
}
