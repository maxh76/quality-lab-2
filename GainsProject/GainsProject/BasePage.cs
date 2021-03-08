﻿//---------------------------------------------------------------
// Name:    Ben Hefel
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To have the sidebar and to move between differnt pages
//---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GainsProject
{
    //---------------------------------------------------------------
    //Easy to follow user interface
    //---------------------------------------------------------------
    public partial class BasePage : Form
    {
        public BasePage()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------
        //Opens the tutorial page.
        //---------------------------------------------------------------
        private void tutorialButton_MouseClick(object sender, MouseEventArgs e)
        {
            TutorialPage tp = new TutorialPage();
            showUserControl(tp);
        }
        //---------------------------------------------------------------
        //Hides opened userControl and puts the one clicked on at the top.
        //---------------------------------------------------------------
        public void showUserControl(Control control)
        {
            Content.Controls.Clear();

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            Content.Controls.Add(control);
        }
        //---------------------------------------------------------------
        //Takes the user to the game selection of the program
        //---------------------------------------------------------------
        private void playButton_MouseClick(object sender, MouseEventArgs e)
        {
            GameSelectPage gsp = new GameSelectPage();
            showUserControl(gsp);
        }
        //---------------------------------------------------------------
        //Takes user to the page that shows previous scores in games
        //---------------------------------------------------------------
        private void previousResultsButton_MouseClick(object sender, MouseEventArgs e)
        {
            PreviousScoresPage psp = new PreviousScoresPage();
            showUserControl(psp);
        }
        //---------------------------------------------------------------
        //Takes user to the page that shows the top scores in each game
        //---------------------------------------------------------------
        private void leaderboardButton_MouseClick(object sender, MouseEventArgs e)
        {
            LeaderboardPage lp = new LeaderboardPage();
            showUserControl(lp);
        }
    }
}
