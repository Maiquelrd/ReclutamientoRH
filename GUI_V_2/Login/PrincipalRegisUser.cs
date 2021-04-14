using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GUI_V_2.Helpers;

namespace GUI_V_2.Login
{
    public partial class RegistrarUser : Form
    {
        public RegistrarUser()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnlogin_Click(object sender, EventArgs e)
        {
            CD_Commands commands = new CD_Commands();
            bool correcto = true;
            if (txtpass.Text == txtpassR.Text)
            {
                try
                {
                    commands.executeCommand("INSERT INTO Persona (Nombres,Apellidos,Cedula,Fecha_Nacimiento,Genero) VALUES ('" + txtNombre.Text.ToString() + "', '" +
                        TxtApell.Text.ToString() + "', '" +
                        txtCedula.Text.ToString() + "', '" +
                        txtFechaNaci.Text.ToString() + "', '" +
                        txtGenero.Text.ToString() + "')");

                }
                catch (Exception)
                {
                    correcto = false;
                }
                if (correcto)
                {
                    try
                    {
                        string id = commands.getSpecificData("SELECT MAX(Persona_ID) as maxid FROM Persona");
                        commands.executeCommand("INSERT INTO Candidato (Persona_ID,Recomendado_Por) VALUES ('" + id + "', '" +
                        txtRecom.Text.ToString() + "')");
                    }
                    catch (Exception)
                    {
                        correcto = false;
                    }
                }

                if (correcto)
                {
                    try
                    {
                        string id = commands.getSpecificData("SELECT MAX(Persona_ID) as maxid FROM Persona");
                        commands.executeCommand("INSERT INTO Usuario (Persona_ID,Rol_ID, Username, Password) VALUES ('" + id + "',2, '" +
                        txtuser.Text.ToString() + "', '" +
                        txtpass.Text.ToString() + "')");
                    }
                    catch (Exception)
                    {
                        correcto = false;
                    }
                    if (correcto)
                    {
                        MessageBox.Show("Usuario Registrado Correctamente", "Registro Completo");
                        PrincipalLogin frmlog = new PrincipalLogin();
                        frmlog.Show();

                        this.Close();
                    }

                    else
                        MessageBox.Show("Los datos no son correctos, No se pudo completar el registro", "Error");
                }

            }

            else
                    MessageBox.Show("Las contraseñas no coinciden", "Error");
        }


        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {

        }

        private void txtpass_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void RegistrarUser_MouseDown(object sender, MouseEventArgs e)
        {
                        ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
