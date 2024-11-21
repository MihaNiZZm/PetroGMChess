namespace ChessLogics
{
    public class Rook : Piece
    {
        public Rook(int x, int y, ChessBoard board) : base(x, y, board) { }

        public override bool CanAttack(IPiece other)
        {
            if (X == other.X || Y == other.Y)
            {
                {
                    var obstacles = Board.GetPiecesOnPath(X, Y, other.X, other.Y);
                    return obstacles.Count == 0;
                }
            }
            return false;
        }
    }
}
