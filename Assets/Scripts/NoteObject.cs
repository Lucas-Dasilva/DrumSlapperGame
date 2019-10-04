using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }

        }
        //If note is withing pressing range
        if (gameObject.transform.position.z < 0.5f && gameObject.transform.position.z > -0.5f)
        {
            canBePressed = true;
        }
        //If arrow goes off screen, the note is missed
        if (gameObject.transform.position.z < -2f)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            gameObject.SetActive(false);
        }

    }

}
