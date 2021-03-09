﻿//---------------------------------------------------------------
// Name:    Ian Seidler
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To display an example game for the user to play
//---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace GainsProject
{
    //---------------------------------------------------------------
    //GUI side of the Example game
    //---------------------------------------------------------------
    public partial class ExampleGame : UserControl
    {
        public const int TIME_BUFFER = 20;
        //Game manager object to to the business logic
        ExampleGameManager game = new ExampleGameManager();
        public ExampleGame()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------
        //When the start button is clicked, The screen turns red, then
        //after a random ammount of time, the screen switched to green.
        //Once the screen turns green, the stopwatch starts.
        //---------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //Change background to red
            this.BackColor = System.Drawing.Color.Red;
            //Clean up leftover form elements
            richTextBox1.Hide();
            Startbutton.Hide();
            //Stay red for a random amount of time
            System.Threading.Thread.Sleep(game.randomTime());
            this.BackColor = System.Drawing.Color.Green;
            //Game is live!
            game.start();
            //Start the timer
            game.stopwatch.Start();
        }
        //---------------------------------------------------------------
        //If the screen is clicked durring the game, the stopwatch is 
        //stopped, and the time diffrence is calculated. The score is
        //then displayed to the user
        //---------------------------------------------------------------
        private void ExampleGame_Click(object sender, EventArgs e)
        {
            //If the game is live, then calculate the time
            if (game.isGameLive())
            {
                game.stopwatch.Stop();
                game.runGame();
                //If the user clicked too early
                if (game.getTime() < TIME_BUFFER)
                {
                    MessageBox.Show("Too early!\nScore:-100");
                    label1.Text = ("You clicked too early!");
                }
                //If the user did not click too early
                else
                {
                    //calculate the score
                    game.calculateScore();
                    MessageBox.Show("Nice it took: " + game.getTime() + " milliseconds\nScore: "
                        + game.getScore());
                    //Display the user's score
                    label1.Text = ("Score: " + game.getScore());
                }
            }
            //Game over!
            game.endGame();
        }
    }
}