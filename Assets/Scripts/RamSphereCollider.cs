using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamSphereCollider : MonoBehaviour
{
    public Transform parent;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = parent.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
     //   transform.rotation = parent.rotation;
        transform.position = parent.position;
    }
}
