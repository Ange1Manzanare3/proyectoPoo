namespace Proyecto_finalPOO
{
    partial class Reseñas
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
            label1 = new Label();
            label2 = new Label();
            txtReseña = new TextBox();
            btnPublicar = new Button();
            lstReseñas = new ListBox();
            label3 = new Label();
            button1 = new Button();
            numCalificacion = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numCalificacion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(159, 50);
            label1.TabIndex = 1;
            label1.Text = "Reseñas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 73);
            label2.Name = "label2";
            label2.Size = new Size(178, 28);
            label2.TabIndex = 2;
            label2.Text = "Escribe tu reseña:";
            // 
            // txtReseña
            // 
            txtReseña.Location = new Point(30, 109);
            txtReseña.Multiline = true;
            txtReseña.Name = "txtReseña";
            txtReseña.Size = new Size(778, 98);
            txtReseña.TabIndex = 3;
            // 
            // btnPublicar
            // 
            btnPublicar.Location = new Point(323, 213);
            btnPublicar.Name = "btnPublicar";
            btnPublicar.Size = new Size(203, 29);
            btnPublicar.TabIndex = 4;
            btnPublicar.Text = "Publicar Reseña";
            btnPublicar.UseVisualStyleBackColor = true;
            btnPublicar.Click += btnPublicar_Click;
            // 
            // lstReseñas
            // 
            lstReseñas.FormattingEnabled = true;
            lstReseñas.Location = new Point(38, 336);
            lstReseñas.Name = "lstReseñas";
            lstReseñas.Size = new Size(917, 244);
            lstReseñas.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 289);
            label3.Name = "label3";
            label3.Size = new Size(198, 28);
            label3.TabIndex = 6;
            label3.Text = "Reseñas Anteriores:";
            // 
            // button1
            // 
            button1.Location = new Point(974, 407);
            button1.Name = "button1";
            button1.Size = new Size(49, 116);
            button1.TabIndex = 7;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numCalificacion
            // 
            numCalificacion.Location = new Point(823, 119);
            numCalificacion.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numCalificacion.Name = "numCalificacion";
            numCalificacion.Size = new Size(150, 27);
            numCalificacion.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(823, 73);
            label4.Name = "label4";
            label4.Size = new Size(122, 28);
            label4.TabIndex = 9;
            label4.Text = "Calificación";
            // 
            // Reseñas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 598);
            Controls.Add(label4);
            Controls.Add(numCalificacion);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(lstReseñas);
            Controls.Add(btnPublicar);
            Controls.Add(txtReseña);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Reseñas";
            Text = "Reseñas";
            ((System.ComponentModel.ISupportInitialize)numCalificacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtReseña;
        private Button btnPublicar;
        private ListBox lstReseñas;
        private Label label3;
        private Button button1;
        private NumericUpDown numCalificacion;
        private Label label4;
    }
}