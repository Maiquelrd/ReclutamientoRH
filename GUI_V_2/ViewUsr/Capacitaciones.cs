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

    public partial class Capacitaciones : Form
    {
        CD_Commands CapacitacionesConexion = new CD_Commands();
        string candidatoID = CurrentUser.GetInstance().candidatoID;
     

        public Capacitaciones()
        {
            InitializeComponent();
        }

        private void Capacitaciones_Load(object sender, EventArgs e)
        {
           
            LoadData();
        }


        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadData()
        {
           
           dataGridView1.DataSource = CapacitacionesConexion.getData("SELECT Capacitacion.Capacitacion_ID, Descripcion, Nivel_Academico, Fecha_Desde, Fecha_Hasta, Institucion FROM Capacitacion inner join Candidato ON Capacitacion.Candidato_ID = Candidato.Candidato_ID where Capacitacion.Candidato_ID = " + candidatoID + ";");
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
                CapacitacionesConexion.executeCommand("Update Capacitacion set Descripcion='" + row.Cells[1].Value.ToString() +
                   "', Nivel_Academico='" + row.Cells[2].Value.ToString() +
                   "', Fecha_Desde='" + Datefix.FixDate(row.Cells[3].Value.ToString()) +
                   "', Fecha_Hasta='" + Datefix.FixDate(row.Cells[4].Value.ToString()) +
                   "', Institucion='" + row.Cells[5].Value.ToString() +
                   "' from Capacitacion where Capacitacion_ID = '" + row.Cells[0].Value.ToString() + "'"); 

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
            CapacitacionesConexion.executeCommand("Delete from Capacitacion where Capacitacion_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearCapacitaciones crear = new CrearCapacitaciones();
            crear.Show();
            PrincipalUsr.getInstance().Hide();
        }

        private void Capacitaciones_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
