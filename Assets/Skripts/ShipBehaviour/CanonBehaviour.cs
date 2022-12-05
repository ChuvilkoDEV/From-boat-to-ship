using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalSettings;
using static MyMath;

public class CanonBehaviour : MonoBehaviour
{
    public GameObject Cannonball;
    public float CannonballSpeed;
    public LayerMask layerMaskWater;

    private RaycastHit cursor;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out cursor, 1000, layerMaskWater)) {
                float distance = getDistance(transform.position, cursor.point);
                float angle = CalculateAngle(distance);
                Debug.Log(distance + ' ' + angle);

                GameObject ball = Instantiate(Cannonball, transform);
                transform.LookAt(cursor.point);
                transform.eulerAngles += Vector3.right * angle;
                ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * CannonballSpeed;
                ball.transform.parent = null;
            }
        }
    }

    private float CalculateAngle(float S)
    {
        float underSin = (S * Physics.gravity.y) / Mathf.Pow(CannonballSpeed, 2);
        if (underSin > 1)
            return -90;
        return  180 * Mathf.Asin(underSin) / 2;
    }
}
