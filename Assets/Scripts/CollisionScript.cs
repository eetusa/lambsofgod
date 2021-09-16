using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag=="Pet"){
            if (rbody == null){
                rbody = gameObject.AddComponent<Rigidbody>();     
                
                rbody.AddForce(collision.relativeVelocity , ForceMode.Impulse); 
               // rigidbody.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity*5f, ForceMode.Impulse);
            }
        }
        
        
    }
}
