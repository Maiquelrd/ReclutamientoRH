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
using GUI_V_2.Login;

namespace GUI_V_2
{
    public partial class PrincipalLogin : Form
    {
        CD_Commands connection = new CD_Commands();
        public PrincipalLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PrincipalLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "")
              {
                  if (txtpass.Text != "")
                {
                    UserModel user = new UserModel();
                         var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                         if (validLogin == true)
                         {


                           string validRol = user.getRol(txtuser.Text, txtpass.Text);
                        if (validRol == "1")
                        {
                            PrincipalAdm mainMenu = new PrincipalAdm();
                                   mainMenu.Show();
                                       this.Hide();
                        }
                        if (validRol == "2")
                        {
                            string test = connection.getSpecificData("select Usuario_ID from usuario where Username = '" + txtuser.Text + "' and Password='" + txtpass.Text + "';");
                            CurrentUser currentUser = new CurrentUser(Convert.ToInt32(test));
                            PrincipalUsr mainMenu = new PrincipalUsr();
                            mainMenu.Show();
                            this.Hide();
                        }
                    }
                        else
                         {
                          msgError("Nombre o contraseña incorrecto. \n intente de nuevo");
                           txtpass.Clear();
                           txtuser.Focus();

                        }
                }

            else msgError("Ingrese contraseña.");
            }
            else msgError("Ingrese nombre de usuario.");
        }
        private void msgError(string msg)
        {
            LblError.Text = "     " + msg;
            LblError.Visible = true;
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnlogin_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void PrincipalLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarUser frmRU = new RegistrarUser();
            frmRU.Show();
            this.Hide();

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
