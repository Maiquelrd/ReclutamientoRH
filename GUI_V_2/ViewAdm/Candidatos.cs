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
    public partial class Candidatos : Form
    {
        CD_Commands candidatos = new CD_Commands();

        public Candidatos()
        {
            InitializeComponent();
        }

        private void Candidatos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {

            dataGridView1.DataSource = candidatos.getData("SELECT Candidato_ID as ID, Usuario.Username as 'Usuario', Nombres, Apellidos, Recomendado_Por AS 'Recomendado por', Cedula, Fecha_Nacimiento as 'Fecha de nacimiento', Genero FROM Candidato inner join persona ON Candidato.Persona_ID = Persona.Persona_ID inner join Usuario on Persona.Persona_ID = Usuario.Persona_ID;  ");
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
                candidatos.executeCommand("Update persona set Nombres='" + row.Cells[1].Value.ToString() +
                   "', Apellidos='" + row.Cells[2].Value.ToString() +
                   "', Cedula='" + row.Cells[5].Value.ToString() +
                   "', Fecha_Nacimiento='" + Datefix.FixDate(row.Cells[6].Value.ToString()) +
                   "', Genero='" + row.Cells[7].Value.ToString() +
                   "' from Persona as p inner join Candidato as e ON e.Persona_ID = p.Persona_ID  where e.candidato_ID = '" + row.Cells[0].Value.ToString() + "'");

            }
            catch (Exception)
            {
                correcto = false;
            }
            if (correcto)
            {
                try
                {
                    candidatos.executeCommand("Update candidato set Recomendado_Por='" + row.Cells[3].Value.ToString() +
                       "', Curriculum='" + row.Cells[4].Value.ToString() +
                       "' from candidato as e inner join Persona as p ON e.Persona_ID = p.Persona_ID  where e.candidato = '" + row.Cells[0].Value.ToString() + "'");
                }
                catch (Exception)
                {
                    correcto = false;
                }
            }

            if (correcto)
                MessageBox.Show("Los datos fueron modificados correctamente", "Datos cambiados");
            else
                MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
            LoadData();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            candidatos.executeCommand("Update candidato set Estado='0' where candidato_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearCandidato crear = new CrearCandidato();
            crear.Show();
            PrincipalAdm.getInstance().Hide();
        }
    }
}
