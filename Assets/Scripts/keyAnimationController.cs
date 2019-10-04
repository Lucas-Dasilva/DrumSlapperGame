using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAnimationController : MonoBehaviour
{
    public Animator keyPop;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public KeyCode keyToPress;
    void Start()
    {
        keyPop = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            keyPop.Play("red_pop");
        }
        if (Input.GetKeyDown(keyToPress))
        {
            keyPop.Play("green_pop");
        }
        if (Input.GetKeyDown(keyToPress))
        {
            keyPop.Play("purple_pop");
        }
        if (Input.GetKeyDown(keyToPress))
        {
            keyPop.Play("yellow_pop");
        }
        if (Input.GetKeyDown(keyToPress))
        {
            keyPop.Play("blue_pop");
            
        }
    }
}
