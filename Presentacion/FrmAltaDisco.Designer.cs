namespace Presentacion
{
    partial class FrmAltaDisco
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.lblCantidadCanciones = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTituloAltaDisco = new System.Windows.Forms.Label();
            this.txtCantidadCanciones = new System.Windows.Forms.TextBox();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.lblTipoEdicion = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.cboTipoDeEdicion = new System.Windows.Forms.ComboBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.pcbImagenDiscoAlta = new System.Windows.Forms.PictureBox();
            this.lblAgregarGenero = new System.Windows.Forms.Label();
            this.txtNuevoGenero = new System.Windows.Forms.TextBox();
            this.btnNuevoGenero = new System.Windows.Forms.Button();
            this.lblEliminarGenero = new System.Windows.Forms.Label();
            this.btnEliminarGenero = new System.Windows.Forms.Button();
            this.lblNuevaEdicion = new System.Windows.Forms.Label();
            this.txtNuevaEdicion = new System.Windows.Forms.TextBox();
            this.btnAgergarEdicion = new System.Windows.Forms.Button();
            this.lblEliminarTipoEdicion = new System.Windows.Forms.Label();
            this.btnEliminarTipoEdicion = new System.Windows.Forms.Button();
            this.btnEliminarLogicoGener = new System.Windows.Forms.Label();
            this.btnEliminarLogicoGenero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenDiscoAlta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(21, 77);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(21, 121);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(114, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha de lanzamiento:";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(21, 158);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(119, 13);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de canciones:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(151, 70);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(200, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(26, 490);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(178, 490);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTituloAltaDisco
            // 
            this.lblTituloAltaDisco.AutoSize = true;
            this.lblTituloAltaDisco.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAltaDisco.Location = new System.Drawing.Point(31, 19);
            this.lblTituloAltaDisco.Name = "lblTituloAltaDisco";
            this.lblTituloAltaDisco.Size = new System.Drawing.Size(222, 24);
            this.lblTituloAltaDisco.TabIndex = 9;
            this.lblTituloAltaDisco.Text = "Agregar nuevo disco";
            // 
            // txtCantidadCanciones
            // 
            this.txtCantidadCanciones.Location = new System.Drawing.Point(151, 151);
            this.txtCantidadCanciones.Name = "txtCantidadCanciones";
            this.txtCantidadCanciones.Size = new System.Drawing.Size(200, 20);
            this.txtCantidadCanciones.TabIndex = 2;
            this.txtCantidadCanciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadCanciones_KeyPress_1);
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(151, 114);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 1;
            // 
            // lblTipoEdicion
            // 
            this.lblTipoEdicion.AutoSize = true;
            this.lblTipoEdicion.Location = new System.Drawing.Point(21, 357);
            this.lblTipoEdicion.Name = "lblTipoEdicion";
            this.lblTipoEdicion.Size = new System.Drawing.Size(80, 13);
            this.lblTipoEdicion.TabIndex = 12;
            this.lblTipoEdicion.Text = "Tipo de edición";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(23, 260);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 13;
            this.lblGenero.Text = "Genero";
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(151, 252);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(121, 21);
            this.cboGenero.TabIndex = 4;
            // 
            // cboTipoDeEdicion
            // 
            this.cboTipoDeEdicion.FormattingEnabled = true;
            this.cboTipoDeEdicion.Location = new System.Drawing.Point(151, 357);
            this.cboTipoDeEdicion.Name = "cboTipoDeEdicion";
            this.cboTipoDeEdicion.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDeEdicion.TabIndex = 6;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(21, 208);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(57, 13);
            this.lblUrlImagen.TabIndex = 16;
            this.lblUrlImagen.Text = "Url imagen";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(151, 201);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(200, 20);
            this.txtUrlImagen.TabIndex = 3;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // pcbImagenDiscoAlta
            // 
            this.pcbImagenDiscoAlta.Location = new System.Drawing.Point(544, 158);
            this.pcbImagenDiscoAlta.Name = "pcbImagenDiscoAlta";
            this.pcbImagenDiscoAlta.Size = new System.Drawing.Size(216, 232);
            this.pcbImagenDiscoAlta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenDiscoAlta.TabIndex = 18;
            this.pcbImagenDiscoAlta.TabStop = false;
            // 
            // lblAgregarGenero
            // 
            this.lblAgregarGenero.AutoSize = true;
            this.lblAgregarGenero.Location = new System.Drawing.Point(19, 295);
            this.lblAgregarGenero.Name = "lblAgregarGenero";
            this.lblAgregarGenero.Size = new System.Drawing.Size(116, 13);
            this.lblAgregarGenero.TabIndex = 19;
            this.lblAgregarGenero.Text = "Agregar nuevo género:";
            // 
            // txtNuevoGenero
            // 
            this.txtNuevoGenero.Location = new System.Drawing.Point(151, 288);
            this.txtNuevoGenero.Name = "txtNuevoGenero";
            this.txtNuevoGenero.Size = new System.Drawing.Size(124, 20);
            this.txtNuevoGenero.TabIndex = 5;
            // 
            // btnNuevoGenero
            // 
            this.btnNuevoGenero.Location = new System.Drawing.Point(281, 283);
            this.btnNuevoGenero.Name = "btnNuevoGenero";
            this.btnNuevoGenero.Size = new System.Drawing.Size(24, 28);
            this.btnNuevoGenero.TabIndex = 21;
            this.btnNuevoGenero.Text = "+";
            this.btnNuevoGenero.UseVisualStyleBackColor = true;
            this.btnNuevoGenero.Click += new System.EventHandler(this.btnNuevoGenero_Click);
            // 
            // lblEliminarGenero
            // 
            this.lblEliminarGenero.AutoSize = true;
            this.lblEliminarGenero.Location = new System.Drawing.Point(326, 260);
            this.lblEliminarGenero.Name = "lblEliminarGenero";
            this.lblEliminarGenero.Size = new System.Drawing.Size(120, 13);
            this.lblEliminarGenero.TabIndex = 22;
            this.lblEliminarGenero.Text = "Eliminar (Físico) genero ";
            // 
            // btnEliminarGenero
            // 
            this.btnEliminarGenero.Location = new System.Drawing.Point(443, 252);
            this.btnEliminarGenero.Name = "btnEliminarGenero";
            this.btnEliminarGenero.Size = new System.Drawing.Size(19, 21);
            this.btnEliminarGenero.TabIndex = 23;
            this.btnEliminarGenero.Text = "-";
            this.btnEliminarGenero.UseVisualStyleBackColor = true;
            this.btnEliminarGenero.Click += new System.EventHandler(this.btnEliminarGenero_Click);
            // 
            // lblNuevaEdicion
            // 
            this.lblNuevaEdicion.AutoSize = true;
            this.lblNuevaEdicion.Location = new System.Drawing.Point(19, 397);
            this.lblNuevaEdicion.Name = "lblNuevaEdicion";
            this.lblNuevaEdicion.Size = new System.Drawing.Size(146, 13);
            this.lblNuevaEdicion.TabIndex = 24;
            this.lblNuevaEdicion.Text = "Agregar nuevo tipo de edicin:";
            // 
            // txtNuevaEdicion
            // 
            this.txtNuevaEdicion.Location = new System.Drawing.Point(171, 394);
            this.txtNuevaEdicion.Name = "txtNuevaEdicion";
            this.txtNuevaEdicion.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaEdicion.TabIndex = 7;
            // 
            // btnAgergarEdicion
            // 
            this.btnAgergarEdicion.Location = new System.Drawing.Point(280, 389);
            this.btnAgergarEdicion.Name = "btnAgergarEdicion";
            this.btnAgergarEdicion.Size = new System.Drawing.Size(25, 29);
            this.btnAgergarEdicion.TabIndex = 26;
            this.btnAgergarEdicion.Text = "+";
            this.btnAgergarEdicion.UseVisualStyleBackColor = true;
            this.btnAgergarEdicion.Click += new System.EventHandler(this.btnAgergarEdicion_Click);
            // 
            // lblEliminarTipoEdicion
            // 
            this.lblEliminarTipoEdicion.AutoSize = true;
            this.lblEliminarTipoEdicion.Location = new System.Drawing.Point(326, 365);
            this.lblEliminarTipoEdicion.Name = "lblEliminarTipoEdicion";
            this.lblEliminarTipoEdicion.Size = new System.Drawing.Size(156, 13);
            this.lblEliminarTipoEdicion.TabIndex = 27;
            this.lblEliminarTipoEdicion.Text = "Eliminar (Físico) tipo de edicion:";
            // 
            // btnEliminarTipoEdicion
            // 
            this.btnEliminarTipoEdicion.Location = new System.Drawing.Point(488, 361);
            this.btnEliminarTipoEdicion.Name = "btnEliminarTipoEdicion";
            this.btnEliminarTipoEdicion.Size = new System.Drawing.Size(23, 21);
            this.btnEliminarTipoEdicion.TabIndex = 28;
            this.btnEliminarTipoEdicion.Text = "-";
            this.btnEliminarTipoEdicion.UseVisualStyleBackColor = true;
            this.btnEliminarTipoEdicion.Click += new System.EventHandler(this.btnEliminarTipoEdicion_Click);
            // 
            // btnEliminarLogicoGener
            // 
            this.btnEliminarLogicoGener.AutoSize = true;
            this.btnEliminarLogicoGener.Location = new System.Drawing.Point(326, 298);
            this.btnEliminarLogicoGener.Name = "btnEliminarLogicoGener";
            this.btnEliminarLogicoGener.Size = new System.Drawing.Size(123, 13);
            this.btnEliminarLogicoGener.TabIndex = 29;
            this.btnEliminarLogicoGener.Text = "Eliminar (Lógico) genero ";
            // 
            // btnEliminarLogicoGenero
            // 
            this.btnEliminarLogicoGenero.Location = new System.Drawing.Point(455, 294);
            this.btnEliminarLogicoGenero.Name = "btnEliminarLogicoGenero";
            this.btnEliminarLogicoGenero.Size = new System.Drawing.Size(19, 21);
            this.btnEliminarLogicoGenero.TabIndex = 30;
            this.btnEliminarLogicoGenero.Text = "-";
            this.btnEliminarLogicoGenero.UseVisualStyleBackColor = true;
            this.btnEliminarLogicoGenero.Click += new System.EventHandler(this.btnEliminarLogicoGenero_Click);
            // 
            // FrmAltaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 587);
            this.Controls.Add(this.btnEliminarLogicoGenero);
            this.Controls.Add(this.btnEliminarLogicoGener);
            this.Controls.Add(this.btnEliminarTipoEdicion);
            this.Controls.Add(this.lblEliminarTipoEdicion);
            this.Controls.Add(this.btnAgergarEdicion);
            this.Controls.Add(this.txtNuevaEdicion);
            this.Controls.Add(this.lblNuevaEdicion);
            this.Controls.Add(this.btnEliminarGenero);
            this.Controls.Add(this.lblEliminarGenero);
            this.Controls.Add(this.btnNuevoGenero);
            this.Controls.Add(this.txtNuevoGenero);
            this.Controls.Add(this.lblAgregarGenero);
            this.Controls.Add(this.pcbImagenDiscoAlta);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.cboTipoDeEdicion);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblTipoEdicion);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.txtCantidadCanciones);
            this.Controls.Add(this.lblTituloAltaDisco);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblCantidadCanciones);
            this.Controls.Add(this.lblFechaLanzamiento);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmAltaDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo disco";
            this.Load += new System.EventHandler(this.FrmAltaDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenDiscoAlta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.Label lblCantidadCanciones;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTituloAltaDisco;
        private System.Windows.Forms.TextBox txtCantidadCanciones;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.Label lblTipoEdicion;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.ComboBox cboTipoDeEdicion;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.PictureBox pcbImagenDiscoAlta;
        private System.Windows.Forms.Label lblAgregarGenero;
        private System.Windows.Forms.TextBox txtNuevoGenero;
        private System.Windows.Forms.Button btnNuevoGenero;
        private System.Windows.Forms.Label lblEliminarGenero;
        private System.Windows.Forms.Button btnEliminarGenero;
        private System.Windows.Forms.Label lblNuevaEdicion;
        private System.Windows.Forms.TextBox txtNuevaEdicion;
        private System.Windows.Forms.Button btnAgergarEdicion;
        private System.Windows.Forms.Label lblEliminarTipoEdicion;
        private System.Windows.Forms.Button btnEliminarTipoEdicion;
        private System.Windows.Forms.Label btnEliminarLogicoGener;
        private System.Windows.Forms.Button btnEliminarLogicoGenero;
    }
}