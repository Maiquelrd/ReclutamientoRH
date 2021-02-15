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

namespace GUI_V_2
{

    public partial class Empleados : Form
    {
        CD_Commands empleados = new CD_Commands();

        public Empleados()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Empleados_Load(object sender, EventArgs e)
        {
           
            LoadData();
        }


        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadData()
        {
           
           dataGridView1.DataSource=  empleados.getData("SELECT Empleado_ID, Nombres, Apellidos, Fecha_Ingreso, Departamento, Puesto, Salario, Cedula, Fecha_Nacimiento, Genero FROM Empleado inner join persona ON Empleado.Persona_ID = Persona.Persona_ID where Estado = 1; ");
        }
    }
}
