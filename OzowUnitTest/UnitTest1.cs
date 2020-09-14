using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using ComputeLibrary;
using System;

namespace OzowUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWithExample()
        {
            
            string input = "Contrary to popular belief, the pink unicorn flies east.";      
            Assert.AreEqual("aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy", input.ToLower().LettersOnly().OrderLetters());
           
        }

        [TestMethod]
        [DataRow("Contrary to popular belief, the pink unicorn flies east.", "contrarytopopularbeliefthepinkunicornflieseast")]
        [DataRow("a", "a")]
        [DataRow("123a", "a")]
        public void TestLettersOnly(string toCompute, string epectedNoLetter)
        {
             Assert.AreEqual(epectedNoLetter, toCompute.ToLower().LettersOnly());
        }

        [TestMethod]
        public void TestGameOfLifeSimple()
        {
            int[,] block = { { 0, 0, 0, 0 }, { 0, 1, 1, 0}, { 0, 1, 1, 0 }, { 0, 0, 0, 0} };
            GameOfLife gof = new GameOfLife(block);
            gof.nextGen();

            Assert.AreEqual(block, gof.getBoard());


        }
        [TestMethod]
        
        public void TestGameOfLifeGen(int [,] expectedBoard, int [,] board )
        {
            
            GameOfLife gof = new GameOfLife(board);
            gof.nextGen();

            Assert.AreEqual(board, gof.getBoard());

        }
    }
}
