namespace ChessLogics
{
    public class Shadow : Piece
    {
        public Shadow(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            int dx = Math.Abs(X - other.X);
            int dy = Math.Abs(Y - other.Y);
            return dx == dy || X == other.X || Y == other.Y;
        }
    }

}
