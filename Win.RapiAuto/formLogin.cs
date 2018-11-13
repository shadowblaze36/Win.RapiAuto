﻿using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class formLogin : Form
    {
        SeguridadBL _seguridad;

        public formLogin()
        {
            InitializeComponent();
            _seguridad = new SeguridadBL();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;

            usuario = txtUsuario.Text;
            contrasena = txtContraseña.Text;

            btAceptar.Enabled = false;
            btAceptar.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contrasena);

            if (resultado == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }

            btAceptar.Enabled = true;
            btAceptar.Text = "Aceptar";
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
