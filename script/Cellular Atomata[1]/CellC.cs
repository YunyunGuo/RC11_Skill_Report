using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//--------------------------------------------------------------------------
// Define the behaviour of each cell type within these classes.
//--------------------------------------------------------------------------

// Couple of specific Cell classes that each have their own attributes/methods.
// Each cell type has an update function. These are to be modified/expanded as part of the exercise

// Cell class C
public class CellC : Cell
{
    private string type = "C";

    public CellC(GameObject gameObj, int x, int y, Environment env) : base(gameObj, x, y, env)
    {
        this.Type = "C";
        this.R = 100;
        this.G = 100;
        this.B = 100;
    }
    // Define any help functions and or variables needed for the update

    public override void Update()
    {
        // In here define functions of what happens, based on neighbors,
        Age++;
    }
}