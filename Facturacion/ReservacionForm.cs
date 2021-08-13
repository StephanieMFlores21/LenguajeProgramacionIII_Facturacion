using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturacion
{
    public partial class ReservacionForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ReservacionForm()
        {
            InitializeComponent();
        }

        //VARIABLE QUE GUARDARÁ LA OPERACIÓN A REALIZAR
        private string OperacionEjecutada = string.Empty;

        //EVENTO QUE SE EJECUTA AL CARGAR EL FORMULARIO
        private void ReservacionForm_Load(object sender, EventArgs e)
        {
            BaseDatosSoftwareHotel BaseHotel = new BaseDatosSoftwareHotel();

            CategoriacomboBox.DataSource = BaseHotel.CargarCategorias();

            //MUESTRA AL USUARIO LA COLUMNA 
            CategoriacomboBox.DisplayMember = "DESCRIPCION";

            //VALOR QUE NO SE MOSTRARÁ
            CategoriacomboBox.ValueMember = "ID";

            //LLAMAMOS LA FUNCION CREADA
            ListarEstadias();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            OperacionEjecutada = "Nuevo";
            HabilitarControles();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            //VALIDACION DESDE UNA CLASE
            if (string.IsNullOrEmpty(CodReservaciontextBox.Text))
            {
                errorProvider1.SetError(CodReservaciontextBox, "Ingrese codigo de habitación");
                CodReservaciontextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(FechaEntradaTextBox.Text))
            {
                errorProvider1.SetError(FechaEntradaTextBox, "Ingrese fecha de entrada");
                FechaEntradaTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(FechaSalidaTextBox.Text))
            {
                errorProvider1.SetError(FechaSalidaTextBox, "Ingrese fecha de salida");
                FechaSalidaTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider1.SetError(DescripciontextBox, "Ingrese una descripción");
                DescripciontextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PreciotextBox.Text))
            {
                errorProvider1.SetError(PreciotextBox, "Ingrese un precio");
                PreciotextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(HabitacionestextBox.Text))
            {
                errorProvider1.SetError(HabitacionestextBox, "Ingrese número de habitaciones");
                HabitacionestextBox.Focus();
                return;
            }

            BaseDatosSoftwareHotel BaseHotel = new BaseDatosSoftwareHotel();

            if (OperacionEjecutada == "Nuevo")
            {
                BaseHotel.InsertarEstadias(CodReservaciontextBox.Text, Convert.ToDateTime(FechaEntradaTextBox.Text), Convert.ToDateTime(FechaSalidaTextBox.Text), DescripciontextBox.Text, Convert.ToInt32(CategoriacomboBox.SelectedValue), Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(HabitacionestextBox.Text));
                
                //LLAMAMOS FUNCIONES CREADAS
                ListarEstadias();
                LimpiarControles();
                DeshabilitarControles();
            }
            else if (OperacionEjecutada == "Modificar")
            {
                bool modificar = BaseHotel.ModificacionEstadia(CodReservaciontextBox.Text, Convert.ToDateTime(FechaEntradaTextBox.Text), Convert.ToDateTime(FechaSalidaTextBox.Text), DescripciontextBox.Text, Convert.ToInt32(CategoriacomboBox.SelectedValue), Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(HabitacionestextBox.Text));

                ListarEstadias();
                LimpiarControles();
                DeshabilitarControles();
            }   
        }

        //AYUDARÁ A ENLISTAR LAS ESTADIAS
        private void ListarEstadias()
        {
            BaseDatosSoftwareHotel BaseHotel = new BaseDatosSoftwareHotel();

            //CARGA DE DATOS EN EL DATAGRIPVIEW
            EstadiasDataGridView.DataSource = BaseHotel.ListarEstadias();
        }

        //CLIC EN NUEVO PARA HABILITAR CONTROLES
        private void HabilitarControles()
        {
            CodReservaciontextBox.Enabled = true;
            FechaEntradaTextBox.Enabled = true;
            FechaSalidaTextBox.Enabled = true;
            DescripciontextBox.Enabled = true;
            CategoriacomboBox.Enabled = true;
            PreciotextBox.Enabled = true;
            HabitacionestextBox.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;

            Nuevobutton.Enabled = false;
            Modificarbutton.Enabled = false;
        }

        //CLIC EN NUEVO PARA DESHABILITAR CONTROLES
        private void DeshabilitarControles()
        {
            CodReservaciontextBox.Enabled = false;
            FechaEntradaTextBox.Enabled = false;
            FechaSalidaTextBox.Enabled = false;
            DescripciontextBox.Enabled = false;
            CategoriacomboBox.Enabled = false;
            PreciotextBox.Enabled = false;
            HabitacionestextBox.Enabled = false;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;

            Nuevobutton.Enabled = true;
            Modificarbutton.Enabled = true;
        }

        //FUNCION DE LIMPIEZA EN CONTROLES
        private void LimpiarControles()
        {
            CodReservaciontextBox.Clear();
            FechaEntradaTextBox.Clear ();
            FechaSalidaTextBox.Clear();
            DescripciontextBox.Clear();
            PreciotextBox.Clear();
            HabitacionestextBox.Clear();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            OperacionEjecutada = "Modificar";

            if (EstadiasDataGridView.SelectedRows.Count > 0)
            {
                CodReservaciontextBox.Text = EstadiasDataGridView.CurrentRow.Cells["CODHABITACION"].Value.ToString();
                FechaEntradaTextBox.Text = EstadiasDataGridView.CurrentRow.Cells["FECHAENTRADA"].Value.ToString();
                FechaSalidaTextBox.Text = EstadiasDataGridView.CurrentRow.Cells["FECHASALIDA"].Value.ToString();
                DescripciontextBox.Text = EstadiasDataGridView.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                CategoriacomboBox.Text = EstadiasDataGridView.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                PreciotextBox.Text = EstadiasDataGridView.CurrentRow.Cells["PRECIO"].Value.ToString();
                HabitacionestextBox.Text = EstadiasDataGridView.CurrentRow.Cells["HABITACION"].Value.ToString();

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Selecione la fila a modificar");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (EstadiasDataGridView.SelectedRows.Count > 0)
            {
                BaseDatosSoftwareHotel BaseHotel = new BaseDatosSoftwareHotel();

                bool eliminar = BaseHotel.EliminarEstadia(EstadiasDataGridView.CurrentRow.Cells[0].Value.ToString());

                ListarEstadias();
            }
            else
            {
                MessageBox.Show("Selecione la fila a eliminar");
            }
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO PERMITE NUMEROS Y PUNTO, PERMITE BORRAR LO INGRESADO
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //PERMITIRÁ SOLO UN PUNTO
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
