namespace ChessLogics
{
    public class ShadowTrail : Piece
    {
        private readonly int spawnedAtMove;
        public int Lifetime { get; private set; }

        public ShadowTrail(int x, int y, ChessBoard board, int lifetime = 1) : base(x, y, board)
        {
            spawnedAtMove = Board.MoveCount;
            Lifetime = lifetime;
        }

        public override bool CanAttack(IPiece other)
        {
            // ShadowTrail не атакует
            return false;
        }

        public bool IsExpired()
        {
            return Board.MoveCount - spawnedAtMove > Lifetime;
        }
    }

}
