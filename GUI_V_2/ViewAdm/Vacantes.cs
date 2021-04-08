using GUI_V_2.Helpers;
using GUI_V_2.ViewAdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2
{
    public partial class Vacantes : Form
    {
        CD_Commands puestos = new CD_Commands();

        public Vacantes()
        {
            InitializeComponent();
        }

        public void LoadData()
        {

            dataGridView1.DataSource = puestos.getData("SELECT Nombre,Descripcion,Nivel_Puesto,Salario_Minimo,Salario_Maximo from puesto where Estado = 1; ");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            bool correcto = true;
            try
            {
                puestos.executeCommand("Update Puesto set Nombre='" + row.Cells[1].Value.ToString() +
                   "', Descripcion='" + row.Cells[2].Value.ToString() +
                   "', Nivel_Puesto='" + row.Cells[7].Value.ToString() +
                   "', Salario_Minimo='" + Datefix.FixDate(row.Cells[8].Value.ToString()) +
                   "', Salario_Maximo='" + row.Cells[9].Value.ToString() +
                   "' from Puesto where Puesto_ID = '" + row.Cells[0].Value.ToString() + "'");

            }
            catch (Exception)
            {
                correcto = false;
            }

            if (correcto)
                MessageBox.Show("Los datos fueron modificados correctamente", "Datos cambiados");
            else
                MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
            LoadData();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            puestos.executeCommand("Update puesto set Estado='0' where Puesto_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void Vacantes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearVacante crear = new CrearVacante();
            crear.Show();
            PrincipalAdm.getInstance().Hide();
        }
    }
}
