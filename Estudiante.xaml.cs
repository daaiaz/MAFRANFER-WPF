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
            estu.sexo = Convert.ToString(cboSexo.SelectedItem);
            estu.telefono = txtTelefono.Text;
            estu.celular = txtCelular.Text;
            estu.fecha_nacimiento = (DateTime)DtpFecNac.SelectedDate;


            datos.estudiante.Add(estu);
            datos.SaveChanges();
            CargarDatosGrilla();

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DgvEstuExistentes.SelectedItem != null)
            {
                estudiante estu = (estudiante)DgvEstuExistentes.SelectedItem;
                estu.nro_documento = txtNroDoc.Text;
                estu.tipo_documento = txtTipoDoc.Text;
                estu.nombre = txtNombre.Text;
                estu.apellido = txtApellido.Text;
                estu.direccion = txtDireccion.Text;
                estu.email = txtMail.Text;
                estu.sexo = (string)cboSexo.SelectedItem;
                //estu.sexo = txtSexo.Text;
                estu.telefono = txtTelefono.Text;
                estu.celular = txtCelular.Text;
                estu.fecha_nacimiento = (DateTime)DtpFecNac.SelectedDate;

                datos.Entry(estu).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Estudiante de la grilla para modificar!");
        }

        private void DgvEstuExistentes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgvEstuExistentes.SelectedItem != null)
            {
                estudiante estu = (estudiante)DgvEstuExistentes.SelectedItem;


                txtNroDoc.Text = estu.nro_documento;
                txtTipoDoc.Text = estu.tipo_documento;
                txtNombre.Text = estu.nombre;
                txtApellido.Text = estu.apellido;
                txtDireccion.Text = estu.direccion;
                txtMail.Text = estu.email;
                cboSexo.SelectedItem = estu.sexo;
                //txtSexo.Text = estu.sexo;
                txtTelefono.Text = estu.telefono;
                txtCelular.Text = estu.celular;
                DtpFecNac.SelectedDate = estu.fecha_nacimiento;

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DgvEstuExistentes.SelectedItem != null)
            {
                estudiante estu = (estudiante)DgvEstuExistentes.SelectedItem;

                datos.estudiante.Remove(estu);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Estudiante de la grilla para eliminar!");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNroDoc.Text = string.Empty;
            txtTipoDoc.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtMail.Text = string.Empty;
            cboSexo.SelectedItem = -1;
            //txtSexo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCelular.Text = string.Empty;
            DtpFecNac.SelectedDate = DtpFecNac.DisplayDate;
        }
    }
}
