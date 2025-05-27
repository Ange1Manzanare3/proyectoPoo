namespace Proyecto_finalPOO
{
    partial class PGestionarUsuario
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
            listBox1 = new ListBox();
            txt_Nombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_correo = new TextBox();
            label3 = new Label();
            txt_contraseña = new TextBox();
            btn_editar = new Button();
            btn_borrar = new Button();
            label4 = new Label();
            txt_credito = new TextBox();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(165, 454);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new Point(182, 177);
            txt_Nombre.MaxLength = 20;
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(169, 23);
            txt_Nombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 159);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 159);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Correo";
            // 
            // txt_correo
            // 
            txt_correo.Location = new Point(401, 177);
            txt_correo.MaxLength = 25;
            txt_correo.Name = "txt_correo";
            txt_correo.Size = new Size(190, 23);
            txt_correo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(661, 159);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Contraseña";
            // 
            // txt_contraseña
            // 
            txt_contraseña.Location = new Point(639, 177);
            txt_contraseña.MaxLength = 15;
            txt_contraseña.Name = "txt_contraseña";
            txt_contraseña.Size = new Size(136, 23);
            txt_contraseña.TabIndex = 5;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(315, 343);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(75, 23);
            btn_editar.TabIndex = 7;
            btn_editar.Text = "Editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // btn_borrar
            // 
            btn_borrar.Location = new Point(195, 38);
            btn_borrar.Name = "btn_borrar";
            btn_borrar.Size = new Size(75, 23);
            btn_borrar.TabIndex = 8;
            btn_borrar.Text = "Borrar Usuario";
            btn_borrar.UseVisualStyleBackColor = true;
            btn_borrar.Click += btn_borrar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(836, 159);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 10;
            label4.Text = "Credito";
            // 
            // txt_credito
            // 
            txt_credito.Location = new Point(814, 177);
            txt_credito.MaxLength = 15;
            txt_credito.Name = "txt_credito";
            txt_credito.Size = new Size(136, 23);
            txt_credito.TabIndex = 9;
            // 
            // PGestionarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 480);
            Controls.Add(label4);
            Controls.Add(txt_credito);
            Controls.Add(btn_borrar);
            Controls.Add(btn_editar);
            Controls.Add(label3);
            Controls.Add(txt_contraseña);
            Controls.Add(label2);
            Controls.Add(txt_correo);
            Controls.Add(label1);
            Controls.Add(txt_Nombre);
            Controls.Add(listBox1);
            Name = "PGestionarUsuario";
            Text = "PGestionarUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox txt_Nombre;
        private Label label1;
        private Label label2;
        private TextBox txt_correo;
        private Label label3;
        private TextBox txt_contraseña;
        private Button btn_editar;
        private Button btn_borrar;
        private Label label4;
        private TextBox txt_credito;
    }
}