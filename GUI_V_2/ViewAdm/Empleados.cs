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
        CD_Empleados empleados = new CD_Empleados();

        public Empleados()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            BtnBorrar.Location = new Point(BtnBorrar.Location.X + 100, BtnBorrar.Location.Y);



        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            getData();
        }


        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getData();
        }

        public void getData()
        {
           
           dataGridView1.DataSource=  empleados.Mostrar();
        }
    }
}
