namespace Proyecto_finalPOO
{
    partial class Carrito
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
            btnQuitar = new Button();
            btnVaciar = new Button();
            btnComprar = new Button();
            listJuegos = new ListBox();
            lblCreditos = new Label();
            txtBalanza = new TextBox();
            btnBalanza = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(39, 28);
            label1.Name = "label1";
            label1.Size = new Size(364, 50);
            label1.TabIndex = 0;
            label1.Text = "Carrito De Compras";
            // 
            // btnQuitar
            // 
            btnQuitar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuitar.Location = new Point(69, 291);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(133, 56);
            btnQuitar.TabIndex = 1;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnVaciar
            // 
            btnVaciar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVaciar.Location = new Point(270, 291);
            btnVaciar.Name = "btnVaciar";
            btnVaciar.Size = new Size(133, 56);
            btnVaciar.TabIndex = 2;
            btnVaciar.Text = "Vaciar";
            btnVaciar.UseVisualStyleBackColor = true;
            btnVaciar.Click += btnVaciar_Click;
            // 
            // btnComprar
            // 
            btnComprar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnComprar.Location = new Point(469, 291);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(133, 56);
            btnComprar.TabIndex = 3;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // listJuegos
            // 
            listJuegos.FormattingEnabled = true;
            listJuegos.Location = new Point(48, 127);
            listJuegos.Name = "listJuegos";
            listJuegos.Size = new Size(581, 104);
            listJuegos.TabIndex = 4;
            // 
            // lblCreditos
            // 
            lblCreditos.AutoSize = true;
            lblCreditos.Location = new Point(558, 49);
            lblCreditos.Name = "lblCreditos";
            lblCreditos.Size = new Size(50, 20);
            lblCreditos.TabIndex = 5;
            lblCreditos.Text = "label2";
            // 
            // txtBalanza
            // 
            txtBalanza.Location = new Point(654, 49);
            txtBalanza.Margin = new Padding(3, 4, 3, 4);
            txtBalanza.Name = "txtBalanza";
            txtBalanza.Size = new Size(114, 27);
            txtBalanza.TabIndex = 6;
            // 
            // btnBalanza
            // 
            btnBalanza.Location = new Point(795, 49);
            btnBalanza.Margin = new Padding(3, 4, 3, 4);
            btnBalanza.Name = "btnBalanza";
            btnBalanza.Size = new Size(104, 57);
            btnBalanza.TabIndex = 7;
            btnBalanza.Text = "Actualizar balanza";
            btnBalanza.UseVisualStyleBackColor = true;
            btnBalanza.Click += btnBalanza_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(687, 12);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 8;
            label3.Text = "Balanza";
            // 
            // Carrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(913, 451);
            Controls.Add(label3);
            Controls.Add(btnBalanza);
            Controls.Add(txtBalanza);
            Controls.Add(lblCreditos);
            Controls.Add(listJuegos);
            Controls.Add(btnComprar);
            Controls.Add(btnVaciar);
            Controls.Add(btnQuitar);
            Controls.Add(label1);
            Name = "Carrito";
            Text = "Carrito";
            Load += Carrito_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnQuitar;
        private Button btnVaciar;
        private Button btnComprar;
        private ListBox listJuegos;
        private Label lblCreditos;
        private TextBox txtBalanza;
        private Button btnBalanza;
        private Label label3;
    }
}