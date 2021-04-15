using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;
using GUI_V_2.Helpers;
using GUI_V_2.ViewAdm;

namespace GUI_V_2
{

    public partial class Idiomas : Form
    {
        CD_Commands IdiomasConexion = new CD_Commands();

        public Idiomas()
        {
            InitializeComponent();
        }

        private void Idiomas_Load(object sender, EventArgs e)
        {
           
            LoadData();
        }


        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadData()
        {
           
           dataGridView1.DataSource = IdiomasConexion.getData("SELECT Idioma.Idioma_ID, Nombre FROM Idioma inner join Candidato ON Idioma.Candidato_ID = Candidato.Candidato_ID where Estado = 1;");
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
                IdiomasConexion.executeCommand("Update Idioma set Nombre='" + row.Cells[1].Value.ToString() + "'"); 

            }
            catch (Exception)
            {
                correcto = false;
            }

            if(correcto)
                MessageBox.Show("Los datos fueron modificados correctamente", "Datos cambiados");
            else
                MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
            LoadData();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            IdiomasConexion.executeCommand("Delete from Idioma where Candidato_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearIdiomas crear = new CrearIdiomas();
            crear.Show();
            PrincipalUsr.getInstance().Hide();
        }

        private void Idiomas_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
