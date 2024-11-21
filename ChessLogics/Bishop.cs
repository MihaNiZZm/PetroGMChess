namespace ChessLogics
{
    public class Bishop : Piece
    {
        public Bishop(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            if (Math.Abs(X - other.X) == Math.Abs(Y - other.Y))
            {
                var obstacles = Board.GetPiecesOnPath(X, Y, other.X, other.Y);
                return obstacles.Count == 0;
            }

            return false;
        }
    }
}
