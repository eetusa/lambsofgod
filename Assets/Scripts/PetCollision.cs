using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCollision : MonoBehaviour
{
    public RigidbodyOptimizer rigidbodyOptimizer;
    public bool rammingOn = false;
    public bool explosiveHit = false;
    public float sphereCollisionRange = 1f;
    //public Collider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (rammingOn){

        
            if (collision.gameObject.tag == "Wall"){
                print("Hit");
            // if (collider.gameObject.GetComponent<Rigidbody>() == null){
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereCollisionRange);
                    foreach (var hitCollider in hitColliders){
                        if (hitCollider.tag == "Wall" && hitCollider.GetComponent<Rigidbody>() == null){
                            rigidbodyOptimizer.AddBody(hitCollider.gameObject.AddComponent<Rigidbody>());
                            if (explosiveHit){
                                if (hitCollider.gameObject != collision.gameObject){
                                    var direction = Quaternion.Euler(0, 0, Random.Range(-45f, 45f)) * (-collision.relativeVelocity);
                                    hitCollider.gameObject.GetComponent<Rigidbody>().AddForce(direction , ForceMode.Impulse); 
                                }
                                
                            }
                        }
                    }
                    if (collision.gameObject.GetComponent<Rigidbody>() == null){
                        rigidbodyOptimizer.AddBody(collision.gameObject.AddComponent<Rigidbody>());
                    } 
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.relativeVelocity , ForceMode.Impulse); 

                    
                    
                    
            //  }
            }
        }
    }
}
