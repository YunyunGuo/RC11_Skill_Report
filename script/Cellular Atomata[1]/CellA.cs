using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//--------------------------------------------------------------------------
// Define the behaviour of each cell type within these classes.
//--------------------------------------------------------------------------

// Couple of specific Cell classes that each have their own attributes/methods.
// Each cell type has an update function. These are to be modified/expanded as part of the exercise


// Cell class A
public class CellA : Cell
{
    // Constructor of an CellA Object
    public CellA(GameObject gameObj, int x, int y, Environment env) : base(gameObj, x, y, env)
    {
        // Here define the base colour of CellA
        this.Type = "A";
        this.R = 0;
        this.G = 0;
        this.B = 0;
    }

    // Define any help functions and or variables needed for the update
    int thresholdA = 80;

    public override void Update()
    {
        /* In here define functions of what happens, based on neighbors,
        age, height, and the rgb values.


        The age and height can be accessed simply through Age, Height, for instance:
        Increment age by one:
        Age++;
        Retrieve the current height by defining an integer h:
        int h = Height;

        To change the colour, the r,g,b attributes can be changed. These can all
        be changed by simply declaring a new integer number between 0 and 255. So
        Making a cell blue:
        R = 0;
        G = 0;
        B = 255;

        The current values can also be accessed like that:
        float r = R;

        To get a neighbour, use the method getNeighbour(int i, int j), where
        i and j are the indeces counted from the current cell. So the one to the left and up:
        Cell cell = getNeighbour(-1,1);
        After which you can get the different attributes of that cell like this:
        for instance the age:
        int ageNeighbour = cell.Age;

        The type of a neighbor can also be read:
        string typeNeighbour = cell.Type; -> (typeNeighbour == "A" if the neighbour is a CellA object)

        HOWEVER BE CAREFULL NOT TO SET THE TYPE OF A NEIGHOUR!!!


        To let the Environment know a cell should be changed to an
        instance of another type of cell you use a flag, so say you want to
        change this cell to a CellB next frame:
        ChangeB();
        */

        if (Age < 100)
        {
            Age++;
        }
        Height = 1 + (Age / 10);

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
        if (lives == 3)
        {
            ChangeB();
        }
        else
        {
            R = X;
            G = Y;
            B = 0;
        }
    }
}