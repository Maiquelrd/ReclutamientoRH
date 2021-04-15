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

namespace GUI_V_2.ViewCandidates
{
    public partial class competencias : Form
    {
        CD_Commands _competencias = new CD_Commands();
        string candidatoID = CurrentUser.GetInstance().candidatoID;
        public competencias()
        {
            InitializeComponent();
        }

        private void competencias_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData()
        {

            dataGridView1.DataSource = _competencias.getData("SELECT Competencia_ID, Descripcion FROM Competencia inner join Candidato on Competencia.Candidato_ID = Candidato.Candidato_ID where Estado = 1 and Candidato.Candidato_ID="+ candidatoID);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearVacante crear = new CrearVacante();
            crear.Show();
            PrincipalAdm.getInstance().Hide();
        }

        private void BtnCrear_Click_1(object sender, EventArgs e)
        {
            CrearCompetencia crearCompetencia = new CrearCompetencia();
            crearCompetencia.Show();
            this.Hide();
        }

        private void BtnBorrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _competencias.executeCommand("Update Competencia set Estado = 0 WHERE Competencia_ID=" + dataGridView1.CurrentRow.Cells[0].Value);
                LoadData();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            bool correcto = true;
            try
            {
                _competencias.executeCommand("Update Competencia set Descripcion='" + row.Cells[1].Value.ToString() + "' where Competencia_ID= " + row.Cells[0].Value + "");

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

    }
}
