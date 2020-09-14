using System;

namespace ComputeLibrary
{
    public static class Assessment
    {

        //Order letters 
        public static string OrderLetters(this string str)
        {
            if (str.Length < 1) return ""; //Assumption string is empty

            int smallestLetter = 0;  //Assumption smallest letter is at index 0

            for (int i = 0; i < str.Length; i++)
                if (str[i] < str[smallestLetter])
                    smallestLetter = i;             //Last value recorded here is the index with the smallest letter
            
            return str[smallestLetter] + OrderLetters(str.Remove(smallestLetter, 1));
        }

        //Remove non-letter characters
        public static string LettersOnly(this string str)
        {
            if (str.Length <1) return "";

            return (!Char.IsLetter(str[0])) ? LettersOnly(str.Remove(0, 1)) : str[0] + LettersOnly(str.Remove(0, 1)); 
        }

    }

    public class GameOfLife
    {
        private int[,] _board;
        private int[,] _cacheboard;

        public GameOfLife(int boardlength)
        {
            _board = new int[boardlength,boardlength];
            _cacheboard = new int[boardlength, boardlength];
        }
        public GameOfLife(int [,] board)
        {
            _board = board;
          _cacheboard = new int[board.GetLength(0), board.GetLength(0)];
        }
        public int[,] getBoard()
        {
            return _board;
        } 

        //Check for the next generation 
        public bool shouldLive(int x,int y)
        {
            int neighboursAlive = 0;

            if(x-1 >=0 && y - 1 >= 0)
            {
                neighboursAlive += _cacheboard[x -1, y -1];
                 neighboursAlive += _cacheboard[x -1, y];
                neighboursAlive += _cacheboard[x, y - 1];
            }

            if (x - 1 >= 0 && y +1 < _board.GetLength(0))
                neighboursAlive += _cacheboard[x - 1, y+1];

            if (x + 1 < _board.GetLength(0) && y - 1 >= 0)
                neighboursAlive += _cacheboard[x + 1 , y - 1];

            if (x + 1 < _board.GetLength(0) && y + 1 < _board.GetLength(0)) { 
                neighboursAlive += _cacheboard[x + 1, y + 1];
                neighboursAlive += _cacheboard[x, y + 1];
                neighboursAlive += _cacheboard[x + 1, y];
                }
            if (_cacheboard[x, y] == 1)
                return (neighboursAlive == 2 || neighboursAlive == 3) ? true : false;

                return ( neighboursAlive == 3) ? true : false;
        }
        public void setAlive(int x, int y) { _board[x, y] = 1; }
        public void setADead(int x, int y) { _board[x, y] = 0; }

        //Changes for the next generation were interfering with my current generation conditions hence temporary board
        private void updateCache() {
            for (int i = 0; i < _board.Length / _board.GetLength(0); i++)
                for (int j = 0; j < _board.GetLength(0); j++)
                
                    _cacheboard[i, j] = _board[i, j];

        }

        //Moving to the Next generation
        public void nextGen()
        {
         updateCache();
            for (int i=0;i< _board.Length/ _board.GetLength(0); i++)
                for(int j = 0; j < _board.GetLength(0); j++)
                    if (shouldLive(i, j))
                        setAlive(i, j);
                    else setADead(i, j);                  
        

        updateCache();
        }

    }
}
