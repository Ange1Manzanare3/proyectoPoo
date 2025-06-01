namespace BATTLESHIP_P.FINAL
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNATAQUE = new System.Windows.Forms.Button();
            this.CMBENEMYL = new System.Windows.Forms.ComboBox();
            this.LBLEMOVE = new System.Windows.Forms.Label();
            this.LBLROUNDS = new System.Windows.Forms.Label();
            this.LBLENEMY = new System.Windows.Forms.Label();
            this.LBLPLAYER = new System.Windows.Forms.Label();
            this.Z4 = new System.Windows.Forms.Button();
            this.Z3 = new System.Windows.Forms.Button();
            this.Z2 = new System.Windows.Forms.Button();
            this.Z1 = new System.Windows.Forms.Button();
            this.Y4 = new System.Windows.Forms.Button();
            this.Y3 = new System.Windows.Forms.Button();
            this.Y2 = new System.Windows.Forms.Button();
            this.Y1 = new System.Windows.Forms.Button();
            this.X4 = new System.Windows.Forms.Button();
            this.X3 = new System.Windows.Forms.Button();
            this.X2 = new System.Windows.Forms.Button();
            this.X1 = new System.Windows.Forms.Button();
            this.W4 = new System.Windows.Forms.Button();
            this.W3 = new System.Windows.Forms.Button();
            this.W1 = new System.Windows.Forms.Button();
            this.W2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.D4 = new System.Windows.Forms.Button();
            this.D3 = new System.Windows.Forms.Button();
            this.C4 = new System.Windows.Forms.Button();
            this.C3 = new System.Windows.Forms.Button();
            this.B4 = new System.Windows.Forms.Button();
            this.B3 = new System.Windows.Forms.Button();
            this.D2 = new System.Windows.Forms.Button();
            this.C2 = new System.Windows.Forms.Button();
            this.B2 = new System.Windows.Forms.Button();
            this.A4 = new System.Windows.Forms.Button();
            this.A3 = new System.Windows.Forms.Button();
            this.A2 = new System.Windows.Forms.Button();
            this.D1 = new System.Windows.Forms.Button();
            this.C1 = new System.Windows.Forms.Button();
            this.B1 = new System.Windows.Forms.Button();
            this.A1 = new System.Windows.Forms.Button();
            this.ENEMTTIMER = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(391, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 34);
            this.label1.TabIndex = 82;
            this.label1.Text = "PARTIDAS TOTALES JUGADAS: 0\r\n\r\n";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(489, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 47);
            this.button1.TabIndex = 81;
            this.button1.Text = "REGRESAR MENU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNATAQUE
            // 
            this.BTNATAQUE.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNATAQUE.Location = new System.Drawing.Point(300, 18);
            this.BTNATAQUE.Name = "BTNATAQUE";
            this.BTNATAQUE.Size = new System.Drawing.Size(84, 47);
            this.BTNATAQUE.TabIndex = 80;
            this.BTNATAQUE.Text = "ATACAR";
            this.BTNATAQUE.UseVisualStyleBackColor = true;
            this.BTNATAQUE.Click += new System.EventHandler(this.ATTACKEVENT);
            // 
            // CMBENEMYL
            // 
            this.CMBENEMYL.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CMBENEMYL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBENEMYL.DropDownWidth = 95;
            this.CMBENEMYL.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBENEMYL.FormattingEnabled = true;
            this.CMBENEMYL.Location = new System.Drawing.Point(175, 34);
            this.CMBENEMYL.Name = "CMBENEMYL";
            this.CMBENEMYL.Size = new System.Drawing.Size(103, 23);
            this.CMBENEMYL.TabIndex = 79;
            // 
            // LBLEMOVE
            // 
            this.LBLEMOVE.AutoSize = true;
            this.LBLEMOVE.BackColor = System.Drawing.Color.Transparent;
            this.LBLEMOVE.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLEMOVE.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LBLEMOVE.Location = new System.Drawing.Point(896, 25);
            this.LBLEMOVE.Name = "LBLEMOVE";
            this.LBLEMOVE.Size = new System.Drawing.Size(50, 40);
            this.LBLEMOVE.TabIndex = 78;
            this.LBLEMOVE.Text = "A1";
            // 
            // LBLROUNDS
            // 
            this.LBLROUNDS.AutoSize = true;
            this.LBLROUNDS.BackColor = System.Drawing.Color.Transparent;
            this.LBLROUNDS.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLROUNDS.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LBLROUNDS.Location = new System.Drawing.Point(443, 153);
            this.LBLROUNDS.Name = "LBLROUNDS";
            this.LBLROUNDS.Size = new System.Drawing.Size(179, 40);
            this.LBLROUNDS.TabIndex = 77;
            this.LBLROUNDS.Text = "ROUND: 20";
            // 
            // LBLENEMY
            // 
            this.LBLENEMY.AutoSize = true;
            this.LBLENEMY.BackColor = System.Drawing.Color.Transparent;
            this.LBLENEMY.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLENEMY.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LBLENEMY.Location = new System.Drawing.Point(896, 99);
            this.LBLENEMY.Name = "LBLENEMY";
            this.LBLENEMY.Size = new System.Drawing.Size(55, 40);
            this.LBLENEMY.TabIndex = 76;
            this.LBLENEMY.Text = "00";
            // 
            // LBLPLAYER
            // 
            this.LBLPLAYER.AutoSize = true;
            this.LBLPLAYER.BackColor = System.Drawing.Color.Transparent;
            this.LBLPLAYER.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLPLAYER.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LBLPLAYER.Location = new System.Drawing.Point(345, 99);
            this.LBLPLAYER.Name = "LBLPLAYER";
            this.LBLPLAYER.Size = new System.Drawing.Size(55, 40);
            this.LBLPLAYER.TabIndex = 75;
            this.LBLPLAYER.Text = "00";
            // 
            // Z4
            // 
            this.Z4.BackColor = System.Drawing.Color.White;
            this.Z4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Z4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z4.Location = new System.Drawing.Point(378, 451);
            this.Z4.Name = "Z4";
            this.Z4.Size = new System.Drawing.Size(87, 76);
            this.Z4.TabIndex = 99;
            this.Z4.Text = "Z4";
            this.Z4.UseVisualStyleBackColor = false;
            this.Z4.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Z3
            // 
            this.Z3.BackColor = System.Drawing.Color.White;
            this.Z3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Z3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z3.Location = new System.Drawing.Point(285, 451);
            this.Z3.Name = "Z3";
            this.Z3.Size = new System.Drawing.Size(87, 76);
            this.Z3.TabIndex = 98;
            this.Z3.Text = "Z3";
            this.Z3.UseVisualStyleBackColor = false;
            this.Z3.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Z2
            // 
            this.Z2.BackColor = System.Drawing.Color.White;
            this.Z2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Z2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z2.Location = new System.Drawing.Point(194, 451);
            this.Z2.Name = "Z2";
            this.Z2.Size = new System.Drawing.Size(87, 76);
            this.Z2.TabIndex = 97;
            this.Z2.Text = "Z2";
            this.Z2.UseVisualStyleBackColor = false;
            this.Z2.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Z1
            // 
            this.Z1.BackColor = System.Drawing.Color.White;
            this.Z1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Z1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z1.Location = new System.Drawing.Point(102, 451);
            this.Z1.Name = "Z1";
            this.Z1.Size = new System.Drawing.Size(87, 76);
            this.Z1.TabIndex = 96;
            this.Z1.Text = "Z1";
            this.Z1.UseVisualStyleBackColor = false;
            this.Z1.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Y4
            // 
            this.Y4.BackColor = System.Drawing.Color.White;
            this.Y4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Y4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y4.Location = new System.Drawing.Point(378, 374);
            this.Y4.Name = "Y4";
            this.Y4.Size = new System.Drawing.Size(87, 76);
            this.Y4.TabIndex = 95;
            this.Y4.Text = "Y4";
            this.Y4.UseVisualStyleBackColor = false;
            this.Y4.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Y3
            // 
            this.Y3.BackColor = System.Drawing.Color.White;
            this.Y3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Y3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y3.Location = new System.Drawing.Point(287, 374);
            this.Y3.Name = "Y3";
            this.Y3.Size = new System.Drawing.Size(85, 76);
            this.Y3.TabIndex = 94;
            this.Y3.Text = "Y3";
            this.Y3.UseVisualStyleBackColor = false;
            this.Y3.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Y2
            // 
            this.Y2.BackColor = System.Drawing.Color.White;
            this.Y2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Y2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y2.Location = new System.Drawing.Point(194, 374);
            this.Y2.Name = "Y2";
            this.Y2.Size = new System.Drawing.Size(87, 76);
            this.Y2.TabIndex = 93;
            this.Y2.Text = "Y2";
            this.Y2.UseVisualStyleBackColor = false;
            this.Y2.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // Y1
            // 
            this.Y1.BackColor = System.Drawing.Color.White;
            this.Y1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Y1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y1.Location = new System.Drawing.Point(101, 374);
            this.Y1.Name = "Y1";
            this.Y1.Size = new System.Drawing.Size(87, 76);
            this.Y1.TabIndex = 92;
            this.Y1.Text = "Y1";
            this.Y1.UseVisualStyleBackColor = false;
            this.Y1.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // X4
            // 
            this.X4.BackColor = System.Drawing.Color.White;
            this.X4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.X4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X4.Location = new System.Drawing.Point(378, 298);
            this.X4.Name = "X4";
            this.X4.Size = new System.Drawing.Size(87, 76);
            this.X4.TabIndex = 91;
            this.X4.Text = "X4";
            this.X4.UseVisualStyleBackColor = false;
            this.X4.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // X3
            // 
            this.X3.BackColor = System.Drawing.Color.White;
            this.X3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.X3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X3.Location = new System.Drawing.Point(285, 298);
            this.X3.Name = "X3";
            this.X3.Size = new System.Drawing.Size(87, 76);
            this.X3.TabIndex = 90;
            this.X3.Text = "X3";
            this.X3.UseVisualStyleBackColor = false;
            this.X3.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // X2
            // 
            this.X2.BackColor = System.Drawing.Color.White;
            this.X2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.X2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X2.Location = new System.Drawing.Point(194, 298);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(87, 76);
            this.X2.TabIndex = 89;
            this.X2.Text = "X2";
            this.X2.UseVisualStyleBackColor = false;
            this.X2.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // X1
            // 
            this.X1.BackColor = System.Drawing.Color.White;
            this.X1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.X1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X1.Location = new System.Drawing.Point(101, 298);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(87, 76);
            this.X1.TabIndex = 88;
            this.X1.Text = "X1";
            this.X1.UseVisualStyleBackColor = false;
            this.X1.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // W4
            // 
            this.W4.BackColor = System.Drawing.Color.White;
            this.W4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.W4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W4.Location = new System.Drawing.Point(378, 219);
            this.W4.Name = "W4";
            this.W4.Size = new System.Drawing.Size(87, 76);
            this.W4.TabIndex = 87;
            this.W4.Text = "W4";
            this.W4.UseVisualStyleBackColor = false;
            this.W4.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // W3
            // 
            this.W3.BackColor = System.Drawing.Color.White;
            this.W3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.W3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W3.Location = new System.Drawing.Point(286, 219);
            this.W3.Name = "W3";
            this.W3.Size = new System.Drawing.Size(87, 76);
            this.W3.TabIndex = 86;
            this.W3.Text = "W3";
            this.W3.UseVisualStyleBackColor = false;
            this.W3.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // W1
            // 
            this.W1.BackColor = System.Drawing.Color.White;
            this.W1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.W1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W1.Location = new System.Drawing.Point(101, 219);
            this.W1.Name = "W1";
            this.W1.Size = new System.Drawing.Size(87, 76);
            this.W1.TabIndex = 85;
            this.W1.Text = "W1";
            this.W1.UseVisualStyleBackColor = false;
            this.W1.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // W2
            // 
            this.W2.BackColor = System.Drawing.Color.White;
            this.W2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.W2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W2.Location = new System.Drawing.Point(194, 219);
            this.W2.Name = "W2";
            this.W2.Size = new System.Drawing.Size(87, 76);
            this.W2.TabIndex = 84;
            this.W2.Text = "W2";
            this.W2.UseVisualStyleBackColor = false;
            this.W2.Click += new System.EventHandler(this.PLAYERPOSITIONBUTTONEVENT);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(97, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 27);
            this.label2.TabIndex = 83;
            this.label2.Text = "ELIGE 3 POSICIONES DISTINTAS PARA TUS BARCOS";
            // 
            // D4
            // 
            this.D4.BackColor = System.Drawing.Color.White;
            this.D4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.D4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D4.Location = new System.Drawing.Point(878, 451);
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(87, 76);
            this.D4.TabIndex = 115;
            this.D4.Text = "D4";
            this.D4.UseVisualStyleBackColor = false;
            // 
            // D3
            // 
            this.D3.BackColor = System.Drawing.Color.White;
            this.D3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.D3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D3.Location = new System.Drawing.Point(787, 451);
            this.D3.Name = "D3";
            this.D3.Size = new System.Drawing.Size(87, 76);
            this.D3.TabIndex = 114;
            this.D3.Text = "D3";
            this.D3.UseVisualStyleBackColor = false;
            // 
            // C4
            // 
            this.C4.BackColor = System.Drawing.Color.White;
            this.C4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C4.Location = new System.Drawing.Point(878, 374);
            this.C4.Name = "C4";
            this.C4.Size = new System.Drawing.Size(87, 76);
            this.C4.TabIndex = 113;
            this.C4.Text = "C4";
            this.C4.UseVisualStyleBackColor = false;
            // 
            // C3
            // 
            this.C3.BackColor = System.Drawing.Color.White;
            this.C3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C3.Location = new System.Drawing.Point(785, 374);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(87, 76);
            this.C3.TabIndex = 112;
            this.C3.Text = "C3";
            this.C3.UseVisualStyleBackColor = false;
            // 
            // B4
            // 
            this.B4.BackColor = System.Drawing.Color.White;
            this.B4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.Location = new System.Drawing.Point(878, 298);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(87, 76);
            this.B4.TabIndex = 111;
            this.B4.Text = "B4";
            this.B4.UseVisualStyleBackColor = false;
            // 
            // B3
            // 
            this.B3.BackColor = System.Drawing.Color.White;
            this.B3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3.Location = new System.Drawing.Point(785, 298);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(87, 76);
            this.B3.TabIndex = 110;
            this.B3.Text = "B3";
            this.B3.UseVisualStyleBackColor = false;
            // 
            // D2
            // 
            this.D2.BackColor = System.Drawing.Color.White;
            this.D2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.D2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D2.Location = new System.Drawing.Point(694, 451);
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(87, 76);
            this.D2.TabIndex = 109;
            this.D2.Text = "D2";
            this.D2.UseVisualStyleBackColor = false;
            // 
            // C2
            // 
            this.C2.BackColor = System.Drawing.Color.White;
            this.C2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C2.Location = new System.Drawing.Point(694, 374);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(87, 76);
            this.C2.TabIndex = 108;
            this.C2.Text = "C2";
            this.C2.UseVisualStyleBackColor = false;
            // 
            // B2
            // 
            this.B2.BackColor = System.Drawing.Color.White;
            this.B2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B2.Location = new System.Drawing.Point(694, 298);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(87, 76);
            this.B2.TabIndex = 107;
            this.B2.Text = "B2";
            this.B2.UseVisualStyleBackColor = false;
            // 
            // A4
            // 
            this.A4.BackColor = System.Drawing.Color.White;
            this.A4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A4.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4.Location = new System.Drawing.Point(878, 219);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(87, 76);
            this.A4.TabIndex = 106;
            this.A4.Text = "A4";
            this.A4.UseVisualStyleBackColor = false;
            // 
            // A3
            // 
            this.A3.BackColor = System.Drawing.Color.White;
            this.A3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3.Location = new System.Drawing.Point(787, 219);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(87, 76);
            this.A3.TabIndex = 105;
            this.A3.Text = "A3";
            this.A3.UseVisualStyleBackColor = false;
            // 
            // A2
            // 
            this.A2.BackColor = System.Drawing.Color.White;
            this.A2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A2.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A2.Location = new System.Drawing.Point(694, 219);
            this.A2.Name = "A2";
            this.A2.Size = new System.Drawing.Size(87, 76);
            this.A2.TabIndex = 104;
            this.A2.Text = "A2";
            this.A2.UseVisualStyleBackColor = false;
            // 
            // D1
            // 
            this.D1.BackColor = System.Drawing.Color.White;
            this.D1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.D1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D1.Location = new System.Drawing.Point(601, 451);
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(87, 76);
            this.D1.TabIndex = 103;
            this.D1.Text = "D1";
            this.D1.UseVisualStyleBackColor = false;
            // 
            // C1
            // 
            this.C1.BackColor = System.Drawing.Color.White;
            this.C1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1.Location = new System.Drawing.Point(601, 374);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(87, 76);
            this.C1.TabIndex = 102;
            this.C1.Text = "C1";
            this.C1.UseVisualStyleBackColor = false;
            // 
            // B1
            // 
            this.B1.BackColor = System.Drawing.Color.White;
            this.B1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B1.Location = new System.Drawing.Point(601, 298);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(87, 76);
            this.B1.TabIndex = 101;
            this.B1.Text = "B1";
            this.B1.UseVisualStyleBackColor = false;
            // 
            // A1
            // 
            this.A1.BackColor = System.Drawing.Color.White;
            this.A1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A1.Location = new System.Drawing.Point(601, 219);
            this.A1.Name = "A1";
            this.A1.Size = new System.Drawing.Size(87, 76);
            this.A1.TabIndex = 100;
            this.A1.Text = "A1";
            this.A1.UseVisualStyleBackColor = false;
            // 
            // ENEMTTIMER
            // 
            this.ENEMTTIMER.Interval = 1000;
            this.ENEMTTIMER.Tick += new System.EventHandler(this.ENEMYPLAYTIMER);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BATTLESHIP_P.FINAL.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 586);
            this.Controls.Add(this.D4);
            this.Controls.Add(this.D3);
            this.Controls.Add(this.C4);
            this.Controls.Add(this.C3);
            this.Controls.Add(this.B4);
            this.Controls.Add(this.B3);
            this.Controls.Add(this.D2);
            this.Controls.Add(this.C2);
            this.Controls.Add(this.B2);
            this.Controls.Add(this.A4);
            this.Controls.Add(this.A3);
            this.Controls.Add(this.A2);
            this.Controls.Add(this.D1);
            this.Controls.Add(this.C1);
            this.Controls.Add(this.B1);
            this.Controls.Add(this.A1);
            this.Controls.Add(this.Z4);
            this.Controls.Add(this.Z3);
            this.Controls.Add(this.Z2);
            this.Controls.Add(this.Z1);
            this.Controls.Add(this.Y4);
            this.Controls.Add(this.Y3);
            this.Controls.Add(this.Y2);
            this.Controls.Add(this.Y1);
            this.Controls.Add(this.X4);
            this.Controls.Add(this.X3);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.X1);
            this.Controls.Add(this.W4);
            this.Controls.Add(this.W3);
            this.Controls.Add(this.W1);
            this.Controls.Add(this.W2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTNATAQUE);
            this.Controls.Add(this.CMBENEMYL);
            this.Controls.Add(this.LBLEMOVE);
            this.Controls.Add(this.LBLROUNDS);
            this.Controls.Add(this.LBLENEMY);
            this.Controls.Add(this.LBLPLAYER);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTNATAQUE;
        private System.Windows.Forms.ComboBox CMBENEMYL;
        private System.Windows.Forms.Label LBLEMOVE;
        private System.Windows.Forms.Label LBLROUNDS;
        private System.Windows.Forms.Label LBLENEMY;
        private System.Windows.Forms.Label LBLPLAYER;
        private System.Windows.Forms.Button Z4;
        private System.Windows.Forms.Button Z3;
        private System.Windows.Forms.Button Z2;
        private System.Windows.Forms.Button Z1;
        private System.Windows.Forms.Button Y4;
        private System.Windows.Forms.Button Y3;
        private System.Windows.Forms.Button Y2;
        private System.Windows.Forms.Button Y1;
        private System.Windows.Forms.Button X4;
        private System.Windows.Forms.Button X3;
        private System.Windows.Forms.Button X2;
        private System.Windows.Forms.Button X1;
        private System.Windows.Forms.Button W4;
        private System.Windows.Forms.Button W3;
        private System.Windows.Forms.Button W1;
        private System.Windows.Forms.Button W2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button D4;
        private System.Windows.Forms.Button D3;
        private System.Windows.Forms.Button C4;
        private System.Windows.Forms.Button C3;
        private System.Windows.Forms.Button B4;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Button D2;
        private System.Windows.Forms.Button C2;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Button A4;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button A2;
        private System.Windows.Forms.Button D1;
        private System.Windows.Forms.Button C1;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.Button A1;
        private System.Windows.Forms.Timer ENEMTTIMER;
    }
}