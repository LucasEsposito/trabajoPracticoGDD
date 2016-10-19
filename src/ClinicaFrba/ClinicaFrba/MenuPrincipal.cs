﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    public partial class MenuPrincipal : Form
    {
        Dictionary<int, Func<Form>> frmsDisponibles;
        Form frmLogin;
        string userActivo;

        public MenuPrincipal(Form frmLogin, int rolActivo, string userActivo)
        {
            InitializeComponent();
            this.frmLogin=frmLogin;
            this.userActivo = userActivo;
            this.inicializarFrmsDisponibles();
            this.fill_list(rolActivo);
        }

        private void fill_list(int rolActivo)
        {
            var parametrosSP = new List<KeyValuePair<string, object>>();
            parametrosSP.Add(new KeyValuePair<string, object>("@role_id", rolActivo));
            var roles = new List<KeyValuePair<int, string>>();

            using (SqlConnection conexion = DBConnection.getConnection())
            { 
                SqlCommand query = Utils.create_sp("CLINICA.FuncionalidadXRol", parametrosSP, conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_fun"].ToString()), reader["descripcion"].ToString()));
            }
            Utils.populate(this.listBox1, roles);
            if (this.listBox1.Items.Count < 1)
            {
                this.button1.Enabled = false;
            }
        }

        private void inicializarFrmsDisponibles()
        {
            this.frmsDisponibles = new Dictionary<int, Func<Form>>();
            this.frmsDisponibles.Add(1, () => new Abm_Afiliado.AbmAfiliado(this, this.userActivo));
            this.frmsDisponibles.Add(2, () => new Abm_Especialidades_Medicas.AbmEspMedicas(this));
            this.frmsDisponibles.Add(3, () => new Abm_Planes.AbmPlanes(this));
            this.frmsDisponibles.Add(4, () => new Abm_Profesional.AbmProfesional(this));
            this.frmsDisponibles.Add(5, () => new Abm_Rol.Form1(this, this.username));
            this.frmsDisponibles.Add(6, () => new Cancelar_Atencion.CancelarAtencion(this, this.username));
            this.frmsDisponibles.Add(7, () => new Compra_Bono.CompraBono(this, this.username));
            this.frmsDisponibles.Add(8, () => new Listados.Listados(this, this.username));
            this.frmsDisponibles.Add(9, () => new Pedir_Turno.PedirTurno(this));
            this.frmsDisponibles.Add(10, () => new Registrar_Agenta_Medico.RegistarAgenda(this));
            this.frmsDisponibles.Add(11, () => new Registro_Llegada.RegistroLlegada(this, this.username));
            this.frmsDisponibles.Add(11, () => new Registro_Resultado.RegistroResultado(this, this.username));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.login_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_functionality_code = ((KeyValuePair<int, string>) this.listBox1.SelectedItem).Key;
            if (!this.frmsDisponibles.ContainsKey(selected_functionality_code))
                return;

            this.Hide();
            (this.frmsDisponibles[selected_functionality_code])().Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
}
