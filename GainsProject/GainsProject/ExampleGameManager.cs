﻿//---------------------------------------------------------------
// Name:    Ian Seidler
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To run the example game and manage the data
//---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainsProject
{
    //---------------------------------------------------------------
    //Runs the Example game and manages the data
    //---------------------------------------------------------------
    public class ExampleGameManager : BaseGame
    {
        //Constants
        public const int RANDOM_TIME_MIN = 1000;
        public const int RANDOM_TIME_MAX = 10000;
        public const int BASE_SCORE_CALCULATION = 200;
        public const int MAX_SCORE = 1000;
        public const int TOO_EARLY_SCORE = -100;
        //---------------------------------------------------------------
        //Sets the time then resets the stopwatch
        //---------------------------------------------------------------
        public override void runGame()
        {
            this.setTime(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        //---------------------------------------------------------------
        //Gives a random number of milliseconds from 1000-10000
        //---------------------------------------------------------------
        public override int randomTime()
        {
            Random rnd = new Random();
            int time = rnd.Next(RANDOM_TIME_MIN, RANDOM_TIME_MAX);
            return time;
        }
        //---------------------------------------------------------------
        //Calculates the score based on the time
        //---------------------------------------------------------------
        public override void calculateScore()
        {
            //Cheating check
            if(this.getTime() == 0)
            {
                this.setScore(TOO_EARLY_SCORE);
                return;
            }
            //If the user was quicker than the base point
            if (this.getTime() < BASE_SCORE_CALCULATION)
            {
                //Set to full points
                this.setScore(MAX_SCORE);
                return;
            }
            //If the user took longer than 200, subtract it from 1200 to
            //get the score
            long score = BASE_SCORE_CALCULATION + MAX_SCORE - this.getTime();
            //If the score is negative, set to zero
            if (score < 0)
                score = 0;
            this.setScore(score);
        }
    }
}
