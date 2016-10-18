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
using ComprasUAQ.Windows;

namespace ComprasUAQ.Windows.Elements
{
    /// <summary>
    /// Interaction logic for Departamentos.xaml
    /// </summary>
    public partial class Departamentos : UserControl
    {
        public Departamentos()
        {
            InitializeComponent();
        }

        public string RegresarNombreImagen(UIElement Imagen)
        {
            Image imagen = (Image)Imagen;
            string nombre_Imagen = imagen.Name;

            if(nombre_Imagen == "Naturales")
            {
                nombre_Imagen = "CIENCIAS NATURALES";
            }
            else
            {
                if(nombre_Imagen == "Quimica")
                {
                    nombre_Imagen = "QUIMICA";
                }
                else
                {
                    if(nombre_Imagen == "Ingenieria")
                    {
                        nombre_Imagen = "INGENIERIA";
                    }
                    else
                    {
                        if(nombre_Imagen == "Derecho")
                        {
                            nombre_Imagen = "DERECHO";
                        }
                        else
                        {
                            if(nombre_Imagen == "Artes")
                            {
                                nombre_Imagen = "BELLAS ARTES";
                            }
                            else
                            {
                                if(nombre_Imagen == "Politicas")
                                {
                                    nombre_Imagen = "CIENCIAS POLITICAS Y SOCIALES";
                                }
                                else
                                {
                                    if(nombre_Imagen == "Medicina")
                                    {
                                        nombre_Imagen = "MEDICINA";
                                    }
                                    else
                                    {
                                        if(nombre_Imagen == "Psicologia")
                                        {
                                            nombre_Imagen = "PSICOLOGIA";
                                        }
                                        else
                                        {
                                            if(nombre_Imagen == "Bachilleres")
                                            {
                                                nombre_Imagen = "BACHILLERES";
                                            }
                                            else
                                            {
                                                if(nombre_Imagen == "Enfermeria")
                                                {
                                                    nombre_Imagen = "ENFERMERIA";
                                                }
                                                else
                                                {
                                                    if(nombre_Imagen == "Informatica")
                                                    {
                                                        nombre_Imagen = "INFORMATICA";
                                                    }
                                                    else
                                                    {
                                                        if(nombre_Imagen == "Letras")
                                                        {
                                                            nombre_Imagen = "LENGUAS Y LETRAS";
                                                        }
                                                        else
                                                        {
                                                            if(nombre_Imagen == "Contabilidad")
                                                            {
                                                                nombre_Imagen = "CONTABILIDAD";
                                                            }
                                                            else
                                                            {
                                                                if(nombre_Imagen == "Filosofia")
                                                                {
                                                                    nombre_Imagen = "FILOSOFIA";
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

            return nombre_Imagen;
        }

    }
}
