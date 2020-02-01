using System;

namespace TTO2
{
    public class Output
    {
        enum RowPosition {TopOfBoard, MiddleOfBoard, BottomOfBoard};
        public Output()
        {
            
        }

        public void Render(string output)
        {
            Console.Write(output);
        }

        public void Render(string[] output)
        {
            for (int item = 0; item < output.Length; ++item)
            {
                Console.Write(output[item]);
            }
        }

        public void PrintMessage(string output)
        {
            System.Console.Write(output);
        }

        public void PrintGeneral(string output)
        {
            System.Console.Write(output);
        }

        public void CleanUpInterface()
        {
            Console.Clear();
        }

        #region Board Rendering
        public void RenderGameboardRow(Square[] squaresToPrint)
        {
            RowPosition _rowType = GetRowType(squaresToPrint[0]);

            switch (_rowType)
            {
                case RowPosition.TopOfBoard: // Top Row
                {
                    RenderBlankRow();
                    RenderMiddleRow(squaresToPrint);
                    RenderBottomRow();
                    break;
                }

                case RowPosition.MiddleOfBoard: // Middle Rows
                {
                    RenderBlankRow();
                    RenderMiddleRow(squaresToPrint);
                    RenderBottomRow();
                    break;
                }

                case RowPosition.BottomOfBoard: // Bottom Row
                {
                    RenderBlankRow();
                    RenderMiddleRow(squaresToPrint);
                    RenderBlankRow();
                    break;
                }
                    
                default: // Other
                    throw new ArgumentException();
            };
        }
        private RowPosition GetRowType(Square sampleSquare)
        {
            if (sampleSquare.row == 0) // Row is Top Row
            {
                return RowPosition.TopOfBoard;
            }
            else if (sampleSquare.row == Gameboard.GAMEBOARD_HEIGHT -1) // Row is Bottom Row
            {
                return RowPosition.BottomOfBoard;
            }
            else if (sampleSquare.row >= 0 && sampleSquare.row < Gameboard.GAMEBOARD_HEIGHT) // Row is Middle row(s)
            {
                return RowPosition.MiddleOfBoard;
            }
            else // Row is out of bounds
            {
                throw new ArgumentException();
            }
        }

        private void RenderBlankRow()
        {
            System.Console.Write("     |     |     \n");
        }

        private void RenderBottomRow()
        {
            System.Console.Write("_____|_____|_____\n");
        }

        private void RenderMiddleRow(Square[] squares)
        {
            foreach (var square in squares)
            {
               // System.Console.Write($"  {square.contents.ToString()}  \n");
               System.Console.Write($"     ");
               if (square != squares[squares.Length-1])
               {
                   System.Console.Write("|");
               }
            };
            System.Console.Write("\n");
        }
#endregion

        
    }
}