using System;
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


using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace TareaPA_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Listar = RolesBBL.GetLista();
            Ventanaconsultar.ItemsSource = Listar;
        }

        public void ClickGuardar_Button(object sender, RoutedEventArgs e)
        {
            Roles role = new Roles(Rolid.Text, Descripcionn.Text, FechaCreacion.Text);
            var Listar = RolesBBL.GetLista();
            Ventanaconsultar.ItemsSource = Listar;
            if (!RolesBBL.Existe(Descripcionn.Text))
            {
                var paso = RolesBBL.Insertar(role);
                
                MessageBox.Show("Se ha agregado exitozamente");
                
            }else{
                MessageBox.Show("La descripcion que ingreso ya existe");
            }
        }
        public void ClickEditar_Button(object sender, RoutedEventArgs e)
        {

            Roles tarea = new Roles(Rolid.Text, Descripcionn.Text, FechaCreacion.Text);

            if (!RolesBBL.Existe(Rolid.Text))
            {
                var paso = RolesBBL.Modificar(tarea);
                MessageBox.Show("Se ha editado el roles");
            }
            else
            {
                MessageBox.Show("Error no se puede editar un Id que no existe");
            }
        }

        public void ClickEliminar_Button(object sender, RoutedEventArgs e)
        {

            if (RolesBBL.Eliminar(Rolid.Text))
            {

                MessageBox.Show("Registro Eliminado", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
