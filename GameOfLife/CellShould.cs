using FluentAssertions;
/*
 * 1- Rules of cell
 *      State True -> Alive 🎯
 *          0 vecinos    -    False
 *          1 vecino     -    False
 *          2 vecinos    -    True
 *          3 vecinos    -    True
 *          4 vecinos    -    False
 *          5 vecinos    -    False
 *          6 vecinos    -    False
 *          7 vecinos    -    False
 *          8 vecinos    -    False
 *
 *      State True -> Dead
 *          0 vecinos    -    False
 *          1 vecinos    -    False
 *          2 vecinos    -    False
 *          3 vecinos    -    True
 *          4 vecinos    -    False
 *          5 vecinos    -    False
 *          6 vecinos    -    False
 *          7 vecinos    -    False
 *          8 vecinos    -    False
 */
namespace GameOfLife;

public class CellShould
{
    [Theory(DisplayName = "be dead when it has less than two neighbours")]
    [InlineData(0, false)]
    [InlineData(1, false)]
    public void be_dead_when_it_has_less_than_two_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.Change();

        cell.State.Should().BeFalse();
    }
    
    [Theory(DisplayName = "be alive when it has 2 or 3 neighbours")]
    [InlineData(2, true)]
    [InlineData(3, true)]
    public void be_alive_when_it_has_2_or_3_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.Change();

        cell.State.Should().BeTrue();
    }
    
    [Theory(DisplayName = "be dead when it has more than three neighbours")]
    [InlineData(4, false)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    [InlineData(7, false)]
    [InlineData(8, false)]
    public void be_dead_when_it_has_more_than_three_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.Change();

        cell.State.Should().BeFalse();
    }
}

public class Cell
{
    public int Neighbours { get; }
    public bool State { get; set; }

    public Cell(int neighbours, bool state)
    {
        Neighbours = neighbours;
        State = state;
    }

    public void Change()
    {
        if (this.Neighbours < 2 || this.Neighbours > 3) this.State = false;
    }
}

