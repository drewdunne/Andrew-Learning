using System;
using System.Collections.Generic;

namespace TTO2
{
    class Gameboard
    {
        public const int GAMEBOARD_HEIGHT = 3;
        public const int GAMEBOARD_WIDTH = 3;

        public const int NUMBER_OF_SQUARES = GAMEBOARD_HEIGHT*GAMEBOARD_WIDTH;

        Square[,] gameSquares;

        public Gameboard()
        {
            gameSquares = new Square[GAMEBOARD_HEIGHT, GAMEBOARD_WIDTH];
        
            for (int _row = 0; _row < GAMEBOARD_HEIGHT; ++_row)
            {
                for (int _column = 0; _column < GAMEBOARD_WIDTH; ++_column)
                {
                    gameSquares[_row, _column] = new Square(_row, _column);
                }
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public void PrintBoard(Output renderer)
        {
            //Console Format for Board:
            //     |     |     
            //  1  |  2  |  3  
            //_____|_____|_____
            //     |     |     
            //  4  |  5  |  6  
            //_____|_____|_____
            //     |     |     
            //  7  |  8  |  9  
            //     |     |     
            // Currently, I believe the best option is for Printboard to simply send the board, 
            // formatted in the way above using boardItems, to Output. Output can take it from there.
            System.Console.WriteLine();
            
            for (int _row = 0; _row < GAMEBOARD_HEIGHT; ++_row)
            {
                var _currentRow = new Square[GAMEBOARD_WIDTH];

                for (int _column = 0; _column < GAMEBOARD_WIDTH; ++_column)
                {
                    _currentRow[_column] = gameSquares[_row, _column];
                }

                renderer.RenderGameboardRow(_currentRow);
            }
        }
    }
}