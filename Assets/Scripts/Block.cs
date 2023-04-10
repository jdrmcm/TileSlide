using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    public int row;
    public int column;
    public int type;
    public int index;

    public Block(int type, int[] pos, int index)
    {
        this.type = type;
        this.row = pos[0];
        this.column = pos[1];
        this.index = index;
    }

    public int[] GetPosition()
    {
        int[] pos = new int[2];
        pos[0] = this.row;
        pos[1] = this.column;
        return pos;
    }

    public int GetTile()
    {
        return this.type;
    }
}
