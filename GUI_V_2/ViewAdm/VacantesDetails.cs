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
    public partial class VacantesDetails : Form
    {
        CD_Commands commands = new CD_Commands();
        public string VacanteID {get;set;}
        public VacantesDetails(string vacanteID)
        {
            this.VacanteID = vacanteID;
            InitializeComponent();
        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void VacantesDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            LblTitulo.Text = LblTitulo.Text + commands.getSpecificData("Select Nombre from Puesto where Puesto_ID =" + VacanteID);
            dataGridView1.DataSource = commands.getData("Select Nombres, Apellidos, Fecha_Nacimiento as 'Fecha de nacimiento', Genero, Recomendado_Por as 'Recomendado por' from Candidato inner join PuestoAspirado ON Candidato.Candidato_ID = PuestoAspirado.Candidato_ID inner join Persona on Candidato.Persona_ID = Persona.Persona_ID where Puesto_ID ="+ VacanteID +"AND PuestoAspirado.Estado = 1;");
        }

        private void VacantesDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            PrincipalAdm.getInstance().Show();
            PrincipalAdm.getInstance().button2_Click(null, null);
        }
    }
}
