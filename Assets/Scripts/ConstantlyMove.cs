using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyMove : MonoBehaviour
{
    public float movespeed;
    public float startspeed = 30;
    public float k;
    public float m;
    public int framecount=0;
    public bool grinding;
    public GameObject BoostObject;
    // Start is called before the first frame update
    void Start()
    {
        k = 90f;
        m = 0.000002f;
        framecount=0;
        grinding = false;
    }

    // Update is called once per frame
    void Update()
    {
        framecount += 1;
        // if(!grinding){
          transform.Translate(transform.forward * movespeed * Time.deltaTime);
        // }
        if (BoostObject.GetComponent<Boost>().boosting == false){
            movespeed = startspeed + k - (1f/(m*(float)framecount + 1f/k));
        }
    }
}

/*     ________________
______|________________|______
  //-----------------------\
//    _^^^_           _^^^_ \
/    ( ^ )         |  ( ^ )  \
\       --       ) )    --   |     
  \           ____________    \
    \        (\__\__\__\__\    |   ¿el problema?
      \       \__\__\__\___)  /
        -          _____     / 
           \\\\\\\\\\\\\\\\\/
*/