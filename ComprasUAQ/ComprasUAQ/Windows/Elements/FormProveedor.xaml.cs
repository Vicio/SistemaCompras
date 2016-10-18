﻿using System;
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
    /// Interaction logic for FormProveedor.xaml
    /// </summary>
    public partial class FormProveedor : UserControl
    {
        public FormProveedor()
        {
            InitializeComponent();
        }


        private void ValidarIdNum(object sender, TextCompositionEventArgs e)
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

        private void guardarProveedor(object sender, RoutedEventArgs e)
        {
            String nombre = Nombre.Text;
            int id = Int32.Parse(IdProveedor.Text);
            Boolean perMoral;
            if (PersonaMoral.SelectedIndex == 0)
            {
                perMoral = false;
            }
            else
            {
                perMoral = true;
            }
            Proveedor proveedor = new Proveedor(id, nombre, perMoral);
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            int f = proveedorDAO.Insert(proveedor);
            if (f == 0)
            {
                MessageBox.Show("Se agrego correctamente el proveedor");
                Nombre.Text = "";
                IdProveedor.Text = "IdProveedor";
                PersonaMoral.SelectedIndex = 0;
            }
        }

        private void limpiar(object sender, RoutedEventArgs e)
        {
            IdProveedor.Clear();
        }
    }
}
