using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Grid
{
    private int size_x;
    private int size_y;

    private Dictionary<(int, int), bool> obstacles;

    public Grid(int sizeX, int sizeY)
    {
        size_x = sizeX;
        size_y = sizeY;
        obstacles = new Dictionary<(int, int), bool>();
    }

    public void AddObstacle(int posX, int posY)
    {
        obstacles.TryAdd((posY, posY), true);
    }
}