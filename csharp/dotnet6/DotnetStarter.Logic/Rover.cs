using System;
using System.Runtime.CompilerServices;
using DotnetStarter.Logic.Enums;

namespace DotnetStarter.Logic;

public class Rover
{
    private int _posX;
    private int _posY;
    private DirectionController _directionController;
    private GridAccessController _grid;
    private bool _facingObstacle;
    private string _report;

    public Rover(Grid grid)
    {
        _posX = 0;
        _posY = 0;
        _directionController = new();
        _grid = new(grid);
        UpdateReport();
    }
    
    public void ExecuteCommands(string commands)
    {
        foreach (char command in commands)
        {
            if (command is 'M')
            {
                (int nextX, int nextY) = GetNextPoint();
                _facingObstacle = _grid.IsPointAnObstacle(nextX, nextY);
                if (!_facingObstacle)
                {
                    Move(nextX, nextY);
                }
                else break;
            }
            else if (command is 'L' or 'R') Rotate(command);
        }
        UpdateReport();
    }

    private (int, int) GetNextPoint()
    {
        (int incrementX, int incrementY) = _directionController.GetFacingAsCoordinates();
        return (_posX + incrementX, _posY + incrementY);
    }

    public string GetReport()
    {
        return _report;
    }

    private void Move(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
    }
    private void Rotate(char direction)
    {
        if(direction is 'L') _directionController.TurnLeft();
        if(direction is 'R') _directionController.TurnRight();
    }

    private void UpdateReport()
    {
        _report = "";
        if (_facingObstacle)
        {
            _report += 'O';
            _report += ':';
        }
        _report += _posX;
        _report += ':';
        _report += _posY;
        _report += ':';
        _report += _directionController.GetFacing();
    }
}