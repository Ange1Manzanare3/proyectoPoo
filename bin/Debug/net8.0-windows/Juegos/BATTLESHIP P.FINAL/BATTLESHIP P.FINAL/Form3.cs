using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATTLESHIP_P.FINAL
{
    public partial class Form3 : Form
    {
        List<Button> PLAYERPOSITIONBUTTONS;
        List<Button> ENEMYPOSITIONBUTTONS;

        Random Random = new Random();
        int SHIPS = 3;
        int ROUND = 20;
        int PCONTADOR;
        int ECONTADOR;

        int PARTIDAST = 0;

        public Form3()
        {
            InitializeComponent();
            RESTARTGAME();
        }

        private void ENEMYPLAYTIMER(object sender, EventArgs e)
        {

            if (PLAYERPOSITIONBUTTONS.Count > 0 && ROUND > 0)
            {
                ROUND -= 1;
                LBLROUNDS.Text = $"ROUND:{ROUND}";
                int INDICE = Random.Next(PLAYERPOSITIONBUTTONS.Count);

                if ((string)PLAYERPOSITIONBUTTONS[INDICE].Tag == "BARCO JUGADOR")
                {
                    PLAYERPOSITIONBUTTONS[INDICE].BackgroundImage = Properties.Resources.fireIcon;
                    LBLEMOVE.Text = PLAYERPOSITIONBUTTONS[INDICE].Text;
                    PLAYERPOSITIONBUTTONS[INDICE].Enabled = false;
                    PLAYERPOSITIONBUTTONS[INDICE].BackColor = Color.DarkBlue;
                    PLAYERPOSITIONBUTTONS.RemoveAt(INDICE);
                    ECONTADOR += 1;
                    LBLENEMY.Text = ECONTADOR.ToString();
                    ENEMTTIMER.Stop();
                }
                else
                {

                    PLAYERPOSITIONBUTTONS[INDICE].BackgroundImage = Properties.Resources.missIcon;
                    LBLEMOVE.Text = PLAYERPOSITIONBUTTONS[INDICE].Text;
                    PLAYERPOSITIONBUTTONS[INDICE].Enabled = false;
                    PLAYERPOSITIONBUTTONS[INDICE].BackColor = Color.DarkBlue;
                    PLAYERPOSITIONBUTTONS.RemoveAt(INDICE);
                    ENEMTTIMER.Stop();

                }
            }

            if (ROUND < 1 || ECONTADOR > 2 || PCONTADOR > 2)
            {

                if (PCONTADOR > ECONTADOR)
                {
                    MessageBox.Show("GANASTE", "JUGADOR");
                    RESTARTGAME();
                }

                else if (ECONTADOR > PCONTADOR)
                {
                    MessageBox.Show("PERDISTE", "BOT");
                    RESTARTGAME();
                }

                else if (ECONTADOR == PCONTADOR)
                {
                    MessageBox.Show("EMPATARON", "BOT = JUGADOR");
                    RESTARTGAME();
                }


            }

        }

        private void ATTACKEVENT(object sender, EventArgs e)
        {

            if (CMBENEMYL.Text != "")
            {
                var PATAQUE = CMBENEMYL.Text.ToLower();
                int INDICE = ENEMYPOSITIONBUTTONS.FindIndex(a => a.Name.ToLower() == PATAQUE);

                
                if (INDICE >= 0 && INDICE < ENEMYPOSITIONBUTTONS.Count)
                {
                    if (ENEMYPOSITIONBUTTONS[INDICE].Enabled && ROUND > 0)
                    {
                        ROUND -= 1;
                        LBLROUNDS.Text = $"ROUND:{ROUND}";

                        if ((string)ENEMYPOSITIONBUTTONS[INDICE].Tag == "BARCO ENEMIGO")
                        {
                            ENEMYPOSITIONBUTTONS[INDICE].Enabled = false;
                            ENEMYPOSITIONBUTTONS[INDICE].BackgroundImage = Properties.Resources.fireIcon;
                            ENEMYPOSITIONBUTTONS[INDICE].BackColor = Color.DarkBlue;
                            PCONTADOR += 1;
                            LBLPLAYER.Text = PCONTADOR.ToString();
                            ENEMTTIMER.Start();
                        }
                        else
                        {
                            ENEMYPOSITIONBUTTONS[INDICE].Enabled = false;
                            ENEMYPOSITIONBUTTONS[INDICE].BackgroundImage = Properties.Resources.missIcon;
                            ENEMYPOSITIONBUTTONS[INDICE].BackColor = Color.DarkBlue;
                            ENEMTTIMER.Start();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Posición no válida, por favor elige una posición correcta.", "Información Importante");
                }
            }
            else
            {
                MessageBox.Show("ELIGE UNA POSICIÓN PARA ATACAR EN EL CMB", "INFORMACIÓN IMPORTANTE");
            }

        }

        private void PLAYERPOSITIONBUTTONEVENT(object sender, EventArgs e)
        {

            if (SHIPS > 0)
            {
                var button = (Button)sender;
                button.Enabled = false;
                button.Tag = "BARCO JUGADOR";
                button.BackColor = Color.Red;
                SHIPS -= 1;

            }
            if (SHIPS == 0)
            {
                BTNATAQUE.Enabled = true;
                BTNATAQUE.BackColor = Color.Red;
                BTNATAQUE.ForeColor = Color.White;
                label2.Text = $"2) AHORA ELIGE UNA POSICION PARA ATACAR EN EL TEXTBOX";
            }
        }

        private void RESTARTGAME()
        {


            PLAYERPOSITIONBUTTONS = new List<Button> { W1, W2, W3, W4, X1, X2, X3, X4, Y1, Y2, Y3, Y4, Z1, Z2, Z3, Z4 };
            ENEMYPOSITIONBUTTONS = new List<Button> { A1, A2, A3, A4, B1, B2, B3, B4, C1, C2, C3, C4, D1, D2, D3, D4 };
            CMBENEMYL.Items.Clear();

            CMBENEMYL.Text = null;
            label2.Text = $"1)ELIGE 3 POSICIONES DISTINTAS PARA TUS BARCOS";

            for (int i = 0; i < ENEMYPOSITIONBUTTONS.Count; i++)
            {
                ENEMYPOSITIONBUTTONS[i].Enabled = true;
                ENEMYPOSITIONBUTTONS[i].Tag = null;
                ENEMYPOSITIONBUTTONS[i].BackColor = Color.White;
                ENEMYPOSITIONBUTTONS[i].BackgroundImage = null;
                CMBENEMYL.Items.Add(ENEMYPOSITIONBUTTONS[i].Text);
            }

            for (int i = 0; i < PLAYERPOSITIONBUTTONS.Count; i++)
            {
                PLAYERPOSITIONBUTTONS[i].Enabled = true;
                PLAYERPOSITIONBUTTONS[i].Tag = null;
                PLAYERPOSITIONBUTTONS[i].BackColor = Color.White;
                PLAYERPOSITIONBUTTONS[i].BackgroundImage = null;

            }
            PCONTADOR = 0;
            ECONTADOR = 0;
            ROUND = 20;
            SHIPS = 3;

            LBLPLAYER.Text = PCONTADOR.ToString();
            LBLENEMY.Text = ECONTADOR.ToString();
            LBLEMOVE.Text = "A1";

            BTNATAQUE.Enabled = false;

            label1.Text = $"PARTIDAS TOTALES JUGADAS: {PARTIDAST}";
            PARTIDAST++;
            ENEMYLOCATIONPICKER();


        }

        private void ENEMYLOCATIONPICKER()
        {

            
            for (int i = 0; i < ENEMYPOSITIONBUTTONS.Count; i++)
            {
                ENEMYPOSITIONBUTTONS[i].Enabled = true;
                ENEMYPOSITIONBUTTONS[i].Tag = null;
                ENEMYPOSITIONBUTTONS[i].BackColor = Color.White;
                ENEMYPOSITIONBUTTONS[i].BackgroundImage = null;
            }

            
            int shipsToPlace = 3;
            List<int> selectedIndexes = new List<int>();

            while (selectedIndexes.Count < shipsToPlace)
            {
                int PICK = Random.Next(ENEMYPOSITIONBUTTONS.Count);

               
                if (!selectedIndexes.Contains(PICK))
                {
                    ENEMYPOSITIONBUTTONS[PICK].Tag = "BARCO ENEMIGO";
                    Debug.WriteLine("POSICION ENEMIGA: " + ENEMYPOSITIONBUTTONS[PICK].Text);
                    selectedIndexes.Add(PICK);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
