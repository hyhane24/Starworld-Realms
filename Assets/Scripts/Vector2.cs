using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vector2
{
    public int x, z;

    public Vector2(int x,int z)
    {
        this.x = x;
        this.z = z;
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        // Debug.Log("Plus called");
        a.x += b.x;
        a.z += b.z;
        return a;
    }
}
