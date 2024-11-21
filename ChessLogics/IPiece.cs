namespace ChessLogics
{
    public interface IPiece
    {
        int X { get; }
        int Y { get; }
        bool CanAttack(IPiece other);
        bool IsValidPosition(int x, int y);
    }
}
