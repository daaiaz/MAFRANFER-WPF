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
    /// Lógica de interacción para w_Curso.xaml
    /// </summary>
    public partial class w_Curso : Window
    {
        cursos_onlineEntities datos;

        public w_Curso()
        {
            InitializeComponent();
            datos = new cursos_onlineEntities();
        }

        private void CargarDatosGrilla()
        {
            try
            {

                DgvCursosExistentes.ItemsSource = datos.curso.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            CursoClie c = new CursoClie();

            c.descripcion = txtDescripcion.Text;
            c.duracion = Convert.ToInt32(txtDuracion.Text);
            c.fecha_inicio = (DateTime)DtpFecInicio.SelectedDate;
            c.fecha_fin = (DateTime)DtpFecFin.SelectedDate;
            c.precio = Convert.ToInt32(txtPrecio.Text);
            c.profesor_id = 3;
            c.estado = cboEstado.Text;

            //datos.curso.Add((dynamic)c);
           // datos.SaveChanges();
            await CursoClie.NuevoCurso(c);
            CargarDatosGrilla();
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DgvCursosExistentes.SelectedItem != null)
            {
                CursoClie c = (CursoClie)DgvCursosExistentes.SelectedItem;
                c.descripcion = txtDescripcion.Text;
                c.duracion = Convert.ToInt32(txtDuracion.Text);
                c.fecha_inicio = (DateTime)DtpFecInicio.SelectedDate;
                c.fecha_fin = (DateTime)DtpFecFin.SelectedDate;
                c.precio = Convert.ToInt32(txtPrecio.Text);
                c.profesor_id = 3;
                c.estado = cboEstado.Text;

                await CursoClie.ActualizarCurso(c);
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el curso a modificar ");

            limpiarCurso();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DgvCursosExistentes.SelectedItem != null)
            {
                CursoClie c = (CursoClie)DgvCursosExistentes.SelectedItem;
                await CursoClie.EliminarCurso(c);
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el curso a eliminar ");

            limpiarCurso();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCurso();
        }

        private void limpiarCurso()
        {
            txtDescripcion.Text = string.Empty;
            txtDuracion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            DtpFecInicio.SelectedDate = DtpFecInicio.DisplayDate;
            DtpFecFin.SelectedDate = DtpFecFin.DisplayDate;
            cboEstado.SelectedItem = -1;
        }

        private void DgvCursosExistentes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgvCursosExistentes.SelectedItem != null)
            {
                CursoClie c = (CursoClie)DgvCursosExistentes.SelectedItem;

                txtDescripcion.Text = c.descripcion;
                txtDuracion.Text = c.duracion.ToString();
                txtPrecio.Text = c.precio.ToString();
                DtpFecInicio.SelectedDate = c.fecha_inicio;
                DtpFecFin.SelectedDate = c.fecha_fin;
                cboEstado.SelectedItem = c.estado;
            }
        }
    }
}
