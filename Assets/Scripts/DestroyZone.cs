using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyZone : MonoBehaviour
{
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Roche")){
            Destroy(other.gameObject);
        }
    }
}
