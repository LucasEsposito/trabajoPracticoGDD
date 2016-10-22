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
        Dictionary<int, Func<Form>> funcDisponibles;
        Form frmLogin;
        string userActivo;

        public MenuPrincipal(Form frmLogin, int rolActivo, string userActivo)
        {
            InitializeComponent();
            this.frmLogin=frmLogin;
            this.userActivo = userActivo;
            this.inicializarDiccFuncionalidades();
            this.getFuncionalidadesAsignadas(rolActivo);
        }

        private void getFuncionalidadesAsignadas(int rolActivo)
        {
            var parametrosSP = new List<KeyValuePair<string, object>>();
            parametrosSP.Add(new KeyValuePair<string, object>("@role_id", rolActivo));
            var funcionalidades = new List<KeyValuePair<int, string>>();

            using (SqlConnection conexion = DBConnection.getConnection())
            { 
                SqlCommand query = Utilidades.Utils.crearSp("CLINICA.FuncionalidadXRol", parametrosSP, conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()){
                    funcionalidades.Add(new KeyValuePair<int, string>(Int32.Parse(reader["func_id"].ToString()), reader["detalle"].ToString()));
                }
            }
            
            Utilidades.Utils.llenar(this.listFuncionalidades, funcionalidades);

            if (this.listFuncionalidades.Items.Count < 1)
            {
                this.botonSeleccionar.Enabled = false;
            }
        }

        private void inicializarDiccFuncionalidades()
        {
            this.funcDisponibles = new Dictionary<int, Func<Form>>();
            this.funcDisponibles.Add(1, () => new Abm_Afiliado.AbmAfiliado());
            this.funcDisponibles.Add(2, () => new Abm_Especialidades_Medicas.AbmEspMedicas());
            this.funcDisponibles.Add(3, () => new Abm_Planes.AbmPlanes());
            this.funcDisponibles.Add(4, () => new Abm_Profesional.AbmProfesional());
            this.funcDisponibles.Add(5, () => new AbmRol.AbmRol());
            this.funcDisponibles.Add(6, () => new Cancelar_Atencion.CancelarAtencion());
            this.funcDisponibles.Add(7, () => new Compra_Bono.CompraBono());
            this.funcDisponibles.Add(8, () => new Listados.Listados());
            this.funcDisponibles.Add(9, () => new Pedir_Turno.PedirTurno());
            this.funcDisponibles.Add(10, () => new Registrar_Agenta_Medico.RegistarAgenda());
            this.funcDisponibles.Add(11, () => new Registro_Llegada.RegistroLlegada());
            this.funcDisponibles.Add(11, () => new Registro_Resultado.RegistroResultado());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.frmLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int funcionalidadSeleccionada = ((KeyValuePair<int, string>) this.listFuncionalidades.SelectedItem).Key;
            if (!this.funcDisponibles.ContainsKey(funcionalidadSeleccionada)) //Control extra
                return;

            this.Hide();
            this.funcDisponibles[funcionalidadSeleccionada]().Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }
    }
}