using FluentAssertions;

namespace GameOfLife;

public class GameOfLifeTest
{
    [Fact(DisplayName = "dead only one cell")]
    public void dead_only_one_cell()
    {
        var gameOfLife = new GameOfLife(new bool[3,3]);

        gameOfLife.NextGen();

        gameOfLife.Should().Be(gameOfLife);
    }
}

public class GameOfLife
{
    public bool[,] Board { get; set; }

    public GameOfLife(bool[,] board)
    {
        Board = board;
    }

    public void NextGen()
    {
        
    }
}

public class Grid
{
    public int Row { get; }
    public int Column { get; }

    public Grid(int row, int column)
    {
        Row = row;
        Column = column;
    }
}