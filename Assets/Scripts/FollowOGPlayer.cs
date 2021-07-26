using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOGPlayer : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    //camera transform
 
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
 
    private void Start()
    {
    }
 
    private void LateUpdate()
    {
        // update position
        transform.position = Target.transform.position;
        transform.rotation = Target.transform.rotation;
 
    }
}