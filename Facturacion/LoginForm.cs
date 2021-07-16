using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion
{
    public partial class LoginForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            //VALIDACIONES PARA USUARIO Y CONTRASEÑA
            if (UsuariotextBox.Text == " ")
            {
                errorProvider1.SetError(UsuariotextBox, "Ingrese el Usuario");
                UsuariotextBox.Focus();
            }
            errorProvider1.SetError(UsuariotextBox, "");

            if (ContraseñatextBox.Text == "")
            {
                errorProvider1.SetError(ContraseñatextBox, "Ingrese contraseña");
                ContraseñatextBox.Focus();
                return;
            }
            errorProvider1.SetError(ContraseñatextBox, "");

            //LLAMAMOS AL FORMULARIO
            PrincipalForm formulario = new PrincipalForm();

            //OCULTA EL FORMULARIO DONDE NOS ENCONTRAMOS
            this.Hide();

            formulario.Show();
        }
    }
}
