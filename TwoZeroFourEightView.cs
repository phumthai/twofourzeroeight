﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
            score.Text = Convert.ToString(((TwoZeroFourEightModel)model).score);
            //
            if (((TwoZeroFourEightModel)model).isOver())
            {
                MessageBox.Show("Game Over");
                Close();
            }

        }
        
        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }

        private void Press(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                //btnUp.Focus();
                controller.ActionPerformed(TwoZeroFourEightController.UP);
                btnUp.Focus();
            }
            else if(e.KeyCode == Keys.Right)
            {
                //btnRight.Focus();
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                btnRight.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                //btnDown.Focus();
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                btnDown.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                //btnLeft.Focus();
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                btnLeft.Focus();
            }
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w'|| e.KeyChar == 'W')
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
                btnUp.Focus();
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                btnRight.Focus();
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                btnDown.Focus();
            }
            else if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                btnLeft.Focus();
            }
        }
    }
}
