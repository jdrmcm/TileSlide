using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridPiece : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    private TMP_Dropdown dropdown;
    private LevelBuilder levelBuilder;
    private int[] pos = new int[2];

    private void Start()
    {
        pos[0] =  Mathf.Abs(Mathf.RoundToInt((float)(transform.position.x + 1.5)));
        pos[1] =  Mathf.Abs(Mathf.RoundToInt((float)(transform.position.y - 2.5)));

        dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();
    }

    private void OnMouseDown()
    {
        if (!levelBuilder.ContainsTile(pos))
        {
            int index = dropdown.value;

            GameObject tile = Instantiate(objects[index], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            tile.transform.SetParent(GameObject.Find("LevelBuilder").transform);

            levelBuilder.AddTile(objects[index], pos);
        }
    }
}
