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
    public partial class PrincipalForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        Usuarios frmUsuarios;
        ReservacionForm frmReservacion;
        ClientesForm frmClientes;
        FacturacionForm frmFacturacion;
        private void UsuariostoolStripExp_Click(object sender, EventArgs e)
        {
            if (frmUsuarios == null)
            {
                frmUsuarios = new Usuarios();
                frmUsuarios.MdiParent = this;
                frmUsuarios.FormClosed += FrmUsuarios_FormClosed;
                frmUsuarios.Show();
            }
            else
            {
                frmUsuarios.Activate();
            }
        }

        private void FrmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUsuarios = null;
        }

        private void ClientestoolStripButton_Click(object sender, EventArgs e)
        {
            if (frmClientes == null)
            {
                frmClientes = new ClientesForm();
                frmClientes.MdiParent = this;
                frmClientes.FormClosed += FrmClientes_FormClosed;
                frmClientes.Show();
            }
            else
            {
                frmClientes.Activate();
            }
        }

        private void FrmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmClientes = null;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (frmFacturacion == null)
            {
                frmFacturacion = new FacturacionForm();
                frmFacturacion.MdiParent = this;
                frmFacturacion.FormClosed += FrmFacturacion_FormClosed;
                frmFacturacion.Show();
            }
            else
            {
                frmFacturacion.Activate();
            }
        }

        private void FrmFacturacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFacturacion = null;
        }

        private void HabitacionestoolStripButton_Click(object sender, EventArgs e)
        {
            if (frmReservacion == null)
            {
                frmReservacion = new ReservacionForm();
                frmReservacion.MdiParent = this;
                frmReservacion.FormClosed += FrmReservacion_FormClosed;
                frmReservacion.Show();
            }
            else
            {
                frmReservacion.Activate();
            }
        }

        private void FrmReservacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReservacion = null;
        }
    }
}
