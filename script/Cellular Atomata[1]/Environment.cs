using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Essenstially a 2d Array holding the cells
public class Environment
{
    private int width;
    private int height;

    private Cell[,] grid;

    public Environment(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.grid = new Cell[this.width, this.height];
    }

    public int Width
    {
        get { return width; }
    }
    public int Height
    {
        get { return height; }
    }

    public Cell GetCell(int x, int y)
    {
        return grid[remapX(x), remapY(y)];
    }

    public void SetCell(Cell cell, int x, int y)
    {
        grid[remapX(x), remapY(y)] = cell;
    }

    private int remapX(int x)
    {
        if (x < 0)
        {
            return x + width;
        }
        else if (x >= width)
        {
            return x - width;
        }
        else return x;
    }

    private int remapY(int y)
    {
        if (y < 0)
        {
            return y + height;
        }
        else if (y >= height)
        {
            return y - height;
        }
        else return y;
    }

    // Update functions that calls all update functions of the different cells
    public void Update()
    {
        // First update all cells

        for (int i = 0; i < this.width; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                Cell cell = this.grid[i, j];
                cell.Update();
            }
        }
        for (int i = 0; i < this.width; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                Cell cell = this.grid[i, j];
                string changeFlag = cell.ChangeFlag;
                if (changeFlag == "A")
                {
                    GameObject go = cell.GameObj;
                    this.grid[i, j] = new CellA(go, cell.X, cell.Y, this);
                }
                else if (changeFlag == "B")
                {
                    GameObject go = cell.GameObj;
                    this.grid[i, j] = new CellB(go, cell.X, cell.Y, this);
                }
                else if (changeFlag == "C")
                {
                    GameObject go = cell.GameObj;
                    this.grid[i, j] = new CellC(go, cell.X, cell.Y, this);
                }
            }
        }
    }
}
