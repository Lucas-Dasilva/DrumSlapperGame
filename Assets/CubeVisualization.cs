using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVisualization : MonoBehaviour 
{
    public GameObject kickCube;
    public GameObject snareCube;
    public GameObject hiCube;

    public float maxScale;
    //Kick drum = 60-100 hz == 1.5-2.56
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i =0; i < 4; i++)
        {
            kickCube.transform.localScale = new Vector3(1, (AudioPeer.audioSamples[i] * maxScale) + 2, 1); 
        }
        for (int i = 7; i < 10; i++)
        {
            snareCube.transform.localScale = new Vector3(1, (AudioPeer.audioSamples[i] * maxScale) + 2, 1);
        }
        for (int i = 400; i < 450; i++)
        {
            hiCube.transform.localScale = new Vector3(1, (AudioPeer.audioSamples[i] * 1000) + 2, 1);
        }

    }
}
