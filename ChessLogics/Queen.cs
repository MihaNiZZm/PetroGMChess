namespace ChessLogics
{
    public class Queen : Piece
    {
        public Queen(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            int dx = Math.Abs(X - other.X);
            int dy = Math.Abs(Y - other.Y);

            
            if (dx == dy || X == other.X || Y == other.Y)
            {
                var obstacles = Board.GetPiecesOnPath(X, Y, other.X, other.Y);
                return obstacles.Count == 0;
            }

            return false;
        }
    }
}
