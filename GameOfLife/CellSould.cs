using FluentAssertions;

namespace GameOfLife;

public class CellSould
{
    [Fact(DisplayName = "be dead when it has less than two neighbours")]
    public void be_dead_when_it_has_less_than_two_neighbours()
    {
        var cell = new Cell(1, true);

        cell.Change();

        cell.State.Should().BeFalse();
    }
}

public class Cell
{
    public int Neighbours { get; }
    public bool State { get; }

    public Cell(int neighbours, bool state)
    {
        Neighbours = neighbours;
        State = state;
    }

    public void Change()
    {
        
    }
}

