﻿using GUI_V_2.Helpers;
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
    public partial class CrearEmpleado : Form
    {
        CD_Commands commands = new CD_Commands();
        public CrearEmpleado()
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
            if(textBox5.Text == textBox10.Text)
            {
                bool correcto = true;
                try
                {
                    commands.executeCommand("INSERT INTO Persona (Nombres,Apellidos,Cedula,Fecha_Nacimiento,Genero) VALUES ('" + textBox1.Text.ToString() + "', '" +
                        textBox2.Text.ToString() + "', '" +
                        textBox3.Text.ToString() + "', '" +
                        textBox4.Text.ToString() + "', '" +
                        comboBox1.Text.ToString() + "')");

                }
                catch (Exception)
                {
                    correcto = false;
                }
                if (correcto)
                {
                    try
                    {
                        string id = commands.getSpecificData("SELECT MAX(Persona_ID) as maxid FROM Persona");
                        commands.executeCommand("INSERT INTO empleado (Persona_ID,Fecha_Ingreso,Departamento,Puesto,Salario,Estado) VALUES ('" + id + "', '" +
                        Datefix.FixDate(DateTime.Now.ToString()) + "', '" +
                        textBox6.Text.ToString() + "', '" +
                        textBox7.Text.ToString() + "', '" +
                        textBox8.Text.ToString() + "', '" +
                        "1')");
                    }
                    catch (Exception)
                    {
                        correcto = false;
                    }
                    if (correcto)
                    {
                        try
                        {
                            string id = commands.getSpecificData("SELECT MAX(Persona_ID) as maxid FROM Persona");
                            commands.executeCommand("INSERT INTO Usuario (Persona_ID,Rol_ID, Username, Password) VALUES ('" + id + "',1, '" +
                            textBox9.Text.ToString() + "', '" +
                            textBox5.Text.ToString() + "')");
                        }
                        catch (Exception)
                        {
                            correcto = false;
                        }
                    }
                }
                if (correcto)
                {
                    MessageBox.Show("Los datos fueron agregados correctamente", "Datos agregados");
                    CerrarForm();
                }
               
                else
                    MessageBox.Show("Hubo un error a la hora de agregar los datos", "Error");

            }
            else
                MessageBox.Show("Las contraseñas no coinciden", "Error");
        }

        private void CerrarForm()
        {
            PrincipalAdm.getInstance().Show();
            PrincipalAdm.getInstance().button1_Click(null, null);
            this.Close();
        }
    }
}
