using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private Block[] level = new Block[20];

    private int index = 0;

    public void AddTile(GameObject type, int[] position)
    {
        Block block = new Block();
        block.SetTile(type);
        block.SetPosition(position);
        level[index] = block;
        index++;
    }

    public void ClearLevel()
    {
        for (int i = 0; i < level.Length; i++)
        {
            level[i] = null;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        index = 0;
    }

    public bool ContainsTile(int[] position)
    {
        bool occupied = false;

        for (int i = 0; i < level.Length; i++)
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
}
