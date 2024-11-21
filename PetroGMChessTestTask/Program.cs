using ChessLogics;

class Program
{
    static void Main()
    {
        ChessBoard board = new ChessBoard();

        Console.WriteLine("Введите описание фигур (например, 'king 0 0'), затем пустую строку для завершения:");

        var inputLines = new List<string>();
        while (true)
        {
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                break;

            inputLines.Add(line);
        }

        // Парсим входные данные
        ParseInput(board, inputLines);

        // Рисуем доску
        Console.WriteLine("\nШахматная доска:");
        board.DrawBoard();

        // Проверяем, кто кого атакует
        var attacks = board.GetAttackingPairs();
        Console.WriteLine("\nАтаки:");
        foreach (var attacker in attacks)
        {
            Console.WriteLine($"{attacker.Key.GetType().Name} ({attacker.Key.X}, {attacker.Key.Y}) атакует:");
            foreach (var target in attacker.Value)
            {
                Console.WriteLine($"  - {target.GetType().Name} ({target.X}, {target.Y})");
            }
        }
    }

    public static void ParseInput(ChessBoard board, IEnumerable<string> inputLines)
    {
        foreach (var line in inputLines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3 || !int.TryParse(parts[1], out int x) || !int.TryParse(parts[2], out int y))
            {
                Console.WriteLine($"Некорректная строка: {line}");
                continue;
            }

            string pieceType = parts[0].ToLower();

            try
            {
                switch (pieceType)
                {
                    case "king":
                        board.AddPiece(new King(x, y, board));
                        break;
                    case "queen":
                        board.AddPiece(new Queen(x, y, board));
                        break;
                    case "rook":
                        board.AddPiece(new Rook(x, y, board));
                        break;
                    case "bishop":
                        board.AddPiece(new Bishop(x, y, board));
                        break;
                    case "knight":
                        board.AddPiece(new Knight(x, y, board));
                        break;
                    case "shadow":
                        board.AddPiece(new Shadow(x, y, board));
                        break;
                    default:
                        Console.WriteLine($"Неизвестный тип фигуры: {pieceType}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении фигуры {pieceType} на позицию ({x}, {y}): {ex.Message}");
            }
        }
    }
}
