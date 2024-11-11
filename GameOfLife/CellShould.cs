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
 *      State True -> Dead 🎯
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

public class CellAliveShould
{
    [Theory(DisplayName = "be dead when it has less than two neighbours")]
    [InlineData(0, true)]
    [InlineData(1, true)]
    public void be_dead_when_it_has_less_than_two_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.ChangeBehaviour();

        cell.State.Should().BeFalse();
    }
    
    [Theory(DisplayName = "be alive when it has 2 or 3 neighbours")]
    [InlineData(2, true)]
    [InlineData(3, true)]
    public void be_alive_when_it_has_2_or_3_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.ChangeBehaviour();

        cell.State.Should().BeTrue();
    }
    
    [Theory(DisplayName = "be dead when it has more than three neighbours")]
    [InlineData(4, true)]
    [InlineData(5, true)]
    [InlineData(6, true)]
    [InlineData(7, true)]
    [InlineData(8, true)]
    public void be_dead_when_it_has_more_than_three_neighbours(int neighbours, bool state)
    {
        var cell = new Cell(neighbours, state);

        cell.ChangeBehaviour();

        cell.State.Should().BeFalse();
    }
}

public class CellDeadShould
{
    [Fact(DisplayName = "be alive when it has 3 neighbours")]
    public void be_alive_when_it_has_3_neighbours()
    {
        var cell = new Cell(3, false);

        cell.ChangeBehaviour();

        cell.State.Should().BeTrue();
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

    public void ChangeBehaviour()
    {
        if (this.State == true)
        {
            if (this.Neighbours is < 2 or > 3)
            {
                this.State = false;
            }
        }
        else if (this.Neighbours == 3)
        {
            this.State = true;
        }
    }
}