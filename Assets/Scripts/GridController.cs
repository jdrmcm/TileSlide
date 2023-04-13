using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS ALL DEPRECATED!! ONLY HERE FOR REFERENCE

public class GridController : MonoBehaviour
{
    [SerializeField] private GameObject yellow;
    [SerializeField] private GameObject blue1;
    [SerializeField] private GameObject blue2;
    [SerializeField] private GameObject green1;
    [SerializeField] private GameObject green2;
    [SerializeField] private GameObject red1;
    [SerializeField] private GameObject red2;
    [SerializeField] private GameObject red3;
    [SerializeField] private GameObject red4;

    //private MDArrayFlattener arrayFlattener;

    string[,] grid = new string[5, 4];
    
    void Start()
    {
        // Early level design (removing later lmfao)
        grid[0, 0] = "y";
        grid[1, 0] = "y";
        grid[2, 0] = "r1";
        grid[3, 0] = "r3";
        grid[4, 0] = "y";
        grid[0, 1] = "b1";
        grid[1, 1] = "b2";
        grid[2, 1] = "r2";
        grid[3, 1] = "r4";
        grid[4, 1] = "y";
        grid[1, 2] = "y";
        grid[2, 2] = "g1";
        grid[3, 2] = "b1";
        grid[4, 2] = "b2";
        grid[1, 3] = "y";
        grid[2, 3] = "g2";
        grid[3, 3] = "y";
        grid[4, 3] = "y";


        // Instantiate all the grid objects in relative coordinates based off 2d matrix
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                GameObject obj = DeserializeObject(grid[y, x]);

                if (obj != null)
                {
                    Instantiate(obj, new Vector3(x, -y, 0), Quaternion.identity);
                }
            }
        }

        //string[] flattened = arrayFlattener.Flatten2DArray(grid);
    }

    void Update()
    {

    }

    GameObject DeserializeObject(string key)
    {
        switch(key)
        {
            case "y":
                return yellow;
            case "b1":
                return blue1;
            case "b2":
                return blue2;
            case "g1":
                return green1;
            case "g2":
                return green2;
            case "r1":
                return red1;
            case "r2":
                return red2;
            case "r3":
                return red3;
            case "r4":
                return red4;
            default:
                return null;
        }
    }
}
