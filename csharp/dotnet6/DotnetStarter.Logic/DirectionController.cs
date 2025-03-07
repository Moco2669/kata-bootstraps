using System;
using System.Data;
using DotnetStarter.Logic.Enums;

namespace DotnetStarter.Logic;

public class DirectionController
{
    private Direction facing;

    public DirectionController()
    {
        facing = Direction.N;
    }

    public void TurnLeft()
    {
        facing = (Direction)(((int)facing - 1 + 4) % 4);
    }
    public void TurnRight()
    {
        facing = (Direction)(((int)facing + 1) % 4);
    }

    public Direction GetFacing()
    {
        return facing;
    }

    public (int, int) GetFacingAsCoordinates()
    {
        switch (facing)
        {
            case Direction.N:
                return (0, 1);
            case Direction.E:
                return (1, 0);
            case Direction.S:
                return (0, -1);
            case Direction.W:
                return (-1, 0);
            default:
                throw new InvalidConstraintException();
        }
    }
}