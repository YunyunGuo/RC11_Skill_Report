using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // The game object
    [SerializeField]
    private  GameObject GameBox;


    // If you would like to change the initial state of the environment,
    // adjust the following function.
    // Currently all cells are randomly assigned as either CellA,B or C.

    // One way to change this is using an attractor object, which you can drag around
    // Through that you can define certain starting zones.

    private void fillEnvironment(Environment env) {
        for (int i = 0; i < env.Width; i++) {
            for (int j = 0; j < env.Height; j++) {

                // Gets a random number between 0-2.
                // 0 - > A, 1- > B, 2 -> C

                //For current version only 0 and one are valid, if you want to
                // include CellC, change the range to 0,3
                int cT = Random.Range(0, 2);
                if(cT == 0) {
                    Cell cell = new CellA(Instantiate(GameBox), i, j, env);
                    env.SetCell(cell, i, j);
                }
                else if (cT == 1) {
                    Cell cell = new CellB(Instantiate(GameBox), i, j, env);
                    env.SetCell(cell, i, j);
                }
                else if (cT == 2) {
                    Cell cell = new CellC(Instantiate(GameBox), i, j, env);
                    env.SetCell(cell, i, j);
                }
            }
        }
    }

    // Here the environment is initialised.
    // To make the grid larger, change the arguments to the desired width and depth
    private Environment environment = new Environment(200, 200);


    // Start is called before the first frame update
    void Start(){
        // Here the initial base environment is initiated
        fillEnvironment(environment);
    }

    // You can change this variable to adjust the framerate of the progression.
    // Keep it between 1 and 30 though. 
    int speed = 10;

    // Update is called once per frame
    void Update(){
        Application.targetFrameRate = speed;
        // Here a function will be called which updates all cells in the environment
        environment.Update();
    }
}
