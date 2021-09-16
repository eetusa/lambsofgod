using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCollision : MonoBehaviour
{
    
    public RigidbodyOptimizer rigidbodyOptimizer;
    public bool rammingOn = false;
    public bool explosiveHit = false;
    public float hitForceMultiplier = 1f;
    public float sphereCollisionRange = 1f;
    //Rigidbody petRigidbody;
    //public Collider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        //petRigidbody = gameObject.GetComponent<Rigidbody>();
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
                    List<BuildCube> buildcubes = new List<BuildCube>();
                    foreach (var hitCollider in hitColliders){
                        if (hitCollider.tag == "Wall" && hitCollider.GetComponent<Rigidbody>() == null){
                            if (hitCollider.gameObject.GetComponent<BuildCube>() != null){
                                buildcubes.Add(hitCollider.gameObject.GetComponent<BuildCube>());
                                hitCollider.gameObject.GetComponent<BuildCube>().isStatic = false;
                            }
                            rigidbodyOptimizer.AddBody(hitCollider.gameObject.AddComponent<Rigidbody>());
                            if (explosiveHit){
                                if (hitCollider.gameObject != collision.gameObject){
                                   // var direction = Quaternion.Euler(0, 0, Random.Range(-45f, 45f)) * (-collision.relativeVelocity);

                                    Vector3 dir =  gameObject.transform.position - hitCollider.gameObject.transform.position;
                                    float distance = Vector3.Distance(gameObject.transform.position, hitCollider.gameObject.transform.position);
                                    dir = dir.normalized;
                                   // hitCollider.gameObject.GetComponent<Rigidbody>().AddForce(direction*hitForceMultiplier , ForceMode.Impulse); 
                                   hitCollider.gameObject.GetComponent<Rigidbody>().AddForce(dir * -collision.relativeVelocity.magnitude * hitForceMultiplier * (1/ Mathf.Sqrt( distance )) , ForceMode.Impulse); 
                                }
                                
                            }
                        }
                    }
                    foreach (BuildCube cube in buildcubes){
                        cube.getHit();
                    }
                    if (collision.gameObject.GetComponent<Rigidbody>() == null){
                        rigidbodyOptimizer.AddBody(collision.gameObject.AddComponent<Rigidbody>());
                    } 
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.relativeVelocity*hitForceMultiplier , ForceMode.Impulse); 

                    
                    
                    
            //  }
            }
        }
    }
}
