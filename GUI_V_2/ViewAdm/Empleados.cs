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

    public partial class Empleados : Form
    {
        CD_Commands empleados = new CD_Commands();

        public Empleados()
        {
            InitializeComponent();
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
           
           dataGridView1.DataSource =  empleados.getData("SELECT Empleado_ID as ID, Usuario.Username as Usuario, Nombres, Apellidos, Fecha_Ingreso As 'Fecha de ingreso', Departamento, Puesto, Salario, Cedula, Fecha_Nacimiento as 'Fecha de nacimiento', Genero FROM Empleado inner join persona ON Empleado.Persona_ID = Persona.Persona_ID inner join usuario on persona.Persona_ID = usuario.Persona_ID where empleado.Estado = 1;");
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
                empleados.executeCommand("Update persona set Nombres='" + row.Cells[2].Value.ToString() +
                   "', Apellidos='" + row.Cells[3].Value.ToString() +
                   "', Cedula='" + row.Cells[8].Value.ToString() +
                   "', Fecha_Nacimiento='" + Datefix.FixDate(row.Cells[9].Value.ToString()) +
                   "', Genero='" + row.Cells[10].Value.ToString() +
                   "' from Persona as p inner join Empleado as e ON e.Persona_ID = p.Persona_ID  where e.empleado_ID = '" + row.Cells[0].Value.ToString() + "'"); 

            }
            catch (Exception )
            {
                correcto = false;
            }
            if (correcto)
            {
                try
                {
                    empleados.executeCommand("Update empleado set Fecha_Ingreso='" + Datefix.FixDate(row.Cells[4].Value.ToString()) +
                       "', Departamento='" + row.Cells[5].Value.ToString() +
                       "', Puesto='" + row.Cells[6].Value.ToString() +
                       "', Salario='" + row.Cells[7].Value.ToString() +
                       "' from Empleado as e inner join Persona as p ON e.Persona_ID = p.Persona_ID  where e.empleado_ID = '" + row.Cells[0].Value.ToString() + "'");
                }
                catch (Exception)
                {
                    correcto = false;
                }
            }

            if(correcto)
                MessageBox.Show("Los datos fueron modificados correctamente", "Datos cambiados");
            else
                MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
            LoadData();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            empleados.executeCommand("Update empleado set Estado='0' where empleado_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Hubo un error a la hora de modificar los datos", "Error");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearEmpleado crear = new CrearEmpleado();
            crear.Show();
            PrincipalAdm.getInstance().Hide();
        }
    }
}
