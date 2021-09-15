using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject closestJointObject;
    ConfigurableJoint closestJoint;
    Rigidbody myRigidBody;
    Vector3 direction;
    Vector3 velocity;
    Vector3 jump;
    public float jumpForce = 2.0f;
    public float thrustForce;
    public float jumpHeight;
    public float jointForce = 10f;

    public PetCollision petCollision;

    public float velocityLimit = 1f;
    float gravity;
    bool isGrounded;
    //UnityEngine.
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        closestJoint = closestJointObject.GetComponent<ConfigurableJoint>();
        myRigidBody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        gravity = Physics.gravity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        direction = input.normalized;
        velocity = direction * speed;
        if (Input.GetKey(KeyCode.Mouse0)){
            petCollision.rammingOn = true;
        } else {
            petCollision.rammingOn = false;
        }
        // if (closestJoint. > jointForce){
        //    // myRigidBody.AddForce (jump * Mathf.Sqrt(2*gravity * jumpHeight), ForceMode.VelocityChange);
        //    print("break!");
        // }
        //print(velocity);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)){
            print("jump");
           // myRigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
           
            myRigidBody.AddForce (jump * Mathf.Sqrt(2*gravity * jumpHeight), ForceMode.VelocityChange);
          //  isGrounded = false;
        }
    }

    void FixedUpdate(){
       // myRigidBody.position += velocity * Time.fixedDeltaTime;
        //myRigidBody.velocity = new Vector3(velocity.x, myRigidBody.velocity.y, velocity.z);  // aika hyvä mut lammas klippaa
      //  myRigidBody.velocity += new Vector3(0,myRigidBody.velocity.y,0);
     // myRigidBody.AddForce(velocity * thrustForce, ForceMode.Force);
        //  if (closestJoint.currentForce.magnitude > jointForce){
        //     myRigidBody.AddForce(velocity*5, ForceMode.VelocityChange);
        //  } else {
              myRigidBody.MovePosition(myRigidBody.position + velocity);
        //  }
        // aika hyvä
   // myRigidBody.AddForce(velocity*2, ForceMode.VelocityChange); // hyvä mut vaatis k"kitkan"
    // if ((myRigidBody.velocity+velocity).magnitude <= velocityLimit){
    //     myRigidBody.velocity = myRigidBody.velocity.normalized*velocityLimit;
    // }
    
       
    
    
     //   myRigidBody.add
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Floor"){
            //print("Grounded");
            isGrounded = true;
        }
        
        
    }
}
