using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath : MonoBehaviour
{
    public static float getDistance(Vector3 a, Vector3 b)
    {
        float x = a.x - b.x;
        float z = a.z - b.z;
        return Mathf.Sqrt(x * x + z * z);
    }
}
