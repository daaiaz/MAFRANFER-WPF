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

namespace MAFRANFER_WPF
{
    /// <summary>
    /// Lógica de interacción para Estudiante.xaml
    /// </summary>
    public partial class Estudiante : Window
    {

        cursos_onlineEntities datos;

        public Estudiante()
        {
            InitializeComponent();

            datos = new cursos_onlineEntities();

        }

        private void CargarDatosGrilla()
        {
            try
            {

                DgvEstuExistentes.ItemsSource = datos.estudiante.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            estudiante estu = new estudiante();

            estu.nro_documento = txtNroDoc.Text;
            estu.tipo_documento = txtTipoDoc.Text;
            estu.nombre = txtNombre.Text;
            estu.apellido = txtApellido.Text;
            estu.direccion = txtDireccion.Text;
            estu.email = txtMail.Text;
            estu.sexo = (string)cboSexo.SelectedItem;
            estu.telefono = txtTelefono.Text;
            estu.celular = txtCelular.Text;
            estu.fecha_nacimiento = (DateTime)DtpFecNac.SelectedDate;


            datos.estudiante.Add(estu);
            datos.SaveChanges();
            CargarDatosGrilla();

        }
    }
}
