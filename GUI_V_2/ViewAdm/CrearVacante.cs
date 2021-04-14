using GUI_V_2.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2.ViewAdm
{
    public partial class CrearVacante : Form
    {
        CD_Commands commands = new CD_Commands();
        public CrearVacante()
        {
            InitializeComponent();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CerrarForm();

        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            try
            {
                commands.executeCommand("INSERT INTO Puesto (Nombre,Descripcion,Nivel_Puesto,Salario_Minimo,Salario_Maximo,Estado)" +
                    " VALUES ('" + textBox1.Text.ToString() + "', '" +
                    textBox2.Text.ToString() + "', '" +
                    textBox3.Text.ToString() + "', '" +
                    textBox6.Text.ToString() + "', '" +
                    textBox7.Text.ToString() + "', '1')");

            }
            catch (Exception)
            {
                correcto = false;
            }
            if (correcto)
            {
                MessageBox.Show("Los datos fueron agregados correctamente", "Datos agregados");
                CerrarForm();
            }
               
            else
                MessageBox.Show("Hubo un error a la hora de agregar los datos", "Error");
        }

        private void CerrarForm()
        {
            PrincipalAdm.getInstance().Show();
            PrincipalAdm.getInstance().button2_Click(null, null);
            this.Close();
        }
    }
}
