﻿//---------------------------------------------------------------
// Name:    Nick Hefel
// Project: SE 3330 team:Xx_Bigger_Gains_xX
// Purpose: To test the ScoreSave class
//---------------------------------------------------------------
using GainsProject.Application;
using GainsProject.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigGainsTests
{
    //---------------------------------------------------------------
    //Test the ScoreSave Class
    //---------------------------------------------------------------
    [TestClass]
    public class ScoreSaveTests
    {
        //---------------------------------------------------------------
        //Test the constructor and the getSaveDataListIndex method
        //---------------------------------------------------------------
        [TestMethod]
        public void TestConstructor()
        {
            ScoreSave scoreSave = new ScoreSave();
            Assert.AreEqual("Nick", scoreSave.getSaveDataListIndex(0).getPlayerTag());
        }
        //---------------------------------------------------------------
        //test the add score
        //---------------------------------------------------------------
        [TestMethod]
        public void TestAddScore()
        {
            ScoreSave scoreSave = new ScoreSave();
            int tempGames = scoreSave.getNumGames();
            scoreSave.addScore(13, "Ben");
            Assert.AreEqual("Ben", scoreSave.getSaveDataList()[tempGames].getPlayerTag());
            Assert.AreEqual(tempGames + 1, scoreSave.getNumGames());
        }
    }
}
