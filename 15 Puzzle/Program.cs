// var myPlayer = new Player {Name = "John"};
// Console.WriteLine("Input an arrow key.");
// Action action = myPlayer.GetTurn();
// Console.WriteLine($"Player took action: {action}");

// var myBoard = new Board();
// myBoard.Render();
// myBoard.Shift(Direction.Up);
// Console.WriteLine("\n\n");
// myBoard.Render();

var myGame = new Game();
myGame.Play();


internal class Game
{
    public Player Player { get; } 
    public Board Board { get; }
    private int _turnNumber;
    
    public Game()
    {
        Player = new Player();
        Board = new Board();
        _turnNumber = 1;
    }

    private void PlayTurn()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Turn #{_turnNumber}");
        Console.ForegroundColor = ConsoleColor.White;
        
        Board.Render();
        
        Direction direction = Player.GetTurn();
        Board.Shift(direction);

        _turnNumber++;
    }

    public void Play()
    {
        while (!Board.GameOver())
        {
            Console.Clear();
            PlayTurn();
        }
        
        VictoryScreen();
    }

    private void VictoryScreen()
    {
        Console.Clear();
        
        Board.Render();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYOU WIN!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

internal enum Direction
{
    Up,
    Right,
    Down,
    Left
}

internal class Player
{
    private static bool IsArrowKey(ConsoleKey key)
    {
        return key == ConsoleKey.DownArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.RightArrow ||
               key == ConsoleKey.LeftArrow;
    }

    public string Name { get; init; } = "";

    public Direction GetTurn()
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (!IsArrowKey(key));

        return key switch
        {
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.RightArrow => Direction.Right,
            ConsoleKey.LeftArrow => Direction.Left,
            _ => throw new InvalidDataException("Key must be an arrow key")
        };
    }
}

internal class Tile
{
    public int Value {get;}

    public void Render()
    {
        if (Value == 0)
        {
            return;
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(Value);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public Tile(int value)
    {
        Value = value;
    }
}

internal class Board
{
    public bool GameOver()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.WriteLine(i*Width + j + 1);
                if (BoardState[i, j].Value != i * Width + j + 1) return false;
            }
        }
        
        return true;
    }
    
    public void Shift(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                ShiftRight();
                break;
            case Direction.Left:
                ShiftLeft();
                break;
            case Direction.Down :
                ShiftDown();
                break;
            case Direction.Up:
                ShiftUp();
                break;
            default:
                throw new InvalidDataException("Must be a valid Direction");
        }

        _emptySquare = GetEmptySquare();
    }
    
    public void ShiftUp()
    {
        for (int i = _emptySquare.Item1; i < Width -1 ; i++)
        {
            BoardState[i, _emptySquare.Item2] = BoardState[i+1, _emptySquare.Item2];
        }

        BoardState[Width-1, _emptySquare.Item2] = new Tile(0);
    }

    public void ShiftDown()
    {
        for (int i = _emptySquare.Item1 - 1; i >= 0; i--)
        {
            BoardState[i+1, _emptySquare.Item2] = BoardState[i, _emptySquare.Item2];
        }
        
        BoardState[0, _emptySquare.Item2] = new Tile(0);
    }

    public void ShiftRight()
    {
        for (int i = _emptySquare.Item2 - 1; i >= 0; i--)
        {
            BoardState[_emptySquare.Item1, i + 1] = BoardState[_emptySquare.Item1, i];
        }

        BoardState[_emptySquare.Item1, 0] = new Tile(0);
    }
    
    public void ShiftLeft()
    {
        for (int i = _emptySquare.Item2; i < Height -1 ; i++)
        {
            BoardState[_emptySquare.Item1, i] = BoardState[_emptySquare.Item1, i+1];
        }

        BoardState[_emptySquare.Item1, Height-1] = new Tile(0);
    }
    
    public void Render()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                BoardState[i,j].Render();
                Console.Write('\t');
            }
            Console.Write('\n');
        }
    }
    
    private static Tile[,] RandomBoard(int width, int height)
    {
        int[] shuffledArray = Enumerable.Range(0, width * height).ToArray();
        Random.Shared.Shuffle(shuffledArray);
        
        var board = new Tile[height, width];
        for (var i = 0; i < height * width; i++)
        {
            board[i / height, i % width] = new Tile(shuffledArray[i]);
        }
        
        return board;
    }

    private (int, int) GetEmptySquare()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                if (BoardState[i, j].Value == 0)
                    return (i,j);
            }
        }

        throw new InvalidDataException("Board must always contain an empty square (a zero), but it does not.");
    }
    
    public Tile[,] BoardState { get; private set; }
    public int Width { get; } = 4;
    public int Height { get; } = 4;
    
    private (int, int) _emptySquare;

    public Board()
    {
        Width = 4;
        Height = 4;
        BoardState = RandomBoard(4, 4);
        _emptySquare = GetEmptySquare();
    }
}