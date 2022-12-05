using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public GameObject Cannonball;
    public float CannonballSpeed;

    //private GameObject[] Cannonbolls;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(Cannonball, transform);
            //ball.transform.localPosition += Vector3.forward * 2;
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * CannonballSpeed);
        }
    }

    private float CalculateAngle(float S)
    {
        float underSin = (S * Physics.gravity.y) / Mathf.Pow(CannonballSpeed, 2);
        if (underSin > 1)
            return -90;
        return Mathf.Asin(underSin) / 2;
    }
}
