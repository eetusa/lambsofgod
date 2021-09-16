using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCube : MonoBehaviour
{
    public List<BuildCube> relyOn;
    public List<BuildCube> relyOnMe;
    public float attachmentSpereRange = 1f;    
    public bool isStatic;
    public bool lostSupport;
    public Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        isStatic = true;
        lostSupport = false;
        List<BuildCube> relyOn = new List<BuildCube>();
        List<BuildCube> relyOnMe = new List<BuildCube>();
        cubeRenderer = GetComponent<Renderer>();
    }

    public void loseSupport(){
        lostSupport = true;
    }

    public void getHit(){
        isStatic = false;
        getNearByStaticCubes();
    }

    void getNearByStaticCubes(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attachmentSpereRange);
        for (int i = 0; i < hitColliders.Length; i++){
            Collider collider = hitColliders[i];
            if (collider.tag == "Wall"){
                BuildCube target = collider.gameObject.GetComponent<BuildCube>();
                if (target.isStatic){
                    print("here");
                    collider.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
                    //BuildCube target = collider.gameObject.GetComponent<BuildCube>();
                    if (collider.transform.position.y > transform.position.y-(attachmentSpereRange/2)){
                        
                    }
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
