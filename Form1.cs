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
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer playerTurn = enPlayer.player1_X;
        public Form1()
        {
            InitializeComponent();
        }

        enum enPlayer
        {
            player1_X,
            player2_O
        }
        enum enWinner
        {
            player1Win,
            player2Win,
            Draw,
            GameInProgres
               
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short Playcount;
        }
       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White,10);
            pen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap=System.Drawing.Drawing2D.LineCap.Round;

            //||
            e.Graphics.DrawLine(pen,700, 40, 700, 390);
            e.Graphics.DrawLine(pen,500, 40, 500, 390);

            //---
            e.Graphics.DrawLine(pen, 360, 280, 840, 280);
            e.Graphics.DrawLine(pen, 360, 150, 840, 150);

        }

        public bool checkValues(Button b1, Button b2, Button b3)
        {
            if (b1.Tag.ToString() != "?" && b1.Tag.ToString() == b2.Tag.ToString() && b1.Tag.ToString() == b3.Tag.ToString())
            {
                b1.BackColor = Color.GreenYellow;
                b3.BackColor = Color.GreenYellow;
                b2.BackColor = Color.GreenYellow;
                if (b1.Tag.ToString().Equals("X"))
                {
                    GameStatus.Winner = enWinner.player1Win;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.player2Win;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;    
            return false;
        }



        public void CheckWinner()
        {
            if(checkValues(button1, button2, button3))
                return;
            if(checkValues(button4, button5, button6))
                return;
            if(checkValues(button7, button8, button9))
                return;
            if(checkValues(button1, button4, button7))
                return;
            if(checkValues(button2, button5, button8))
                return;
            if(checkValues(button3, button6, button9))
                return;
            if(checkValues(button1, button5, button9))
                return;
            if(checkValues(button3, button5, button7))
                return;
        }

        public void ChangeImage(Button b)
        {
            if (b.Tag.ToString().Equals("?"))
            {
                switch(playerTurn){
                    case enPlayer.player1_X:
                        b.Image = Resources.X;
                        playerTurn = enPlayer.player2_O;
                        GameStatus.Playcount++;
                        b.Tag = "X";
                        lbPlayerTurn.Text = "Player2(O)";
                        CheckWinner();
                        break;
                    case enPlayer.player2_O:
                        b.Image = Resources.O;
                        playerTurn = enPlayer.player1_X;
                        GameStatus.Playcount++;
                        b.Tag = "O";
                        lbPlayerTurn.Text = "Player1(X)";
                        CheckWinner();
                        break;
                }
            }
            else
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if(GameStatus.Playcount == 9)
            {
                GameStatus.GameOver=true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        public void EndGame()
        {
            lbPlayerTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.player1Win:
                    lbWinner.Text = "Player 1 (X) is Winner";
                    break;
                case enWinner.player2Win:
                    lbWinner.Text = "Player 2 (O) is Winner";
                    break;
                case enWinner.Draw:
                    lbWinner.Text = "Draw";
                    break;

            } 
            //MessageBox.Show("Game Endded", "Game Endded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }


        public void ResetButton(Button b)
        {
            b.Image=Resources.question_mark_96;
            b.BackColor=Color.Transparent;
            b.Tag = "?";
            b.Enabled = true;
        }


        public void RestartGame()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            GameStatus.GameOver = false;
            GameStatus.Playcount = 0;
            GameStatus.Winner = enWinner.GameInProgres;
            playerTurn = enPlayer.player1_X;
            lbPlayerTurn.Text = "Player1(X)";
            lbWinner.Text = "In Progres";
        }


        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button) sender);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
