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
        //if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(Cannonball, transform);
            //ball.transform.localPosition += Vector3.forward * 2;
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * CannonballSpeed);
        }
    }

    private void CalculateAngle()
    {

    }
}
