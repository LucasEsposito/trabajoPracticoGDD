﻿namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textAfiliado = new System.Windows.Forms.TextBox();
            this.labelAfiliado = new System.Windows.Forms.Label();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.contadorBonos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrecioFinal = new System.Windows.Forms.TextBox();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonSeleccionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textPlan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPrecioBono = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.contadorBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compra de Bonos";
            // 
            // textAfiliado
            // 
            this.textAfiliado.Location = new System.Drawing.Point(27, 70);
            this.textAfiliado.Name = "textAfiliado";
            this.textAfiliado.Size = new System.Drawing.Size(123, 20);
            this.textAfiliado.TabIndex = 1;
            this.textAfiliado.TextChanged += new System.EventHandler(this.textAfiliado_TextChanged);
            // 
            // labelAfiliado
            // 
            this.labelAfiliado.AutoSize = true;
            this.labelAfiliado.Location = new System.Drawing.Point(27, 51);
            this.labelAfiliado.Name = "labelAfiliado";
            this.labelAfiliado.Size = new System.Drawing.Size(41, 13);
            this.labelAfiliado.TabIndex = 2;
            this.labelAfiliado.Text = "Afiliado";
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Location = new System.Drawing.Point(27, 110);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(99, 13);
            this.labelCantidad.TabIndex = 3;
            this.labelCantidad.Text = "Cantidad a comprar";
            this.labelCantidad.Click += new System.EventHandler(this.labelCantidad_Click);
            // 
            // contadorBonos
            // 
            this.contadorBonos.Location = new System.Drawing.Point(30, 135);
            this.contadorBonos.Name = "contadorBonos";
            this.contadorBonos.Size = new System.Drawing.Size(120, 20);
            this.contadorBonos.TabIndex = 5;
            this.contadorBonos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Precio Final";
            // 
            // textPrecioFinal
            // 
            this.textPrecioFinal.Location = new System.Drawing.Point(271, 135);
            this.textPrecioFinal.Name = "textPrecioFinal";
            this.textPrecioFinal.ReadOnly = true;
            this.textPrecioFinal.Size = new System.Drawing.Size(85, 20);
            this.textPrecioFinal.TabIndex = 7;
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(383, 132);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botonConfirmar.TabIndex = 8;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(460, 168);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 9;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // botonSeleccionar
            // 
            this.botonSeleccionar.Location = new System.Drawing.Point(167, 68);
            this.botonSeleccionar.Name = "botonSeleccionar";
            this.botonSeleccionar.Size = new System.Drawing.Size(71, 23);
            this.botonSeleccionar.TabIndex = 10;
            this.botonSeleccionar.Text = "Seleccionar";
            this.botonSeleccionar.UseVisualStyleBackColor = true;
            this.botonSeleccionar.Click += new System.EventHandler(this.botonSeleccionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Plan";
            // 
            // textPlan
            // 
            this.textPlan.Location = new System.Drawing.Point(271, 69);
            this.textPlan.Name = "textPlan";
            this.textPlan.ReadOnly = true;
            this.textPlan.Size = new System.Drawing.Size(85, 20);
            this.textPlan.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Precio Bono";
            // 
            // textPrecioBono
            // 
            this.textPrecioBono.Location = new System.Drawing.Point(386, 70);
            this.textPrecioBono.Name = "textPrecioBono";
            this.textPrecioBono.ReadOnly = true;
            this.textPrecioBono.Size = new System.Drawing.Size(72, 20);
            this.textPrecioBono.TabIndex = 14;
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 203);
            this.Controls.Add(this.textPrecioBono);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPlan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.botonSeleccionar);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.textPrecioFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contadorBonos);
            this.Controls.Add(this.labelCantidad);
            this.Controls.Add(this.labelAfiliado);
            this.Controls.Add(this.textAfiliado);
            this.Controls.Add(this.label1);
            this.Name = "CompraBono";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CompraBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contadorBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAfiliado;
        private System.Windows.Forms.Label labelAfiliado;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.NumericUpDown contadorBonos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrecioFinal;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonSeleccionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPlan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPrecioBono;
    }
}