using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2.ViewCandidates
{
    public partial class CrearCompetencia : Form
    {
        CD_Commands commands = new CD_Commands();
        string candidatoID = CurrentUser.GetInstance().candidatoID;

        public CrearCompetencia()
        {
            InitializeComponent();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            bool cb = checkBox1.Checked;
            int cbVal;
            try
            {
                if(cb)
                {
                    cbVal = 1;
                }
                else
                {
                    cbVal = 0;
                }
                commands.executeCommand("INSERT INTO Competencia (Candidato_ID,Descripcion, Estado) VALUES ("+ candidatoID + ",'" + textBox1.Text + "',"+cbVal+")");
            }
            catch (Exception)
            {
                correcto = false;
            }

            if (correcto)
            {
                MessageBox.Show("Los datos fueron agregados correctamente", "Datos agregados");
                PrincipalUsr.getInstance().Show();
                this.Close();
            }
            else
                MessageBox.Show("Hubo un error a la hora de agregar los datos", "Error");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Activo";
            }
            else
            {
                checkBox1.Text = "Inactivo";
            }
        }

        private void CrearCompetencia_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PrincipalUsr.getInstance().Show();
            this.Close();
        }
    }
}
