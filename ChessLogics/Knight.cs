namespace ChessLogics
{
    public class Knight : Piece
    {
        public Knight(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            int dx = Math.Abs(X - other.X);
            int dy = Math.Abs(Y - other.Y);
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
    }
}
