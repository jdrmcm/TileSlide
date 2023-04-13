using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelBuilder : MonoBehaviour
{
    public int index = 0;

    public List<Block> level = new List<Block>();

    [SerializeField] TMP_InputField inputField;

    public void AddTile(int type, double[] position)
    {
        Block block = new Block(type, position, index);
        level.Add(block);
        index++;
    }

    public void RemoveTile(double[] position)
    {
        int index = 0;

        for (int i = 0; i < level.Count; i++)
        {
            if (position[0] == level[i].xPos)
            {
                if (position[1] == level[i].yPos)
                {
                    index = level[i].index;
                    level.RemoveAt(i);
                }
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject tile = transform.GetChild(i).gameObject;

            if (index == tile.GetComponent<TilePiece>().index)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void ClearLevel()
    {
        level.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        index = 0;
    }

    public bool ContainsTile(double[] position)
    {
        bool occupied = false;

        for (int i = 0; i < level.Count; i++)
        {
            if (level[i] != null)
            {
                if (level[i].GetPosition()[0] == position[0])
                {
                    if (level[i].GetPosition()[1] == position[1])
                    {
                        occupied = true;
                    }
                }
            }
        }
        return occupied;
    }

    public void SaveLevel()
    {
        FileHandler.SaveToJSON<Block>(level, inputField.text + ".dat");
    }
}
