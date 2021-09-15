using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyOptimizer : MonoBehaviour
{
    public float waitTime = 1f;
    public float linearVelocityLimit = 0.01f;
    public float angularVelocityLimit = 0.01f;
    //List<Rigidbody> rigidbodies;
    List<RigidWithTime> rigidbodies;
    // Start is called before the first frame update
    void Start()
    {
       //rigidbodies = new List<Rigidbody>();
       rigidbodies = new List<RigidWithTime>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = rigidbodies.Count-1; i >= 0; i--){
            // Rigidbody body = rigidbodies[i];
            // if (body.velocity.magnitude < linearVelocityLimit && body.angularVelocity.magnitude < angularVelocityLimit){
            //     rigidbodies.RemoveAt(i);
            //     Destroy(body);
            // }
            RigidWithTime body = rigidbodies[i];
            if (Time.time > body.startTime + body.waitTime){
                if (body.rigidbody.velocity.magnitude < linearVelocityLimit && body.rigidbody.angularVelocity.magnitude < angularVelocityLimit){
                    rigidbodies.RemoveAt(i);
                    Destroy(body.rigidbody);
                }
            }
        }
    }

    public void AddBody(Rigidbody body){
        rigidbodies.Add(new RigidWithTime(body, Time.time, waitTime));
    }
}
