using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//--------------------------------------------------------------------------
// Define the behaviour of each cell type within these classes.
//--------------------------------------------------------------------------

// Couple of specific Cell classes that each have their own attributes/methods.
// Each cell type has an update function. These are to be modified/expanded as part of the exercise



// Cell class B
public class CellB : Cell
{
    private string type = "B";

    public CellB(GameObject gameObj, int x, int y, Environment env) : base(gameObj, x, y, env)
    {
        this.Type = "B";
        this.R = 255;
        this.G = 255;
        this.B = 255;
    }

    // Define any help functions and or variables needed for the update

    public override void Update()
    {
        // In here define functions of what happens, based on neighbors,
        if (Age < 100)
        {
            Age++;
        }
        Height = 1 + (Age / 30);
        int lives = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (!(i == 0 && j == 0))
                {
                    Cell neighbour = GetNeighbour(i, j);
                    if (neighbour.Type == "B")
                    {
                        lives++;
                    }
                }
            }
        }
        if (lives < 2 || lives > 3)
        {
            ChangeA();
        }
    }
}