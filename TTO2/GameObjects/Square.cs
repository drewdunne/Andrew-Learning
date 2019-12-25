namespace TTO2
{
    public enum Mark 
    {
        empty = ' ', 
        X = 'X', 
        O = 'O'
    }

    public class Square
    {
        public int row;
        public int column;
        public Mark contents;    
        public Square(int arow, int acolumn)
        {
            row = arow;
            column = acolumn;
            contents = Mark.empty;
        }
    }
}