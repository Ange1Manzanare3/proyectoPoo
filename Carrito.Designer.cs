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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 36);
            label1.Name = "label1";
            label1.Size = new Size(364, 50);
            label1.TabIndex = 0;
            label1.Text = "Carrito De Compras";
            // 
            // btnQuitar
            // 
            btnQuitar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuitar.Location = new Point(68, 291);
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
            btnComprar.Location = new Point(468, 291);
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
            // Carrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 450);
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
    }
}