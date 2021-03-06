﻿using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    public partial class ListadoAfiliados : Form
    {
        string consulta = "SELECT afil_id Afiliado, usua_apellido Apellido, usua_nombre Nombre, usua_nroDoc Documento FROM GEDDES.Usuarios, GEDDES.Afiliados WHERE afil_usuario = usua_id";
        public ListadoAfiliados()
        {
            InitializeComponent();
           // conexion = new Connection();
        }

        public static ListadoAfiliados ListadoBaja()
        {
            ListadoAfiliados listado = new ListadoAfiliados();
            listado.botonEliminar.Visible = true;
            listado.botonEliminar.Enabled = false;
            listado.botonModificar.Enabled = false;

            listado.AcceptButton = listado.botonEliminar;
       
            
            listado.botonModificar.Visible = false;
            listado.botonEliminar.Location = listado.botonModificar.Location;

            return listado;
        }
        
      #region METODOS QUE SE ACTIVAN CUANDO SE ACCIONA UN BOTON O CAMBIA UN VALOR
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            usua_nombre.Clear();
            usua_apellido.Clear();
            usua_nroDoc.Clear();

            botonModificar.Enabled = false;
            botonDesactivar.Enabled = false;

            checkBoxApellido.Checked = false;
            checkBoxNombre.Checked = false;
            checkBoxDoc.Checked = false;
            usua_intentos.Checked = false;

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void buscar()
        {
            Parametro[] parametros = new Parametro[4];
            string consulta;
            bool esExacta;

            botonModificar.Enabled = false;
            botonDesactivar.Enabled = false;
            if (camposVacios())
            {
                if (this.usua_intentos.Checked)
                {
                    consulta = "SELECT afil_id Afiliado, usua_apellido Apellido, usua_nombre Nombre, usua_nroDoc Documento FROM GEDDES.Usuarios, GEDDES.Afiliados WHERE afil_usuario = usua_id AND usua_intentos <> 0 ";

                }
                else
                {
                    consulta = this.consulta;
                }
            }
            else
            {
                esExacta = checkBoxNombre.Checked;

                parametros.SetValue(Parametro.fromTextBox(usua_nombre, esExacta), 0);

                esExacta = checkBoxApellido.Checked;

                parametros.SetValue(Parametro.fromTextBox(usua_apellido, esExacta), 1);

                esExacta = checkBoxDoc.Checked;

                parametros.SetValue(Parametro.fromTextBox(usua_nroDoc, esExacta), 2);

                if (this.usua_intentos.Checked)
                {
                    parametros.SetValue(Parametro.fromCheckBox(usua_intentos), 3);
                }

                consulta = Parser.armarConsulta("Afiliados", parametros);
                
            }

            DBConnection.cargarPlanilla(planillaResultados, consulta);  
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void planillaResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonModificar.Enabled = true;
            botonDesactivar.Enabled = true;
            botonEliminar.Enabled = true;
            this.AcceptButton = botonModificar;
        }



        private void planillaResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            botonModificar.Enabled = true;

        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            this.cargarAlAfiliado();
        }


        private void botonDesactivar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea desactivar a este afiliado?", "Desactivar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //lleno los datos del afiliado
                Afiliado afil = this.completarDatosDeAfiliado();

                Utilidades.Utils.bajaLogicaA(afil);

                this.buscar();
                //DBConnection.cargarPlanilla(planillaResultados, consulta);  
            }
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
         

            if (MessageBox.Show("Está seguro que desea eliminar este afiliado?", "Desactivar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
           

                //completo los datos del afiliado
                Afiliado afil = this.completarDatosDeAfiliado();

                //elimino al afiliado del sistema
                Utilidades.Utils.darDeBajaAfiliado(afil.getUsuaId());


               // baja.eliminarAfiliado(afil);
                MessageBox.Show("Usuario eliminado");
                this.buscar();
                
                //DBConnection.cargarPlanilla(planillaResultados, this.consulta);  
            }
        }

        #endregion


        #region METODOS AUXILIARES
        private void agregarALista(Parametro[] parametros, TextBox textbox)
        {
            int longitud = parametros.Length;
            if (textbox.Text.Length != 0)
            {
            }
        }

        private bool camposVacios()
        {
            return Parser.estaVacio(usua_nombre) && Parser.estaVacio(usua_nroDoc) && Parser.estaVacio(usua_apellido);
        }

        private void cargarAlAfiliado()
        {  
            Afiliado afil = this.completarDatosDeAfiliado() ;
            ModificacionUsuario modif = new ModificacionUsuario(afil);

            modif.Show();
        }

        private Afiliado completarDatosDeAfiliado()
        {
            string direccion, tipoDoc, telefono, mail, genero, estado;
            int plan_id, cantidadHijos;
            DateTime fechaNac;

            // obtengo los datos asociados al afiliado como usuario
            
            int afilId = Convert.ToInt32(planillaResultados.SelectedCells[0].Value);
            long cod_usuario = Convert.ToInt64(planillaResultados.SelectedCells[0].Value);

            string apellido = Convert.ToString(planillaResultados.SelectedCells[1].Value);
            string nombre = Convert.ToString(planillaResultados.SelectedCells[2].Value);
            string dni = Convert.ToString(planillaResultados.SelectedCells[3].Value);


            SqlDataReader reader = Utils.getDatosAdicionalesAfiliado(afilId);

            // obtengo datos de afiliado: plan, estado, hijos, y su numero de usuario
            reader.Read();
                plan_id = Convert.ToInt32(reader[0]);
                estado = Convert.ToString(reader[1]);
                cantidadHijos = Convert.ToInt32(reader[2]);
                cod_usuario = Convert.ToInt64(reader[3]);

            //obtengo los datos de direccion, tipo de documento, etc...
           reader = Utils.obtenerUsuarioDesdeUsername(cod_usuario);

           reader.Read();
                direccion = Convert.ToString(reader[0]);
                tipoDoc = Convert.ToString(reader[1]);
                telefono = Convert.ToString(reader[2]);
                fechaNac = Convert.ToDateTime(reader[3]);
                mail = Convert.ToString(reader[4]);
                genero = Convert.ToString(reader[5]);

            //obtengo el nombre del plan
           string plan = Utils.getNombrePlan(plan_id);

           Afiliado afiliado = new Afiliado(nombre, apellido, fechaNac, tipoDoc, dni, direccion, telefono, genero, estado, plan);

           afiliado.setCodigo(afilId);
           afiliado.setUsuaId(cod_usuario);            
            
            return afiliado;
        }
        #endregion       
    }
}
