using System;
using System.Runtime.CompilerServices;

namespace DotnetStarter.Logic;

public class Rover
{
    private int pos_x;
    private int pos_y;
    private int facing;
    private string report;

    public Rover(Grid grid)
    {
        pos_x = 0;
        pos_y = 0;
        facing = 0;
        UpdateReport();
    }
    
    public void ExecuteCommands(string commands)
    {
        foreach (char command in commands)
        {
            if (command is 'M')
            {
                Move();
            }
            else if (command is 'L' or 'R')
            {
                Rotate(command);
            }
        }
        
        UpdateReport();
    }

    public string GetReport()
    {
        return report;
    }

    private void Move()
    {
        switch (facing)
        {
            case 0:
                ++pos_y;
                break;
            case 1:
                ++pos_x;
                break;
            case 2:
                --pos_y;
                break;
            case 3:
                --pos_x;
                break;
        }
    }
    private void Rotate(char direction)
    {
        if (direction is 'L')
        {
            --facing;
            if (facing < 0)
            {
                facing = 3;
            }
        }
        else if (direction is 'R')
        {
            ++facing;
            if (facing > 3)
            {
                facing = 0;
            }
        }
    }

    private void UpdateReport()
    {
        report = "";
        report += pos_x;
        report += ':';
        report += pos_y;
        report += ':';
        string facingChar = "";
        switch (facing)
        {
            case 0:
                facingChar = "N";
                break;
            case 1:
                facingChar = "E";
                break;
            case 2:
                facingChar = "S";
                break;
            case 3:
                facingChar = "W";
                break;
        }

        report += facingChar;
    }
}