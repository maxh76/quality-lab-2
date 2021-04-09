﻿//---------------------------------------------------------------
// Name:    Ben Hefel
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To have the sidebar and to move between differnt pages
//---------------------------------------------------------------
using System;
using System.Linq;
using System.Windows.Forms;
using GainsProject.Application;

namespace GainsProject.UI
{
    //---------------------------------------------------------------
    //Easy to follow user interface
    //---------------------------------------------------------------
    public partial class BasePage : Form
    {
        //Name object to store the name
        NameClass nameStorage = new NameClass();
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
            GameModeSelect gsp = new GameModeSelect ();
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
        //---------------------------------------------------------------
        //Closes the application 
        //---------------------------------------------------------------
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string specialChar = " \\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            bool hasSpecial = false;
            string compareString = NameBox.Text;
            if (compareString == "")
            {
                WelcomeLabel.Text = "Enter your name";
                return;
            }
            foreach (char character in specialChar)
            {
                if (compareString.Contains(character))
                {
                    hasSpecial = true;
                }
            }
            if (hasSpecial)
            {
                WelcomeLabel.Text = "No Special Chars";
                return;
            }
            else 
            {
                nameStorage.setName(NameBox.Text);
                WelcomeLabel.Text = "Welcome " + nameStorage.getName();
                EnterButton.Hide();
            }
        }
    }
}
