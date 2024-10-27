using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static int Random(this Vector2Int vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y + 1);
    }

    public static float Random(this Vector2 vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }

    public static Vector3 VectorOfSize(this Vector3 vector, float size)
    {
        return new Vector3(size, size, size);
    }

    public static T Random<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    public static Vector2 Random(this Vector4 vector)
    {
        return new Vector2(new Vector2(vector.x, vector.y).Random(),
            new Vector2(vector.z, vector.w).Random());
    }
}
