using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //How fast arrows fall down
    public float beatTempo;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        //How fast it moves per second
        beatTempo = beatTempo / 60;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted!= false)
        {
            //transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
        
    }
}
