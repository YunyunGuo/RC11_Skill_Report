using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class of all cell types, constructor needs an instantiated GameBox or GameSphere
// After that all operations of those game objects will happen internally
public abstract class Cell
{
    private Environment environment;
    private Vector3 position;
    private GameObject gameObj;
    // a 2d array holding the neighbouring cells internally.
    // Watch out, the middle will not be initialised since that is this cell. 
    private int height = 1;
    private Vector3 dimensions = new Vector3(1, 1, 1);

    private string type;

    // A string flag that can be set if the type of cell needs to be changed
    private string changeFlag;

    // Age counter
    private int age;

    // private RGB values:
    private int r = 0;
    private int g = 0;
    private int b = 0;

    // Abstract constructor of a cell.
    public Cell(GameObject gameObj, int x, int y, Environment env)
    {
        this.environment = env;
        this.gameObj = gameObj;
        this.position = new Vector3(x, height / 2, y);
        this.gameObj.transform.position = this.position;
        this.gameObj.transform.localScale = this.dimensions;
    }

    public int EnvWidth {
        get { return environment.Width; }
    }

    public int EnvHeight {
        get { return environment.Height; }
    }

    public int X
    {
        get { return (int)position.x; }
        set
        {
            position.x = value;
            gameObj.transform.position = position;
        }
    }

    public int Y
    {
        get { return (int)position.z; }
        set
        {
            position.y = value;
            gameObj.transform.position = position;
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            height = value;
            position.y = height / 2;
            dimensions.y = height;
            gameObj.transform.position = position;
            gameObj.transform.localScale = dimensions;
        }
    }

    public string ChangeFlag
    {
        get { return changeFlag; }
    }

    public void ChangeA()
    {
        changeFlag = "A";
    }

    public void ChangeB()
    {
        changeFlag = "B";
    }

    public void ChangeC()
    {
        changeFlag = "C";
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public GameObject GameObj
    {
        get { return gameObj; }
    }

    public int R
    {
        get { return r; }
        set
        {
            r = value;
            Color colour = new Color32((byte)r, (byte)g, (byte)b, 255); ;
            gameObj.GetComponent<MeshRenderer>().material.color = colour;
        }
    }
    public int G
    {
        get { return g; }
        set
        {
            g = value;
            Color colour = new Color32((byte)r, (byte)g, (byte)b, 255); ;
            gameObj.GetComponent<MeshRenderer>().material.color = colour;
        }
    }
    public int B
    {
        get { return b; }
        set
        {
            b = value;
            Color colour = new Color32((byte)r, (byte)g, (byte)b, 255); ;
            gameObj.GetComponent<MeshRenderer>().material.color = colour;
        }
    }

    public Cell GetNeighbour(int i, int j)
    {
        return this.environment.GetCell(X + i, Y + j);
    }

    public abstract void Update();
}