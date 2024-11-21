namespace ChessLogics
{
    public class ChessBoard
    {
        private List<IPiece> pieces;
        public int BoardSize { get; }
        public int MoveCount { get; private set; }

        public ChessBoard()
        {
            pieces = new List<IPiece>();
            MoveCount = 0;
            BoardSize = 8;
        }

        public List<IPiece> GetPiecesOnPath(int startX, int startY, int endX, int endY)
        {
            List<IPiece> onPath = new();

            int dx = Math.Sign(endX - startX);
            int dy = Math.Sign(endY - startY);

            int x = startX + dx;
            int y = startY + dy;

            while (x != endX || y != endY)
            {
                var piece = pieces.FirstOrDefault(p => p.X == x && p.Y == y);
                if (piece != null)
                {
                    onPath.Add(piece);
                }

                x += dx;
                y += dy;
            }

            return onPath;
        }

        public bool IsCellOccupied(int x, int y)
        {
            return pieces.Any(p => p.X == x && p.Y == y);
        }

        public void AddPiece(IPiece piece)
        {
            if (!piece.IsValidPosition(piece.X, piece.Y))
            {
                throw new ArgumentException($"Cannot place piece at ({piece.X}, {piece.Y}).");
            }

            pieces.Add(piece);
        }

        public Dictionary<IPiece, List<IPiece>> GetAttackingPairs()
        {
            var attackingPairs = new Dictionary<IPiece, List<IPiece>>();

            foreach (var attacker in pieces)
            {
                foreach (var target in pieces)
                {
                    if (attacker != target && attacker.CanAttack(target))
                    {
                        if (!attackingPairs.ContainsKey(attacker))
                        {
                            attackingPairs[attacker] = new List<IPiece>();
                        }
                        attackingPairs[attacker].Add(target);
                    }
                }
            }

            return attackingPairs;
        }

        public void DrawBoard()
        {
            char[,] board = new char[BoardSize, BoardSize];

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    board[i, j] = '.';
                }
            }

            foreach (var piece in pieces)
            {
                board[piece.X, piece.Y] = GetPieceSymbol(piece);
            }

            for (int y = 0; y < BoardSize; ++y)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    Console.Write(board[y, x] + " ");
                }
                Console.WriteLine();
            }
        }

        private char GetPieceSymbol(IPiece piece)
        {
            return piece switch
            {
                King => 'K',
                Queen => 'Q',
                Rook => 'R',
                Bishop => 'B',
                Knight => 'N',
                Shadow => 'S',
                _ => '?'
            };
        }
    }

}
