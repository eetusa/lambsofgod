using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidWithTime
{
    public Rigidbody rigidbody;
    public float startTime;
    public float waitTime;

    public RigidWithTime(Rigidbody body, float start, float wait){
        this.rigidbody = body;
        this.startTime = start;
        this.waitTime = wait;
    }
}
