using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridPiece : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] bool active = true;

    private TMP_Dropdown dropdown;
    private LevelBuilder levelBuilder;
    private GameObject saveScreen;

    public double[] pos = new double[2];
    
    private void Start()
    {
        pos[0] =  (double)transform.position.x;
        pos[1] =  (double)transform.position.y;

        if (active)
        {
            dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
            levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();
            saveScreen = GameObject.Find("Canvas").transform.Find("SaveScreen").gameObject;
        }
    }

    private void OnMouseDown()
    {
        if(active)
        {
            if (!saveScreen.activeInHierarchy)
            {
                if (!levelBuilder.ContainsTile(pos))
                {
                    int index = dropdown.value;

                    GameObject tile = Instantiate(objects[index], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    tile.transform.SetParent(GameObject.Find("LevelBuilder").transform);
                    tile.GetComponent<TilePiece>().index = levelBuilder.index;

                    levelBuilder.AddTile(index, pos);
                }
                else
                {
                    levelBuilder.RemoveTile(pos);
                }
            }
        }
    }
}
