using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteRecorder : MonoBehaviour
{
    public bool hasStarted;
    public float time;
    public AudioSource theSong;

    public KeyCode keyToPress;
    public List<float> yellowTime = new List<float>();
    int i = 0;



    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted != false)
        {
            //On keypress, places the time in the song in which the key was pressed
            if (Input.GetKeyDown(keyToPress))
            {
                yellowTime.Add(theSong.time);
                Debug.Log("Note Press at: " + yellowTime[i]);
                i++;
            }
            if (Input.GetKeyDown(KeyCode.S)) //Save array into json
            {
                Save();
            }
        }
        
    }

    void Save()
    {
        Debug.Log("Size of array: " + yellowTime.Count);

        //Path of the file
        string path = "Assets/NoteData/YellowTime.txt";
        
        //Content
        string arrayContent = "";
        File.WriteAllText(path, arrayContent);
        for (int i = 0; i < yellowTime.Count; i++)
        {
            if(i == yellowTime.Count -  1)
            {
                arrayContent = yellowTime[i].ToString();
                File.AppendAllText(path, arrayContent);

            }
            else
            {
                arrayContent = yellowTime[i].ToString() + "\n";
                //Create File
                File.AppendAllText(path, arrayContent);
            }
        }
          
    }
}
