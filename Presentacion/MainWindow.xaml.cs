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
using Negocio;
using Datos;


namespace Presentacion
{
    public partial class MainWindow : Window
    {
        CategoriaBLL catBll = new CategoriaBLL();
        TareaBLL tarBLL = new TareaBLL();

        public MainWindow()
        {
            InitializeComponent();
            CargarCategorias();
            CargarEstados();
            CargarTareas();
        }

        private void CmdAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            catBll.Add(nombre);
            txtNombre.Text = string.Empty;

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            lstCategorias.ItemsSource = null;
            lstCategorias.ItemsSource = catBll.GetAll();

            cmbCategorias.ItemsSource = null;
            cmbCategorias.ItemsSource = catBll.GetAll();
        }

        private void CargarEstados()
        {
            cmbEstado.ItemsSource = Enum.GetValues(typeof(Estados));
            cmbEstado.SelectedValue = Estados.Pendiente;
        }

        private void CmdAgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string cuerpo = txtCuerpo.Text;
            DateTime fechaCreacion = DateTime.Today;
            DateTime fechaVencimiento = (DateTime)dpFechaVencimiento.SelectedDate;
            Categoria categoria = (Categoria)cmbCategorias.SelectedItem;
            Estados estado = (Estados)cmbEstado.SelectedItem;
            int num = 0;
            if (estado==Estados.Pendiente)
            {
                num = 0;
            }
            else if (estado == Estados.Postpuesto)
            {
                num = 1;
            }
            else if (estado == Estados.Terminado)
            {
                num = 2;
            }

            tarBLL.Add(titulo, cuerpo, num, categoria.Id, fechaCreacion, fechaVencimiento);
            
            CargarCategorias();
            CargarTareas();
        }

        private void CargarTareas()
        {
            lstTareas.ItemsSource = null;
            lstTareas.ItemsSource = tarBLL.GetAll();
        }

    }
}
