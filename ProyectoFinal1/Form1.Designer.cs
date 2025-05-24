namespace InvestigadorIA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.textBoxPreguntas = new System.Windows.Forms.TextBox();
            this.textBoxRespuesta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bttnBuscar.Location = new System.Drawing.Point(530, 97);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(182, 31);
            this.bttnBuscar.TabIndex = 0;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = false;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // textBoxPreguntas
            // 
            this.textBoxPreguntas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPreguntas.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPreguntas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxPreguntas.Location = new System.Drawing.Point(319, 50);
            this.textBoxPreguntas.Multiline = true;
            this.textBoxPreguntas.Name = "textBoxPreguntas";
            this.textBoxPreguntas.Size = new System.Drawing.Size(596, 41);
            this.textBoxPreguntas.TabIndex = 1;
            // 
            // textBoxRespuesta
            // 
            this.textBoxRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRespuesta.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRespuesta.Location = new System.Drawing.Point(319, 145);
            this.textBoxRespuesta.Multiline = true;
            this.textBoxRespuesta.Name = "textBoxRespuesta";
            this.textBoxRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRespuesta.Size = new System.Drawing.Size(596, 374);
            this.textBoxRespuesta.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(936, 531);
            this.Controls.Add(this.textBoxRespuesta);
            this.Controls.Add(this.textBoxPreguntas);
            this.Controls.Add(this.bttnBuscar);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.TextBox textBoxPreguntas;
        private System.Windows.Forms.TextBox textBoxRespuesta;
    }
}

