namespace DotnetStarter.Logic;

public class GridAccessController
{
    private Grid _grid;

    public GridAccessController(Grid grid) => _grid = grid;

    public bool IsPointAnObstacle(int posX, int posY)
    {
        return _grid.IsObstacle(posX, posY);
    }
}