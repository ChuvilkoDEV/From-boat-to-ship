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
    private Vector3 cursorXZ;
    private float angeInRadians = 45 * Mathf.PI / 180;
    private float g = Physics.gravity.y;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out cursor, 1000, layerMaskWater)) {
                Vector3 fromTo = cursor.point - transform.position;
                Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
                float distanceXZ = fromToXZ.magnitude;
                float distanceY = fromTo.y;

                float v2 = (g * Mathf.Pow(distanceXZ, 2)) / (2 * (distanceY - Mathf.Tan(angeInRadians) * distanceXZ) * Mathf.Pow(Mathf.Cos(angeInRadians), 2));
                float v = Mathf.Sqrt(Mathf.Abs(v2));

                GameObject ball = Instantiate(Cannonball, transform);
                transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
                //transform.eulerAngles = new Vector3(0f, transform.rotation.y, transform.rotation.z);
                ball.transform.localEulerAngles = Vector3.right * (-30);
                ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * v;
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
