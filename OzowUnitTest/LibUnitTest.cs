using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using ComputeLibrary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace OzowUnitTest
{
    [TestClass]
    public class LibUnitTest
    {

        //Testing the sorting library
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
        [DataRow("Contrary to popular belief, the pink unicorn flies east.", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [DataRow("a", "a")]
        [DataRow("123a", "a")]
        [DataRow("--123@#$%%&*(&", "")]
        public void TestLetterSort(string toCompute, string epectedNoLetter)
        {
            Assert.AreEqual(epectedNoLetter, toCompute.ToLower().LettersOnly().OrderLetters());
        }


        //Testing Game of life class
        [TestMethod]
        public void TestGameOfLifeShouldLive()
        {
            int[,] board = { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
            GameOfLife gof = new GameOfLife(board);
            gof.nextGen();

            Assert.AreEqual(false,gof.shouldLive(0, 1) );
            Assert.AreEqual(true, gof.shouldLive(1, 1) );
            Assert.AreEqual(true, gof.shouldLive(1, 2) );
            Assert.AreEqual(true, gof.shouldLive(2, 1) );
            Assert.AreEqual(true, gof.shouldLive(2, 2) );

            gof = new GameOfLife(new int[,]{ { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 } });
            gof.nextGen();
            gof.nextGen();

            Assert.AreEqual( false, gof.shouldLive(1, 2));
            Assert.AreEqual( true , gof.shouldLive(2, 1));
            Assert.AreEqual( true , gof.shouldLive(2, 2));
            Assert.AreEqual( true , gof.shouldLive(2, 3));
            Assert.AreEqual( false, gof.shouldLive(3, 2));
        }

        [TestMethod]
        public void TestGameOfLifeSimple()
        {
            int[,] block = { { 0, 0, 0, 0 }, { 0, 1, 1, 0}, { 0, 1, 1, 0 }, { 0, 0, 0, 0} };
            GameOfLife gof = new GameOfLife(block);
            gof.nextGen();

            Assert.AreEqual(block, gof.getBoard());
        }

        [DataTestMethod]
        [DynamicData(nameof(TestDataMethod), DynamicDataSourceType.Method)]
        public void TestGameOfLifeGen(int [,] expectedBoard, int [,] board )
        {
            GameOfLife gof = new GameOfLife(board);
            gof.nextGen();

            for (int i = 0; i < board.Length / board.GetLength(0); i++)           
                for (int j = 0; j < board.GetLength(0); j++)
                    Assert.AreEqual(expectedBoard[i, j], gof.getBoard()[i, j]);
        }

        static IEnumerable<object[]> TestDataMethod()
        {
            yield return new[] {

                new [,]{ { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 } },
                new [,]{ { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } }
                         };
        }
     
    }
}
