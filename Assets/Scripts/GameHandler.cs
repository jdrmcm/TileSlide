using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject grid;
    [SerializeField] List<Block> level = new List<Block>();

    void Start()
    {
        if (LoadHelper.levelToLoad != null)
        {
            LoadLevel(LoadHelper.levelToLoad);
        }
    }

    void LoadLevel(string target)
    {
        level = FileHandler.ReadFromJSON<Block>(target);

        foreach (var item in level)
        {
            PlaceTile(item);
        }
    }

    void PlaceTile(Block tile)
    {
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            GridPiece gridPiece = grid.transform.GetChild(i).GetComponent<GridPiece>();

            if (tile.xPos == gridPiece.pos[0])
            {
                if (tile.yPos == gridPiece.pos[1])
                {
                    GameObject obj = Instantiate(objects[tile.type], GetTilePos(tile), Quaternion.identity);
                    obj.GetComponent<TilePiece>().index = tile.index;
                }
            }
        }
    }

    private Vector3 GetTilePos(Block tile)
    {
        Vector3 pos = new Vector3((float)(tile.xPos), (float)(tile.yPos));

        return pos;
    }
}
