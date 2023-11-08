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
using Microsoft.Win32;
namespace Formulario_de_Hugo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
           
            textBox.Text = string.Empty;
            
        }

        private void Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtDireccion")
                {
                    textBox.Text = "Direccion";
                }
                else if (textBox.Name == "txtCiudad")
                {
                    textBox.Text = "Ciudad";
                }
                else if (textBox.Name == "txtProvincia")
                {
                    textBox.Text = "Provincia";
                }
                else if (textBox.Name == "txtCodigoPostal")
                {
                    textBox.Text = "Código Postal";
                }
                else if (textBox.Name == "txtPais")
                {
                    textBox.Text = "País";
                }
               
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            MenuItem menuItem = (MenuItem)sender;
            string rolSeleccionado = menuItem.Header.ToString();
            principalMenu.Header = rolSeleccionado;
        }

        private void GuardarButton(object sender, RoutedEventArgs e)
        {
            
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            
            var empleado = new { Nombre = nombre, Apellidos = apellidos, Email = email, Telefono = telefono };

            dataGrid.Items.Add(empleado);

  
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }

        private void CargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath));
                imagenCargada.Source = bitmap;
            }
        }

        private void CancelarButton(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
