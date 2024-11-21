namespace ChessLogics
{
    public abstract class Piece : IPiece
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        protected ChessBoard Board { get; }

        protected Piece(int x, int y, ChessBoard board)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));

            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position for a chess piece.");
            }

            X = x;
            Y = y;
        }

        public abstract bool CanAttack(IPiece other);

        public virtual bool IsValidPosition(int x, int y)
        {
            if (x < 0 || x >= Board.BoardSize || y < 0 || y >= Board.BoardSize)
            {
                return false;
            }

            return !Board.IsCellOccupied(x, y);
        }
    }


}
