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
    public partial class Usuarios : Syncfusion.Windows.Forms.Office2010Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private string OperacionEjecutada = string.Empty;

        //VARIABLE GLOBAL
        BaseDatosSoftwareHotel BaseHotel = new BaseDatosSoftwareHotel();
        
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            OperacionEjecutada = "Nuevo";
            HabilitarControles();
        }

        //EVENTO QUE SE EJECUTA AL CARGAR EL FORMULARIO
        private void Usuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        //CLIC EN NUEVO PARA HABILITAR CONTROLES
        private void HabilitarControles()
        {
            CodigoUsusTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ContraseñatextBox.Enabled = true;

            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;

            Nuevobutton.Enabled = false;
            Modificarbutton.Enabled = false;
        }

        //CLIC EN NUEVO PARA DESHABILITAR CONTROLES
        private void DeshabilitarControles()
        {
            CodigoUsusTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ContraseñatextBox.Enabled = false;

            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;

            Nuevobutton.Enabled = true;
            Modificarbutton.Enabled = true;
        }

        //FUNCION DE LIMPIEZA EN CONTROLES
        private void LimpiarControles()
        {
            CodigoUsusTextBox.Clear();
            NombreTextBox.Clear();
            ContraseñatextBox.Clear();
        }

        //AYUDARÁ A ENLISTAR LOS USUARIOS
        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = BaseHotel.CargarUsuarios();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (OperacionEjecutada == "Nuevo")
            {
                bool insertar = BaseHotel.InsertarUsuario(CodigoUsusTextBox.Text, NombreTextBox.Text, ContraseñatextBox.Text);

                ListarUsuarios();
                LimpiarControles();
                //DeshabilitarControles();
            }
            else if(OperacionEjecutada  == "Modificar")
            {
                bool modificar = BaseHotel.ModificacionUsuario(CodigoUsusTextBox.Text, NombreTextBox.Text, ContraseñatextBox.Text);

                ListarUsuarios();
                LimpiarControles();
                //DeshabilitarControles();
            }
        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            OperacionEjecutada = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoUsusTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["CODIGO"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                ContraseñatextBox.Text = UsuariosDataGridView.CurrentRow.Cells["CONTRASEÑA"].Value.ToString();

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Selecione el usuario a modificar");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool eliminar = BaseHotel.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells[0].Value.ToString());

                ListarUsuarios();
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Selecione el usuario a eliminar");
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }
    }
}
