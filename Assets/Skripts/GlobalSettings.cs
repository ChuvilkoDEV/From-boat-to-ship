using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GlobalSettings : MonoBehaviour
{
    static public float waterResistance;
    static public float gridStep = 4f;

    public static Ray ray;

    private void Awake()
    {
        waterResistance = 1f * Time.deltaTime;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction);
    }
}
