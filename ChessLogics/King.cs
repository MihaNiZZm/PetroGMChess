namespace ChessLogics
{
    public class King : Piece
    {
        public King(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            int dx = Math.Abs(X - other.X);
            int dy = Math.Abs(Y - other.Y);
            return dx <= 1 && dy <= 1;
        }
    }
}
