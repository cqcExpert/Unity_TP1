using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    void Start()
    {
        

    }

    void Update()
    {
        transform.position=new Vector3(transform.position.x, transform.position.y-1*20 * Time.deltaTime, transform.position.z);

        //or
        // transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
    }

}
