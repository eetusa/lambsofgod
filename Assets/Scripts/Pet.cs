using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float gravityMultiplier = 1f;
    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdtate(){
        
        rbody.AddForce( new Vector3(0f, -Physics.gravity.magnitude * gravityMultiplier, 0f), ForceMode.Force);
    }
}
