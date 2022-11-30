using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GlobalSettings : MonoBehaviour
{
    static public float waterResistance = 1f * Time.deltaTime;
    static public float gridStep = 4f;
}
