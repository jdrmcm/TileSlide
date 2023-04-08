using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    private int[] pos = new int[2];
    private GameObject type;

    public void SetPosition(int[] input)
    {
        this.pos[0] = input[0];
        this.pos[1] = input[1];
    }

    public int[] GetPosition()
    {
        return this.pos;
    }

    public void SetTile(GameObject input)
    {
        this.type = input;
    }

    public GameObject GetTile()
    {
        return this.type;
    }
}
