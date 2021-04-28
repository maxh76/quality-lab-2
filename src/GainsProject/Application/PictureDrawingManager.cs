﻿//---------------------------------------------------------------
// Name:    Ben Hefel
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To run the picture drawing game and manage the data
//---------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using GainsProject.Domain;

namespace GainsProject.Application
{
    //---------------------------------------------------------------
    //class that takes care of all the picture drawing logic
    //---------------------------------------------------------------
    public class PictureDrawingManager : BaseGame
    {
        public const int UPPER_PICTURE_LIMIT = 8;
        public const int COLOR_WHITE = 0;
        public const int COLOR_YELLOW = 1;
        public const int COLOR_ORANGE = 2;
        public const int COLOR_RED = 3;
        public const int COLOR_PURPLE = 4;
        public const int COLOR_BLUE = 5;
        public const int COLOR_GREEN = 6;
        public const int COLOR_BROWN = 7;
        public const int COLOR_BLACK = 8;
        public const int SCORE_SUB_MULTIPLIER = 5;
        //Seeded random
        private Random random;
        private DateTime startTime;
        private int[,] pictureArray;
        private int[,] drawingArray;
        private int color;
        private int xCoord;
        private int yCoord;
        private int boxSize;
        private int incorrectPictures;
        private int lastNum;
        
        public PictureDrawingManager()
        {
            random = new Random();
            startTime = new DateTime();
            color = 0;
            xCoord = 0;
            yCoord = 0;
            boxSize = 0;
            incorrectPictures = 0;
            lastNum = -1;
        }
        //---------------------------------------------------------------
        //runs the game, resets incorrect Pictures, startTime, gets a new
        // picture to copy.
        //---------------------------------------------------------------
        public override void runGame()
        {
            pictureArray = new int[8, 8];
            drawingArray = new int[8, 8];
            incorrectPictures = 0;
            loadPicturePanel();
            startTime = DateTime.Now;
            start();
        }
        //---------------------------------------------------------------
        //calculates the score
        //---------------------------------------------------------------
        public override void calculateScore()
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            long scoreSubtracter = Convert.ToInt64(elapsedTime.TotalSeconds) * SCORE_SUB_MULTIPLIER;
            setScore(1000 - scoreSubtracter - (incorrectPictures * 100));
        }
        //---------------------------------------------------------------
        //does not get used in this game
        //---------------------------------------------------------------
        public override int randomTime()
        {
            return -1;
        }
        //---------------------------------------------------------------
        //returns the game time as a string that resembles a clock
        //---------------------------------------------------------------
        public string getElapsedTime()
        {
            string timeString = "";
            TimeSpan elapsedTime = DateTime.Now - startTime;
            timeString += elapsedTime.Hours.ToString("00") + ": " +
                elapsedTime.Minutes.ToString("00") + ": " +
                elapsedTime.Seconds.ToString("00");
            return timeString;
        }
        //---------------------------------------------------------------
        //increments incorrectPictures
        //---------------------------------------------------------------
        public void incorrectAnswer()
        {
            ++incorrectPictures;
        }
        //---------------------------------------------------------------
        // gets incorrectPictures
        //---------------------------------------------------------------
        public string getIncorrectPictures()
        {
            return "" + incorrectPictures;
        }
        //---------------------------------------------------------------
        //checks if the drawing is the same as the given picture
        //---------------------------------------------------------------
        public bool checkPainting()
        {
            bool isMatch = true;
            for(int i = 0; i < UPPER_PICTURE_LIMIT; i ++)
            {
                for(int j = 0; j < UPPER_PICTURE_LIMIT; j++)
                {
                    if(pictureArray[i,j] != drawingArray[i,j])
                    {
                        isMatch = false;
                        return isMatch;
                    }
                }
            }
            calculateScore();
            endGame();
            return isMatch;
        }
        //---------------------------------------------------------------
        //colors the new square on the panel, and puts the color into the 
        //array to be compared later
        //---------------------------------------------------------------
        public void colorSquare(object sender, PaintEventArgs e)
        {
            int xPos = xCoord / boxSize;
            int yPos = yCoord / boxSize;
            drawingArray[xPos, yPos] = color;
            for(int i = 0; i < UPPER_PICTURE_LIMIT; i++)
            {
                for(int j = 0; j < UPPER_PICTURE_LIMIT; j++)
                {
                    Rectangle rect = new Rectangle(i * boxSize, j * boxSize, boxSize, boxSize);
                    e.Graphics.FillRectangle(coloredBrush(drawingArray[i,j]), rect);
                }
            }
        }
        //---------------------------------------------------------------
        //returns a brush with a color for the given int
        //---------------------------------------------------------------
        public SolidBrush coloredBrush(int color)
        {
            
            SolidBrush brush = new SolidBrush(Color.White);
            if(color == COLOR_WHITE)
            {
                brush = new SolidBrush(Color.White);
            }
            else if (color == COLOR_YELLOW)
            {
                brush = new SolidBrush(Color.Yellow);
            }
            else if (color == COLOR_ORANGE)
            {
                brush = new SolidBrush(Color.Orange);
            }
            else if (color == COLOR_RED)
            {
                brush = new SolidBrush(Color.Red);
            }
            else if (color == COLOR_PURPLE)
            {
                brush = new SolidBrush(Color.Purple);
            }
            else if (color == COLOR_BLUE)
            {
                brush = new SolidBrush(Color.Blue);
            }
            else if (color == COLOR_GREEN)
            {
                brush = new SolidBrush(Color.Green);
            }
            else if (color == COLOR_BROWN)
            {
                brush = new SolidBrush(Color.SaddleBrown);
            }
            else if (color == COLOR_BLACK)
            {
                brush = new SolidBrush(Color.Black);
            }
            return brush;
        }
        //---------------------------------------------------------------
        //sets the color
        //---------------------------------------------------------------
        public void setColor(int color)
        {
            this.color = color;
        }
        //---------------------------------------------------------------
        //sets color when a number is pressed instead of a button
        //---------------------------------------------------------------
        public void setColorWithKey(Keys key)
        {
            switch (key)
            {
                case Keys.D1:
                    setColor(COLOR_WHITE);
                    break;
                case Keys.D2:
                    setColor(COLOR_YELLOW);
                    break;
                case Keys.D3:
                    setColor(COLOR_ORANGE);
                    break;
                case Keys.D4:
                    setColor(COLOR_RED);
                    break;
                case Keys.D5:
                    setColor(COLOR_PURPLE);
                    break;
                case Keys.D6:
                    setColor(COLOR_BLUE);
                    break;
                case Keys.D7:
                    setColor(COLOR_GREEN);
                    break;
                case Keys.D8:
                    setColor(COLOR_BROWN);
                    break;
                case Keys.D9:
                    setColor(COLOR_BLACK);
                    break;
                default:
                    break;
            }
        }
        //---------------------------------------------------------------
        //gets the color
        //---------------------------------------------------------------
        public int getColor()
        {
            return color;
        }
        //---------------------------------------------------------------
        //sets the cursor coordinates and size of panel squares
        //---------------------------------------------------------------
        public void setPanelInfo(int x, int y, int boxSize)
        {
            xCoord = x;
            yCoord = y;
            this.boxSize = boxSize;
        }
        //---------------------------------------------------------------
        //fills the picture panel 
        //---------------------------------------------------------------
        public void fillPicturePanel(object sender, PaintEventArgs e)
        {
            boxSize = 30;
            for (int i = 0; i < UPPER_PICTURE_LIMIT; i++)
            {
                for (int j = 0; j < UPPER_PICTURE_LIMIT; j++)
                {
                    Rectangle rect = new Rectangle(i * boxSize, j * boxSize, boxSize, boxSize);
                    e.Graphics.FillRectangle(coloredBrush(pictureArray[i, j]), rect);
                }
            }
        }
        //---------------------------------------------------------------
        //makes the whole drawing panel white
        //---------------------------------------------------------------
        public void clearPanel(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, boxSize, boxSize);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);
        }
        //---------------------------------------------------------------
        // picks a random file out of the folder of pictures, and loads
        //it into the picture panel
        //---------------------------------------------------------------
        public void loadPicturePanel()
        {
            DirectoryInfo di = new DirectoryInfo("PictureDrawingFolder");
            FileInfo [] dirFiles = di.GetFiles();
            int fileCount = dirFiles.Length;
            int randomFile = random.Next(0, fileCount);
            if(randomFile == lastNum)
            {
                while(randomFile == lastNum)
                    randomFile = random.Next(0, fileCount);
            }
            string randomFileName = dirFiles[randomFile].Name;
            StreamReader sr = new StreamReader("PictureDrawingFolder/" + randomFileName);
            for (int i = 0; i < UPPER_PICTURE_LIMIT; i++)
            {
                for (int j = 0; j < UPPER_PICTURE_LIMIT; j++)
                {
                    pictureArray[i, j] = Convert.ToInt32(sr.ReadLine());
                }
            }
            lastNum = randomFile;
            sr.Close();
        }
    }
}