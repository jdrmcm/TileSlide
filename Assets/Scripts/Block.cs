using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    public double xPos;
    public double yPos;
    public int type;
    public int index;

    public Block(int type, double[] pos, int index)
    {
        this.type = type;
        this.xPos = pos[0];
        this.yPos = pos[1];
        this.index = index;
    }

    public double[] GetPosition()
    {
        double[] pos = new double[2];
        pos[0] = this.xPos;
        pos[1] = this.yPos;
        return pos;
    }

    public int GetTile()
    {
        return this.type;
    }
}
