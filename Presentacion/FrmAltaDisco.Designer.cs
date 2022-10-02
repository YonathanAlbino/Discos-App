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
            this.btnEliminarGenero = new System.Windows.Forms.Button();
            this.lblNuevaEdicion = new System.Windows.Forms.Label();
            this.txtNuevaEdicion = new System.Windows.Forms.TextBox();
            this.btnAgergarEdicion = new System.Windows.Forms.Button();
            this.btnEliminarTipoEdicion = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenDiscoAlta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(31, 80);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(31, 124);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(114, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha de lanzamiento:";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(31, 161);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(119, 13);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de canciones:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(161, 73);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(200, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(58, 464);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(175, 464);
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
            this.lblTituloAltaDisco.Location = new System.Drawing.Point(41, 22);
            this.lblTituloAltaDisco.Name = "lblTituloAltaDisco";
            this.lblTituloAltaDisco.Size = new System.Drawing.Size(222, 24);
            this.lblTituloAltaDisco.TabIndex = 9;
            this.lblTituloAltaDisco.Text = "Agregar nuevo disco";
            // 
            // txtCantidadCanciones
            // 
            this.txtCantidadCanciones.Location = new System.Drawing.Point(161, 154);
            this.txtCantidadCanciones.Name = "txtCantidadCanciones";
            this.txtCantidadCanciones.Size = new System.Drawing.Size(200, 20);
            this.txtCantidadCanciones.TabIndex = 2;
            this.txtCantidadCanciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadCanciones_KeyPress_1);
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(161, 117);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 1;
            // 
            // lblTipoEdicion
            // 
            this.lblTipoEdicion.AutoSize = true;
            this.lblTipoEdicion.Location = new System.Drawing.Point(31, 360);
            this.lblTipoEdicion.Name = "lblTipoEdicion";
            this.lblTipoEdicion.Size = new System.Drawing.Size(80, 13);
            this.lblTipoEdicion.TabIndex = 12;
            this.lblTipoEdicion.Text = "Tipo de edición";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(33, 263);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 13;
            this.lblGenero.Text = "Genero";
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(161, 255);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(121, 21);
            this.cboGenero.TabIndex = 4;
            // 
            // cboTipoDeEdicion
            // 
            this.cboTipoDeEdicion.FormattingEnabled = true;
            this.cboTipoDeEdicion.Location = new System.Drawing.Point(161, 360);
            this.cboTipoDeEdicion.Name = "cboTipoDeEdicion";
            this.cboTipoDeEdicion.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDeEdicion.TabIndex = 6;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(31, 211);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(57, 13);
            this.lblUrlImagen.TabIndex = 16;
            this.lblUrlImagen.Text = "Url imagen";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(161, 204);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(200, 20);
            this.txtUrlImagen.TabIndex = 3;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // pcbImagenDiscoAlta
            // 
            this.pcbImagenDiscoAlta.Location = new System.Drawing.Point(426, 73);
            this.pcbImagenDiscoAlta.Name = "pcbImagenDiscoAlta";
            this.pcbImagenDiscoAlta.Size = new System.Drawing.Size(216, 232);
            this.pcbImagenDiscoAlta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenDiscoAlta.TabIndex = 18;
            this.pcbImagenDiscoAlta.TabStop = false;
            // 
            // lblAgregarGenero
            // 
            this.lblAgregarGenero.AutoSize = true;
            this.lblAgregarGenero.Location = new System.Drawing.Point(29, 298);
            this.lblAgregarGenero.Name = "lblAgregarGenero";
            this.lblAgregarGenero.Size = new System.Drawing.Size(116, 13);
            this.lblAgregarGenero.TabIndex = 19;
            this.lblAgregarGenero.Text = "Agregar nuevo género:";
            // 
            // txtNuevoGenero
            // 
            this.txtNuevoGenero.Location = new System.Drawing.Point(161, 291);
            this.txtNuevoGenero.Name = "txtNuevoGenero";
            this.txtNuevoGenero.Size = new System.Drawing.Size(121, 20);
            this.txtNuevoGenero.TabIndex = 5;
            // 
            // btnNuevoGenero
            // 
            this.btnNuevoGenero.Location = new System.Drawing.Point(291, 286);
            this.btnNuevoGenero.Name = "btnNuevoGenero";
            this.btnNuevoGenero.Size = new System.Drawing.Size(24, 28);
            this.btnNuevoGenero.TabIndex = 21;
            this.btnNuevoGenero.Text = "+";
            this.btnNuevoGenero.UseVisualStyleBackColor = true;
            this.btnNuevoGenero.Click += new System.EventHandler(this.btnNuevoGenero_Click);
            // 
            // btnEliminarGenero
            // 
            this.btnEliminarGenero.Location = new System.Drawing.Point(321, 286);
            this.btnEliminarGenero.Name = "btnEliminarGenero";
            this.btnEliminarGenero.Size = new System.Drawing.Size(22, 29);
            this.btnEliminarGenero.TabIndex = 23;
            this.btnEliminarGenero.Text = "-";
            this.btnEliminarGenero.UseVisualStyleBackColor = true;
            this.btnEliminarGenero.Click += new System.EventHandler(this.btnEliminarGenero_Click);
            // 
            // lblNuevaEdicion
            // 
            this.lblNuevaEdicion.AutoSize = true;
            this.lblNuevaEdicion.Location = new System.Drawing.Point(4, 407);
            this.lblNuevaEdicion.Name = "lblNuevaEdicion";
            this.lblNuevaEdicion.Size = new System.Drawing.Size(146, 13);
            this.lblNuevaEdicion.TabIndex = 24;
            this.lblNuevaEdicion.Text = "Agregar nuevo tipo de edicin:";
            // 
            // txtNuevaEdicion
            // 
            this.txtNuevaEdicion.Location = new System.Drawing.Point(161, 400);
            this.txtNuevaEdicion.Name = "txtNuevaEdicion";
            this.txtNuevaEdicion.Size = new System.Drawing.Size(121, 20);
            this.txtNuevaEdicion.TabIndex = 7;
            // 
            // btnAgergarEdicion
            // 
            this.btnAgergarEdicion.Location = new System.Drawing.Point(290, 392);
            this.btnAgergarEdicion.Name = "btnAgergarEdicion";
            this.btnAgergarEdicion.Size = new System.Drawing.Size(25, 29);
            this.btnAgergarEdicion.TabIndex = 26;
            this.btnAgergarEdicion.Text = "+";
            this.btnAgergarEdicion.UseVisualStyleBackColor = true;
            this.btnAgergarEdicion.Click += new System.EventHandler(this.btnAgergarEdicion_Click);
            // 
            // btnEliminarTipoEdicion
            // 
            this.btnEliminarTipoEdicion.Location = new System.Drawing.Point(320, 392);
            this.btnEliminarTipoEdicion.Name = "btnEliminarTipoEdicion";
            this.btnEliminarTipoEdicion.Size = new System.Drawing.Size(23, 31);
            this.btnEliminarTipoEdicion.TabIndex = 28;
            this.btnEliminarTipoEdicion.Text = "-";
            this.btnEliminarTipoEdicion.UseVisualStyleBackColor = true;
            this.btnEliminarTipoEdicion.Click += new System.EventHandler(this.btnEliminarTipoEdicion_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(367, 204);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(19, 25);
            this.btnAgregarImagen.TabIndex = 29;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // FrmAltaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 524);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnEliminarTipoEdicion);
            this.Controls.Add(this.btnAgergarEdicion);
            this.Controls.Add(this.txtNuevaEdicion);
            this.Controls.Add(this.lblNuevaEdicion);
            this.Controls.Add(this.btnEliminarGenero);
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
        private System.Windows.Forms.Button btnEliminarGenero;
        private System.Windows.Forms.Label lblNuevaEdicion;
        private System.Windows.Forms.TextBox txtNuevaEdicion;
        private System.Windows.Forms.Button btnAgergarEdicion;
        private System.Windows.Forms.Button btnEliminarTipoEdicion;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}